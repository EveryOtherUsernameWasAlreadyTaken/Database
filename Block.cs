namespace SQLNS
{

using G = System.Collections.Generic;
using DBNS;

class Block : EvalEnv // Result of compiling a batch of statements or a routine (stored function or procedure) definition.
{
  public Block( DatabaseImp d, bool isFunc )
  { Db = d; IsFunc = isFunc; }

  public void ExecuteStatements( ResultSet rs )
  {
    ResultSet = rs;
    NextStatement = 0;
    while ( NextStatement < Statements.Count )
    {
      Statements[ NextStatement++ ]();
    }
  }

  public void AllocLocalValues( SqlExec e )
  {
    CheckLabelsDefined( e );
    Locals = new Value[ LocalType.Count ];
  }

  int NextStatement; // Index into Statements, can be assigned to change execution control flow.
  public G.List<System.Action> Statements = new G.List<System.Action>(); // List of actions to be executed.

  Value FunctionResult;

  public ColInfo Params;
  public DataType ReturnType;

  public G.List<DataType> LocalType = new G.List<DataType>(); // Type of the ith local variable.

  public DatabaseImp Db;

  // Lookup dictionaries for local variables and labels.
  G.Dictionary<string,int> LocalVarLookup = new G.Dictionary<string,int>();
  G.List<int> Jump = new G.List<int>();
  int JumpUndefined = 0; // Number of jump labels awaiting definition.
  G.Dictionary<string,int> JumpLookup = new G.Dictionary<string,int>();

  public bool IsFunc;

  // Statement preparation ( parse phase ).

  public void Declare( string name, DataType type )
  {
    LocalVarLookup[ name ] = LocalType.Count;
    LocalType.Add( type );
  }  

  public int Lookup( string name ) // Gets the number of a local variable, -1 if not declared.
  {
    int result;
    if ( LocalVarLookup.TryGetValue( name, out result ) ) return result;
    return -1;
  }

  public int LookupJumpId( string name )
  {
    int result;
    if ( JumpLookup.TryGetValue( name, out result ) ) return result;
    return -1;
  }

  public System.Action Goto( string name )
  {
    int jumpid = LookupJumpId( name );
    if ( jumpid < 0 )
    {
      jumpid = Jump.Count;
      JumpLookup[ name ] = jumpid;
      Jump.Add( -1 );
      JumpUndefined += 1;
      return () => ExecuteGoto( jumpid );
    }
    else return () => JumpBack( Jump[ jumpid ] );
  }

  public bool SetLabel( string name ) // returns true if label already defined ( an error ).
  {
    int i = Statements.Count;
    int jumpid = LookupJumpId( name );
    if ( jumpid < 0 )
    {
      jumpid = Jump.Count;
      JumpLookup[ name ] = jumpid;
      Jump.Add( i );
    }
    else 
    {
      if ( Jump[ jumpid ] >= 0 ) return true;
      Jump[ jumpid ] = i;
      JumpUndefined -= 1;
    }
    return false;
  }

  public int GetHere()
  {
    return Statements.Count;
  }

  public int GetJumpId()
  {
    int jumpid = Jump.Count;
    Jump.Add( -1 );
    return jumpid;
  }

  public void SetJump( int jumpid )
  {
    Jump[ jumpid ] = Statements.Count;
  }

  public void CheckLabelsDefined( SqlExec e )
  {
    if ( JumpUndefined != 0 ) e.Error( "Undefined Goto Label" );
  }

  public int GetForId()
  {
    int forid = LocalType.Count;
    LocalType.Add( DataType.None );
    return forid;
  }

  // Statement execution.

  public void ExecProcedure( Block b, G.List<Exp> parms, SqlExec e )
  {
    // Allocate the local variables for the called procedure.
    var locals = new Value[ b.LocalType.Count ];

    // Evaluate the parameters to be passed, saving them in the newly allocated local variables.
    for ( int i = 0; i < parms.Count; i += 1 ) locals[i] = parms[ i ].Eval( this );

    // Save local state.
    var save1 = b.Locals; 
    var save2 = b.NextStatement;

    // Execute the procedure
    b.Locals = locals;
    b.ExecuteStatements( ResultSet );

    // Restore local state.
    b.NextStatement = save2; 
    b.Locals = save1;
  }

  public Value ExecuteFunctionCall( EvalEnv e, Exp [] parms )
  {
    // Allocate the local variables for the called function.
    var locals = new Value[ LocalType.Count ];

    // Evaluate the parameters to be passed, saving them in the newly allocated local variables.
    for ( int i = 0; i < parms.Length; i += 1 ) locals[i] = parms[ i ].Eval( e );

    // Save local state.
    var save1 = Locals; 
    var save2 = NextStatement;

    // Execute the function
    Locals = locals;

    ExecuteStatements( e.ResultSet );

    // Restore local state.
    NextStatement = save2; 
    Locals = save1;

    return FunctionResult;
  }

  public void Execute( Exp e )
  {
    string s = (string) ( e.Eval( this )._O );
    try
    {
      Db.ExecuteSql( s, ResultSet );    
    }
    catch ( System.Exception exception )
    {
      Db.SetRollback();
      ResultSet.Exception = exception;
    }
  }

  public void ExecuteGoto( int jumpId )
  {
    NextStatement = Jump[ jumpId ];
  }

  public void ExecuteReturn( Exp e )
  {
    if ( IsFunc ) FunctionResult = e.Eval( this );
    NextStatement = Statements.Count;
  }

  public void ExecuteIf( Exp test, int jumpid )
  {
    if ( !test.Eval( this ).B ) NextStatement = Jump[ jumpid ];
  }

  public void JumpBack( int i )
  {
    NextStatement = i;
  }

  public void ExecuteSelect( TableExpression te, int [] assigns )
  {
    if ( assigns != null ) // assigns is list of local variables to be assigned.
      te.FetchTo( new AssignResultSet( assigns, this ), this );
    else
      te.FetchTo( ResultSet, this );
  }

  public void InitFor( int c, TableExpression te, int[] assigns )
  {
    Locals[ c ]._O = new For( te, assigns, this );
  }

  public void ExecuteFor( int forid, int breakid )
  {
    For f = (For) Locals[ forid ]._O;
    if ( f == null || !f.Fetch() ) NextStatement = Jump[ breakid ];
  }

  public void ExecInsert( Table t, TableExpression te, int[] colIx, int idCol )
  {
    long lastId = t.ExecInsert( te, colIx, idCol, this );
    if ( ResultSet != null ) ResultSet.LastIdInserted = lastId;
  }

  public void SetMode( Exp e )
  {
    ResultSet.SetMode( e.Eval( this ).L );
  }

} // end class Block


class AssignResultSet : ResultSet // Implements SET assignment of local variables.
{
  int [] Assigns;
  Block B;

  public AssignResultSet( int [] assigns, Block b )
  {
    Assigns = assigns;
    B = b;
  }

  public override bool NewRow( Value [] r )
  {
    for ( int i=0; i < Assigns.Length; i += 1 ) B.Locals[ Assigns[ i ] ] = r[ i ];
    return true;
  }  
} // end class AssignResultSet


class For // Implements FOR statement.
{
  G.List<Value[]> Rows;
  int [] Assigns;
  Value[] LocalValues; 
  int Fetched;

  public For( TableExpression te, int[] assigns, Block b )
  {
    Fetched = 0;
    Assigns = assigns;
    LocalValues = b.Locals;
    var rs = new SingleResultSet();
    te.FetchTo( rs, b );
    Rows = rs.Table.Rows;
  }

  public bool Fetch()
  {
    if ( Fetched >= Rows.Count ) return false;
    Value [] r = Rows[ Fetched ++ ];
    for ( int i = 0; i < Assigns.Length; i += 1 )
      LocalValues[ Assigns[ i ] ] = r[ i ];
    return true;
  }

} // end class For

} // end namespace SQLNS
