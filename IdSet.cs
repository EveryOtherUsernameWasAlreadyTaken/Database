namespace DBNS {
using G = System.Collections.Generic;
using SQLNS;


/*

IdSet is for optimising WHERE clauses for SELECT,UPDATE,DELETE.

When accessing a large table, we only want to access a small subset of the records.

The id values may be explicit as in 

SELECT .... FROM dbo.Cust WHERE id in ( 3,4,5 )

or they may come from an index as in

SELECT .... FROM dbo.Cust WHERE Name = 'Smith'

where an index has been defined CREATE INDEX CustByName ON dbo.Cust(Name)

*/

abstract class IdSet 
{
  public abstract G.IEnumerable<long>All( EvalEnv ee );
}

class ExpListIdSet : IdSet
{
  Exp[] List;
  public ExpListIdSet( Exp[] list, EvalEnv e ) { List = list; }

  public override G.IEnumerable<long>All( EvalEnv ee )
  { 
    for ( int i = 0; i < List.Length; i += 1 )
    {
      yield return List[i].Eval( ee ).L;
    }
  }  
}

class TableExpressionIdSet : IdSet
{
  SingleResultSet S = new SingleResultSet(); 

  public TableExpressionIdSet( TableExpression te, EvalEnv ee ) 
  {
    te.FetchTo( S, ee );
  }

  public override G.IEnumerable<long>All( EvalEnv ee )
  { 
    StoredTable t = S.Table;
    G.List<Value[]> rows = t.Rows;

    for ( int i = 0; i < rows.Count; i += 1 ) 
    {
      Value[] row = rows[ i ];
      yield return row[0].L;
    }
  }
} // end class TableExpressionIdSet
  

class IdCopy : IdSet
{
  G.SortedSet<long> Copy = new G.SortedSet<long>();
  public IdCopy( IdSet x, EvalEnv ee )
  {
    foreach ( long id in x.All( ee ) ) Copy.Add( id );
  }
  public override G.IEnumerable<long>All( EvalEnv ee )
  { 
    foreach ( long id in Copy ) yield return id;
  }
}

class SingleId : IdSet
{
  Exp X;
  public SingleId( Exp x ){ X = x; }
  public override G.IEnumerable<long>All( EvalEnv ee )
  { 
    Value v = X.Eval( ee );
    yield return v.L;
  }
}

class UpTo : IdSet
{
  long N;
  public UpTo( long n ){ N = n; }
  public override G.IEnumerable<long>All( EvalEnv ee ){ for ( int i=1; i<=N; i+=1 ) yield return i; }
}

// Uses an index to look up a set of id values, optimises select ... from t where indexedcol in ( .... )
class Lookup : IdSet 
{
  G.IEnumerable<Value> Values;
  IndexFile Ix;

  public Lookup( IndexFile ix, G.IEnumerable<Value> values )
  {
    Values = values;
    Ix = ix;
  }

  public override G.IEnumerable<long>All( EvalEnv ee )
  { 
    foreach ( Value v in Values )
    {
      DataType t = Ix.Inf.Types[0];
      int idCol = Ix.Inf.KeyCount-1;
      var start = new ValueStart( v, t );
      foreach ( IndexFileRecord r in Ix.From( start.Compare, false ) )
      {
        if ( Util.Compare( v, r.Col[0], t ) == 0 )
        {
          yield return r.Col[ idCol ].L;
        }
        else break;
      }
    }
  } 
} // end class Lookup

class IndexFrom : IdSet
{
  Exp K;
  IndexFile F;
  DataType Type;
  Token Op;
  Value V;

  int Compare( ref IndexFileRecord r ) // This make not be quite optimal for Less and Greater.
  {
    int cf = 0;
    if ( Op <= Token.LessEqual ) // Op == Token.Less || Op == Token.LessEqual
    {
      switch ( Type ) 
      { 
        case DataType.Binary:
          cf = Util.Compare( (byte[])V._O, (byte[])r.Col[0]._O );
          if ( cf == 0 ) cf = +1; // Should be -1 if Op == Less ?
          break;
        case DataType.String: 
          cf = string.Compare( (string)V._O, (string)r.Col[0]._O ); 
          if ( cf == 0 ) cf = +1; // Should be -1 if Op == Less ?
          break;
        case DataType.Bigint: 
          cf = V.L < r.Col[0].L ? -1 : +1; // Should be <= if Op == Less ?
          break;   
        default: throw new System.Exception( "Type error" );     
      }
    }
    else // ( Op == Token.Greater || Op == Token.GreaterEqual || Op == Token.Equal )
    {
      switch ( Type ) 
      { 
        case DataType.Binary: 
          cf = Util.Compare( (byte[])V._O, (byte[])r.Col[0]._O ); 
          if ( cf == 0 ) cf = -1;
          break;
        case DataType.String: 
          cf = string.Compare( (string)V._O, (string)r.Col[0]._O ); 
          if ( cf == 0 ) cf = -1;
          break;
        case DataType.Bigint: 
          cf = V.L <= r.Col[0].L ? -1 : +1; 
          break;
        default: throw new System.Exception( "Type error" );
      }
    }
    return cf;    
  }
  
  public IndexFrom( IndexFile f, Exp k, Token op )
  {
    F = f; K = k; Op = op;
  }
  public override G.IEnumerable<long>All( EvalEnv ee )
  { 
    V = K.Eval( ee );
    Type = K.Type;
    foreach ( IndexFileRecord r in F.From( Compare, Op <= Token.LessEqual /* Op == Token.Less || Op == Token.LessEqual */ ) )
    {
      if ( Op == Token.Equal ) switch ( K.Type )
      { 
        case DataType.Bigint: if ( r.Col[0].L != V.L ) yield break; break;
        case DataType.Binary: if ( Util.Compare( (byte[])r.Col[0]._O, (byte[])V._O ) != 0 ) yield break; break;
        case DataType.String: if ( ((string)r.Col[0]._O) != (string)V._O ) yield break; break;
        default: throw new System.Exception( "Type error" );
      }
      yield return r.Col[ F.Inf.KeyCount-1 ].L;
    }
  }
} // end class IndexFrom

} // end namespace DBNS
