using DBNS;

class Init
{

  /* Needs a new batch before inserting into Column table ( around line 60 ) */

  public static void Go( Database d )
  {
    d.Sql( @"
INSERT INTO [sys].[Schema](Id,[Name]) VALUES 
(2,'handler')
(3,'web')
(4,'htm')
(5,'browse')
(6,'dbo')
INSERT INTO [sys].[Table](Id,[Schema],[Name],[IsView],[Definition]) VALUES 
(8,3,'File',0,'')
(9,5,'Table',0,'')
(10,5,'Column',0,'')
(11,6,'Cust',0,'')
(12,6,'Order',0,'')
(13,6,'OrderSummary',1,'SELECT 
  SUM(Total) AS Total, 
  COUNT() AS Count,
  MIN(Total) AS Min,
  MAX(Total) AS Max
FROM dbo.Order 
GROUP BY Cust')
INSERT INTO [sys].[Column](Id,[Table],[Name],[Type]) VALUES 
(21,8,'Path',2)
(22,8,'ContentType',2)
(23,8,'ContentLength',5)
(24,8,'Content',1)
(25,9,'NameFunction',2)
(26,9,'SelectFunction',2)
(27,9,'DefaultOrder',2)
(32,9,'Title',2)
(33,9,'Description',2)
(34,9,'Role',5)
(35,10,'Position',5)
(36,10,'Label',2)
(37,10,'Description',2)
(38,10,'RefersTo',5)
(39,10,'Default',2)
(40,10,'InputCols',5)
(41,10,'InputFunction',2)
(42,10,'InputRows',5)
(43,10,'Style',5)
(44,11,'FirstName',2)
(45,11,'LastName',2)
(46,11,'Age',5)
(47,11,'Postcode',2)
(48,12,'Cust',5)
(49,12,'Total',2255)
", null );

    d.Sql( @"
INSERT INTO [web].[File](Id,[Path],[ContentType],[ContentLength],[Content]) VALUES 
(1,'/img/fav.ico','image/x-icon',1086,0x00000100010010100000010020002804000016000000280000001000000020000000010020000000000000000000000000000000000000000000000000000000ffbf0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffff0000ffff00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffff0000ffff0000ffff000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffff0000ffff0000ffff0000ffff0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffff0000ffff0000ffff0000ffff0000ffff00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff000000000000000000000000000000000000000000000000000000000000000000000000000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000000000000000000000000000000000000000000000000000000000000000000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff00000000000000000000000000000000000000000000000000000000000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff000000000000000000000000000000000000000000000000000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000000000000000000000000000000000000000000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff00000000000000000000000000000000000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff000000000000000000000000000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000000000000000000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff00000000000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff000000000000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffff0000ffbf)
INSERT INTO [browse].[Table](Id,[NameFunction],[SelectFunction],[DefaultOrder],[Title],[Description],[Role]) VALUES 
(1,'sys.SchemaName','browse.SchemaSelect','','','',0)
(2,'sys.TableName','browse.TableSelect','','','',0)
(9,'sys.TableName','','','BrowseTable','',0)
(10,'browse.BrowseColumnName','','','BrowseColumn','',0)
(11,'dbo.CustName','dbo.CustSelect','','Customer','',0)
(12,'','','','','',0)
INSERT INTO [browse].[Column](Id,[Position],[Label],[Description],[RefersTo],[Default],[InputCols],[InputFunction],[InputRows],[Style]) VALUES 
(2,0,'','',1,'',0,'',0,0)
(6,0,'','',2,'',0,'',0,0)
(9,0,'','',2,'',0,'',0,0)
(12,0,'','',2,'',0,'',0,0)
(13,0,'','',4,'',0,'',0,0)
(15,0,'','',1,'',0,'',0,0)
(17,0,'','',0,'',150,'',40,0)
(18,0,'','',1,'',0,'',0,0)
(20,0,'','',0,'',150,'',40,0)
(25,0,'','',0,'',0,'',0,0)
(38,0,'','',2,'',0,'',0,0)
(48,0,'','',11,'',0,'',0,0)
INSERT INTO [dbo].[Cust](Id,[FirstName],[LastName],[Age],[Postcode]) VALUES 
(1,'Mary','Poppins',62,'EC4 2NX')
(2,'Clare','Smith',27,'GL3')
(3,'Ron','Jones',0,'')
(4,'Peter','Perfect',0,'')
(5,'George','Washington',0,'')
(6,'Ron','Williams',0,'')
(7,'Adam','Baker',0,'')
(8,'George','Barwood',0,'GL2 4LZ')
INSERT INTO [dbo].[Order](Id,[Cust],[Total]) VALUES 
(51,5,555.27)
(52,2,10.02)
(53,3,20.04)
(54,4,30.06)
(55,5,40.08)
(56,6,50.10)
(57,7,60.12)
(58,1,35.07)
(59,2,45.09)
(60,3,55.11)
(61,4,665.13)
(62,5,20.04)
(63,6,30.06)
(64,7,40.08)
(65,1,15.03)
(66,2,25.05)
(67,3,35.07)
(68,4,45.09)
(69,5,55.11)
(70,6,65.13)
(71,7,75.15)
(72,1,50.10)
(73,2,5.01)
(74,3,15.03)
(75,4,25.05)
(76,5,35.07)
(77,6,45.09)
(78,7,55.11)
(79,1,30.06)
(80,2,40.08)
(81,3,50.10)
(82,4,60.12)
(83,2,70.14)
(84,6,25.05)
(85,7,35.07)
(86,1,10.02)
(87,2,20.04)
(88,3,30.06)
(89,4,40.08)
(90,5,50.10)
(91,6,60.12)
(92,7,70.14)
(93,1,45.09)
(94,2,55.11)
(95,3,10.02)
(96,4,20.04)
(97,5,30.06)
(98,6,40.08)
(99,7,50.10)
(100,1,25.05)
(101,1,99.85)
(102,5,9999.00)
(103,4,111.11)
CREATE INDEX ByRefersTo on [browse].[Column]([RefersTo])
CREATE INDEX ByLastName on [dbo].[Cust]([LastName])
CREATE FUNCTION [sys].[ColName]( table int, colId int ) RETURNS string AS
BEGIN
  IF colId = 0 return 'Id'

  DECLARE result string, i int
  SET i = 1
  FOR result = Name FROM sys.Column WHERE Table = table
  BEGIN
    IF i = colId RETURN result
    SET i = i + 1
  END
  RETURN '?bad colId?'  
END
CREATE FUNCTION [sys].[ColNames]( table int ) RETURNS string AS
BEGIN
  DECLARE result string, col string
  SET result = '(Id'
  FOR col = Name FROM sys.Column where Table = table
    SET result = result | ',' | sys.QuoteName(col)
  RETURN result | ')'
END
CREATE FUNCTION [sys].[Cols]( table int ) RETURNS string AS
BEGIN
  DECLARE col string, list string
  FOR col = sys.QuoteName(Name) | ' ' | sys.TypeName(Type)
  FROM sys.Column WHERE Table = table
    SET list = CASE WHEN  list = '' then col ELSE list | ',' | col END

  RETURN '(' | list | ')'
END
CREATE FUNCTION [sys].[ColValues]( table int ) RETURNS string AS
BEGIN
  DECLARE result string, col string
  SET result = 'Id'
  FOR col = CASE 
    WHEN Type = 2 THEN 'sys.SingleQuote(' | Name | ')'
    ELSE Name
  END
  FROM sys.Column where Table = table
    SET result = result | '|'',''|' | col
  RETURN result
END
CREATE FUNCTION [sys].[Dot]( schema string, name string ) RETURNS string AS
BEGIN
  RETURN sys.QuoteName( schema ) | '.' | sys.QuoteName( name )
END
CREATE FUNCTION [sys].[IndexCols]( index int ) RETURNS string AS
BEGIN
  DECLARE table int, list string, col string

  SET table = Table FROM sys.Index WHERE Id = index

  FOR col = sys.QuoteName(sys.ColName( table, ColId )) FROM sys.IndexCol WHERE Index = index
    SET list = CASE WHEN  list = '' then col ELSE list | ',' | col END

  RETURN '(' | list | ')'
END
CREATE FUNCTION [sys].[IndexName]( index int ) RETURNS string AS
BEGIN
  DECLARE result string
  SET result = sys.QuoteName(Name) FROM sys.Index WHERE Id = index
  RETURN result
END
CREATE FUNCTION [sys].[QuoteName]( s string ) RETURNS string AS
BEGIN
  RETURN '[' | REPLACE( s, ']', ']]' ) | ']'
END
CREATE FUNCTION [sys].[RenameObject]( objtype string, sch string, name string, newsch string, newname string ) 
RETURNS string AS 

BEGIN
  DECLARE s int, ns int
  SET s = Id FROM sys.Schema WHERE Name = sch
  IF s = 0 RETURN sch | ' does not exist'
  SET ns = Id FROM sys.Schema WHERE Name = newsch
  IF ns = 0 RETURN newsch | ' does not exist'
  
  DECLARE oid int
  IF objtype = 'TABLE' SET oid = Id FROM sys.Table WHERE Schema = s AND Name = name AND IsView = 0
  ELSE IF objtype = 'VIEW' SET oid = Id FROM sys.Table WHERE Schema = s AND Name = name AND IsView = 1
  ELSE IF objtype = 'PROCEDURE' SET oid = Id FROM sys.Procedure WHERE Schema = s AND Name = name
  ELSE IF objtype = 'FUNCTION' SET oid = Id FROM sys.Function WHERE Schema = s AND Name = name

  IF oid = 0 RETURN sys.Dot(sch,name)| ' does not exist'

  DECLARE nid int
  IF objtype = 'TABLE' OR objtype = 'VIEW' SET nid = Id FROM sys.Table WHERE Schema = ns AND Name = newname
  ELSE IF objtype = 'PROCEDURE' SET nid = Id FROM sys.Procedure WHERE Schema = ns AND Name = newname
  ELSE IF objtype = 'FUNCTION' SET nid = Id FROM sys.Function WHERE Schema = ns AND Name = newname

  IF nid != 0 RETURN sys.Dot(newsch,newname) | ' already exists'

  IF objtype = 'TABLE' OR objtype = 'VIEW' UPDATE sys.Table SET Schema = ns, Name = newname WHERE Id = oid
  ELSE IF objtype = 'PROCEDURE' UPDATE sys.Procedure SET Schema = ns, Name = newname WHERE Id = oid
  ELSE IF objtype = 'FUNCTION' UPDATE sys.Function SET Schema = ns, Name = newname WHERE Id = oid
 
  RETURN ''
END
CREATE FUNCTION [sys].[SchemaName]( schema int) RETURNS string AS 
BEGIN 
  DECLARE s string
  SET s = Name FROM sys.Schema WHERE Id = schema
  RETURN s
END
CREATE FUNCTION [sys].[SingleQuote]( s string ) RETURNS string AS
BEGIN
  RETURN '''' | REPLACE( s, '''', '''''' ) | ''''
END
CREATE FUNCTION [sys].[TableName]( table int ) returns string as
begin
  DECLARE schema int, name string, result string

  SET schema = Schema, name = Name FROM sys.Table WHERE Id = table

  if name = '' return 'null'

  SET result = sys.Dot( Name, name ) 
  FROM sys.Schema WHERE Id = schema
  
  return result
end
CREATE FUNCTION [sys].[TypeName]( t int ) RETURNS string AS 
BEGIN 
  RETURN CASE 
    WHEN t = 1 THEN 'binary'
    WHEN t = 2 THEN 'string' 
    WHEN t = 3 THEN 'bigint'
    WHEN t = 4 THEN 'double'
    WHEN t = 5 THEN 'int'
    WHEN t = 6 THEN 'float'
    WHEN t = 7 THEN 'smallint'
    WHEN t = 8 THEN 'tinyint'
    WHEN t = 9 THEN 'bool'
    ELSE 'decimal(' | ( t / 16 ) % 64 | ',' | t / 1024 | ')'
  END
END
CREATE FUNCTION [web].[Cookie]( name string ) RETURNS string as
BEGIN
  RETURN ARG( 3, name )
END
CREATE FUNCTION [web].[Form]( name string ) RETURNS string AS
BEGIN
  return ARG( 2, name )
END
CREATE FUNCTION [web].[Path]() RETURNS string AS
BEGIN
  return ARG(0,'')
END
CREATE FUNCTION [web].[Query]( name string ) RETURNS string AS
BEGIN
  return ARG( 1, name )
END
CREATE FUNCTION [htm].[Attr]( s string ) RETURNS string AS
BEGIN
  set s = REPLACE( s, '&', '&amp;' )
  set s = REPLACE( s, '""', '&quot;' )
  RETURN '""' | s | '""'
END
CREATE FUNCTION [htm].[Encode]( s string ) RETURNS string AS
BEGIN
  set s = REPLACE( s,'&', '&amp;' )
  set s = REPLACE( s, '<', '&lt;' )
  RETURN s
END
CREATE FUNCTION [browse].[BrowseColumnName]( k int ) RETURNS string AS 
BEGIN
  DECLARE result string
  SET result = sys.TableName( Table ) | '.' | sys.QuoteName( Name )
  FROM sys.Column WHERE Id = k
  RETURN result
END
CREATE FUNCTION [browse].[ChildSql]( colId int, k int ) RETURNS string AS 
BEGIN 
  /* Returns SQL to display a child table, with hyperlinks where a column refers to another table */

  DECLARE table int SET table = Table FROM sys.Column WHERE Id = colId

  DECLARE result string, col string, colid int, colName string, type int, th string

  FOR colid = Id, col = CASE 
    WHEN Type = 2 THEN 'htm.Encode(' | Name | ')'
    ELSE Name
  END, colName = Name, type = Type
  FROM sys.Column where Table = table AND Id != colId
  ORDER BY browse.ColPos(Id), Id
  BEGIN
    DECLARE ref int, nf string SET ref = 0, nf = ''
    SET ref = RefersTo FROM browse.Column WHERE Id = colid
    IF ref > 0 SET nf = NameFunction FROM browse.Table WHERE Id = ref

    SET result = result | '|''<TD' | CASE WHEN type != 2 THEN ' align=right' ELSE '' END | '>''|'
      | CASE WHEN nf != '' 
        THEN '''<a href=""/ShowRow?t=' | ref | '&k=''|' | col | '|''"">''|' | nf | '(' | col | ')' | '|''</a>''' 
        ELSE col
        END,
        th = th | '<TH>' | colName

  END
  DECLARE kcol string SET kcol = sys.QuoteName(Name) FROM sys.Column WHERE Id = colId
  RETURN 
   'SELECT ''<TABLE><TR><TH>' | th | ''' '

   | 'SELECT ' | '''<TR><TD><a href=""ShowRow?t=' | table | '&k=''| Id | ''"">Show</a> '''
     | result | ' FROM ' | sys.TableName( table ) | ' WHERE ' | kcol | ' = ' | k

   | ' SELECT ''</TABLE>'''
END
CREATE FUNCTION [browse].[ColNames]( table int ) RETURNS string AS
BEGIN

  DECLARE result string, col string
  FOR col = '<a href=""/BrowseColInfo?k=' | Id | '"">' | Name | '</a>' 
    | ' ' | sys.TypeName(Type) /* | ' pos=' | browse.ColPos(Id) */
  FROM sys.Column where Table = table
  ORDER BY browse.ColPos(Id), Id
    SET result = 
      CASE WHEN result = '' THEN '' ELSE result | ', ' END
      | col
  RETURN result

END
CREATE FUNCTION [browse].[ColPos]( c int ) RETURNS int AS
BEGIN
  DECLARE pos int
  SET pos = Position FROM browse.Column WHERE Id = c
  RETURN pos
END
CREATE FUNCTION [browse].[ColValues]( table int ) RETURNS string AS
BEGIN
  DECLARE result string, col string, colid int
  FOR colid = Id, col = CASE 
    WHEN Type = 2 THEN 'htm.Encode(sys.SingleQuote(' | Name | '))'
    ELSE Name
  END
  FROM sys.Column where Table = table 
  ORDER BY browse.ColPos(Id), Id
  BEGIN
    DECLARE ref int, nf string
    SET ref = 0, nf = '' SET ref = RefersTo FROM browse.Column WHERE Id = colid
    IF ref > 0 SET nf = NameFunction FROM browse.Table WHERE Id = ref

    SET result = CASE WHEN result = '' THEN '' ELSE result | '|'',''|' END | 
      CASE WHEN nf != '' 
      THEN '''<a href=""/ShowRow?t=' | ref | '&k=''|' | col | '|''"">''|' | nf | '(' | col | ')' | '|''</a>''' 
      ELSE col
      END

  END
  RETURN result
END
CREATE FUNCTION [browse].[DefaultDefault]( type int, ref int ) RETURNS string AS
BEGIN
  RETURN CASE
    WHEN type = 2 THEN ''''''
    WHEN type = 1 THEN '0x'
    ELSE '0'
    END
END
CREATE FUNCTION [browse].[DefaultInput]( type int ) RETURNS string AS
BEGIN
  RETURN CASE 
  WHEN type = 3 OR type = 5 OR type = 7 OR type = 8 THEN 'browse.InputInt'
  WHEN type = 1 THEN 'browse.InputBinary'
  WHEN type = 4 OR type = 6 THEN 'browse.InputDouble'
  ELSE 'browse.InputString'
  END
END
CREATE FUNCTION [browse].[FormInsertSql]( table int, pc int ) returns string AS
BEGIN
  DECLARE sql string, col string, type int, colId int

  FOR col = Name, type = Type, colId = Id FROM sys.Column 
    WHERE Table = table AND Id != pc
    ORDER BY browse.ColPos(Id), Id
  BEGIN
    DECLARE ref int, inf string, default string
    SET ref = 0, inf = '', default = ''

    SET ref = RefersTo, default = Default FROM browse.Column WHERE Id = colId

    IF ref > 0 SET inf = SelectFunction FROM browse.Table WHERE Id = ref

    IF inf = '' SET inf = browse.DefaultInput( type )
    IF default = '' SET default = browse.DefaultDefault( type, ref )
 
    SET sql = CASE WHEN sql = '' THEN '' ELSE sql | ' | ' END
      | '''<p><label for=""' | col | '"">' | col | '</label>: '' | ' 
      | inf | '(' | colId | ',' | default | ')'

  END
  RETURN 'SELECT ' | sql
END
CREATE FUNCTION [browse].[FormUpdateSql]( table int, k int ) returns string AS
BEGIN
  DECLARE sql string, col string, colId int, type int

  FOR col = Name, colId = Id, type = Type FROM sys.Column WHERE Table = table
  ORDER BY browse.ColPos(Id), Id
  BEGIN
    DECLARE ref int, inf string
    SET ref = 0, inf = ''
    SET ref = RefersTo FROM browse.Column WHERE Id = colId
    IF ref > 0 SET inf = SelectFunction FROM browse.Table WHERE Id = ref

    IF inf = '' SET inf = browse.DefaultInput( type )

    SET sql = sql 
      | CASE WHEN sql = '' THEN '' ELSE ' | ' END
      | '''<p><label for=""' | col | '"">' | col | '</label>: '' | ' 
      | inf | '(' | colId | ',' | sys.QuoteName(col) | ')'
  END

  RETURN 'SELECT ' | sql | ' FROM ' | sys.TableName( table ) | ' WHERE Id =' | k
END
CREATE FUNCTION [browse].[InputBinary]( colId int, value binary ) RETURNS string AS 
BEGIN 
  DECLARE cn string SET cn = Name FROM sys.Column WHERE Id = colId

  DECLARE size int SET size = InputCols FROM browse.Column where Id = colId

  IF size = 0 SET size = 50

  RETURN '<input id=""' | cn | '"" name=""' | cn | '"" size=' | size | ' value=""' | value | '"">'
END
CREATE FUNCTION [browse].[InputDouble]( colId int, value double ) RETURNS string AS 
BEGIN 
  DECLARE cn string SET cn = Name FROM sys.Column WHERE Id = colId

  DECLARE size int 
  SET size = InputCols FROM browse.Column where Id = colId
  IF size = 0 SET size = 15

  RETURN '<input id=""' | cn | '"" name=""' | cn | '"" size=""' | size | '""' | ' value=""' | value | '"">'
END
CREATE FUNCTION [browse].[InputInt]( colId int, value int) RETURNS string AS 
BEGIN 
  DECLARE cn string 
  SET cn = Name FROM sys.Column WHERE Id = colId

  DECLARE size int

  SET size = InputCols FROM browse.Column where Id = colId

  IF size = 0 SET size = 10

  RETURN '<input type=number id=""' | cn | '"" name=""' | cn | '"" size=' | size | ' value=' | value | '>'
END
CREATE FUNCTION [browse].[InputString]( colId int, value string ) RETURNS string AS 
BEGIN 
  DECLARE cn string SET cn = Name FROM sys.Column WHERE Id = colId 

  DECLARE cols int, rows int, description string
  SET cols = InputCols, rows = InputRows, description = Description
  FROM browse.Column where Id = colId

  IF cols = 0 SET cols = 50

  IF rows > 0
    RETURN '<textarea id=""' | cn | '"" name=' | cn | '"" cols=""' | cols | '""' | '"" rows=""' | rows |'""'
      | CASE WHEN value = '' THEN 'placeholder=' | htm.Attr(description) ELSE '' END
      | '"">' | htm.Encode(value) | '</textarea>'
  ELSE
    RETURN '<input id=""' | cn | '"" name=""' | cn | '"" size=""' | cols | '""' | ' value=' | htm.Attr(value) | '>'
END
CREATE FUNCTION [browse].[InsertNames]( table int ) RETURNS string AS
BEGIN
  DECLARE result string, col string
  SET result = ''
  FOR col = Name FROM sys.Column where Table = table
    SET result = 
       CASE WHEN result = '' THEN '' ELSE result + ',' END
       | sys.QuoteName(col)
  RETURN '(' | result | ')'
END
CREATE FUNCTION [browse].[InsertSql]( table int, pc int, p int ) RETURNS string AS
BEGIN
  DECLARE vlist string, f string, type int, colId int

  FOR f = 'web.Form(' | sys.SingleQuote(Name) | ')', type = Type, colId = Id
  FROM sys.Column WHERE Table = table 
  SET vlist = 
    CASE WHEN vlist = '' THEN '' ELSE vlist | ' , ' END | 
    CASE 
    WHEN colId = pc THEN '' | p
    WHEN type = 3 OR type = 5 OR type = 7 OR type = 8 THEN 'PARSEINT(' | f | ')'
    WHEN type = 4 OR type = 6 THEN 'PARSEDOUBLE(' | f | ')'
    WHEN type >= 15 THEN 'PARSEDECIMAL(' | f | ',' | type | ')'
    ELSE f
    END

  RETURN 'INSERT INTO ' | sys.TableName( table ) | browse.InsertNames( table ) | ' VALUES ( ' | vlist | ')'
END
CREATE FUNCTION [browse].[SchemaSelect]( colId int, sel int ) RETURNS string AS
BEGIN
  DECLARE col string SET col = Name from sys.Column WHERE Id = colId

  DECLARE opt string, options string, sels string
  SET sels = web.Form( col )
  IF sels != '' SET sel = PARSEINT( sels )

  FOR opt = '<option ' | CASE WHEN Id = sel THEN ' selected' else '' END 
  | ' value=' | Id | '>' | htm.Encode( Name ) | '</option>'
  FROM sys.Schema
  ORDER BY Name
  SET options = options + opt

  return '<select id=""' | col | '"" name=""' | col | '"">' | options | 
     '<option ' | CASE WHEN sel = 0 THEN ' selected' ELSE '' END | ' value=0></option>'
     | '</select>'
END
CREATE FUNCTION [browse].[ShowSql]( table int, k int ) RETURNS string AS
BEGIN
  DECLARE cols string, col string, colname string, colid int
  FOR colid = Id, colname = Name, col = CASE 
    WHEN Type = 2 THEN 'htm.Encode(' | Name | ')'
    ELSE Name
    END
  FROM sys.Column where Table = table 
  ORDER BY browse.ColPos(Id), Id
  BEGIN
    DECLARE ref int, nf string
    SET ref = 0, nf = ''
    SET ref = RefersTo FROM browse.Column WHERE Id = colid
    IF ref > 0 SET nf = NameFunction FROM browse.Table WHERE Id = ref ELSE SET nf = ''

    SET cols = 
      CASE WHEN cols = '' THEN '' ELSE cols | ' | ' END
      | '''<p>' | colname | ': '' | '
      | CASE 
        WHEN nf != '' THEN '''<a href=""/ShowRow?t=' | ref | '&k=''|' | col | '|''"">''|' | nf | '(' | col | ')' | '|''</a>''' 
        ELSE col
        END
  END

  DECLARE namefunc string SET namefunc = NameFunction FROM browse.Table WHERE Id = table

  RETURN '  
    DECLARE t int SET t = '|table|'
    DECLARE k int SET k = '|k|'
    DECLARE title string SET title = browse.TableTitle( t )' 
      | CASE WHEN namefunc = '' THEN '' ELSE ' | '' '' | ' | namefunc | '(k)' END | '
    EXEC web.Head( title )
    SELECT ''<b>'' | title | ''</b><br>''
  '
  | ' SELECT ' | cols | ' FROM ' | sys.TableName(table) | ' WHERE Id = k'

  | ' SELECT ''<p><a href=""/EditRow?t='' | t | ''&k='' | k | ''"">Edit</a>'''

  | '
  DECLARE col int
  FOR col = Id FROM browse.Column WHERE RefersTo = t
  BEGIN
    SELECT ''<p><b>'' | browse.TableTitle( Table ) | ''</b>''
     | '' <a href=""AddChild?c='' | col | ''&p='' | k | ''"">Add</a>''
    FROM sys.Column WHERE Id = col

    EXECUTE( browse.ChildSql( col, k ) )
  END

  SELECT ''<p><a href=""/ShowTable?k='' | t | ''"">'' | browse.TableTitle(t) | '' Table</a>''

  EXEC web.Trailer()
'
END
CREATE FUNCTION [browse].[TableSelect]( colId int, sel int ) RETURNS string AS
BEGIN
  DECLARE col string SET col = Name from sys.Column WHERE Id = colId

  DECLARE opt string, options string

  FOR opt = '<option ' | CASE WHEN Id = sel THEN ' selected' else '' END 
  | ' value=' | Id | '>' | htm.Encode( sys.TableName(Id) ) | '</option>'
  FROM sys.Table
  ORDER BY sys.TableName(Id)
  SET options = options + opt

  return '<select id=""' | col | '"" name=""' | col | '"">' | options | 
     '<option ' | CASE WHEN sel = 0 THEN ' selected' ELSE '' END | ' value=0></option>'
     | '</select>'
END
CREATE FUNCTION [browse].[TableTitle]( table int ) RETURNS string AS
BEGIN
  DECLARE result string

  SET result = Title FROM browse.Table WHERE Id = table

  IF result = '' SET result = Name FROM sys.Table WHERE Id = table

  RETURN result
END
CREATE FUNCTION [browse].[UpdateSql]( table int, k int ) RETURNS string AS
BEGIN
  DECLARE alist string, col string, type int, colId int

  FOR colId = Id, col = Name, type = Type FROM sys.Column WHERE Table = table
  BEGIN
    DECLARE f string

    SET f = 'web.Form(' | sys.SingleQuote(col) | ')'

    SET alist = CASE WHEN alist = '' THEN '' ELSE alist | ' , ' END
      | sys.QuoteName(col) | ' = ' | 
      CASE 
      WHEN type = 3 OR type = 5 OR type = 7 OR type = 8 
      THEN 'PARSEINT(' | f |')'
      WHEN type = 4 OR type = 6
      THEN 'PARSEDOUBLE(' | f | ')'
      WHEN type >= 15
      THEN 'PARSEDECIMAL(' | f | ',' | type | ')'
      ELSE f
      END
  END

  RETURN 'UPDATE ' | sys.TableName( table ) | ' SET ' + alist | ' WHERE Id =' | k
END
CREATE FUNCTION [dbo].[CustName]( cust int ) returns string as 
BEGIN
  DECLARE result string 
  SET result = 'Cust ' | cust -- default in case Cust row does not exist
  SET result = FirstName | ' ' | LastName FROM dbo.Cust where Id = cust
  RETURN result
END
CREATE FUNCTION [dbo].[CustSelect]( colId int, sel int ) RETURNS string AS
BEGIN
  DECLARE col string SET col = Name FROM sys.Column where Id = colId
  DECLARE opt string, options string

  FOR opt = '<option ' | CASE WHEN Id = sel THEN ' selected' else '' END 
  | ' value=' | Id | '>' | htm.Encode( dbo.CustName(Id) ) | '</option>'
  FROM dbo.Cust
  ORDER BY LastName, FirstName
  SET options = options + opt

  return '<select id=""' | col | '"" name=""' | col | '"">' | options 
    | '<option ' | CASE WHEN sel = 0 THEN ' selected' ELSE '' END | ' value=0></option>'
    | '</select>'
END
CREATE PROCEDURE [sys].[DroppedColumn]( t int, colId int ) AS 
BEGIN 
  /* Called internally during ALTER TABLE */
  DECLARE index int
  WHILE 1 = 1 
  BEGIN
    SET index = 0
    SET index = Index FROM sys.IndexCol WHERE Table = t AND ColId = colId
    IF index = 0 BREAK 
    EXECUTE( 'DROP INDEX ' | sys.IndexName(index) | ' ON ' | sys.TableName(t) )
  END
  UPDATE sys.IndexCol SET ColId = ColId - 1 WHERE Table = t AND ColId >= colId
END
CREATE PROCEDURE [sys].[DropSchema]( schema string ) AS
/* Note: this should not be called directly, instead use DROP SCHEMA statement */
BEGIN
  DECLARE sid int, name string
  SET sid = Id FROM sys.Schema WHERE Name = schema
  FOR name = Name FROM sys.Function WHERE Schema = sid EXECUTE( 'DROP FUNCTION ' | sys.Dot(schema,name) )
  FOR name = Name FROM sys.Procedure WHERE Schema = sid EXECUTE( 'DROP PROCEDURE ' | sys.Dot(schema,name) )
  FOR name = Name FROM sys.Table WHERE Schema = sid AND IsView = 1 EXECUTE( 'DROP VIEW ' | sys.Dot(schema,name) )
  FOR name = Name FROM sys.Table WHERE Schema = sid AND IsView = 0 EXECUTE( 'DROP TABLE ' | sys.Dot(schema,name) )
  DELETE FROM sys.Schema WHERE Id = sid
END
CREATE PROCEDURE [sys].[DropTable]( t int ) AS 
BEGIN
  DELETE FROM browse.Column WHERE Id in ( SELECT Id FROM sys.Column WHERE Table = t )
  DELETE FROM browse.Table WHERE Id = t
  DELETE FROM sys.Column WHERE Table = t
  DELETE FROM sys.Table WHERE Id = t
  DELETE FROM sys.Index WHERE Table = t
  DELETE FROM sys.IndexCol WHERE Table = t
END
CREATE PROCEDURE [sys].[ModifiedColumn]( t int, colIx int ) AS 
BEGIN
  UPDATE sys.Index SET Modified = 1 WHERE Id IN ( SELECT Index FROM sys.IndexCol WHERE Table = t AND ColIx = colix )
END
CREATE PROCEDURE [sys].[RecreateModifiedIndexes]() AS 
BEGIN
  DECLARE table int, name string, cols string

  FOR table = Table, name = Name, cols = sys.IndexCols( Id )
  FROM sys.Index WHERE Modified = 1
  BEGIN
    EXECUTE( 'DROP INDEX ' | name | ' ON ' | sys.TableName( table ) )
    EXECUTE( 'CREATE INDEX ' | name | ' ON ' | sys.TableName( table ) | cols )
  END
END
CREATE PROCEDURE [handler].[/AddChild]() AS
BEGIN
  DECLARE c int SET c = PARSEINT( web.Query('c') )
  DECLARE p int SET p = PARSEINT( web.Query('p') )
  DECLARE t int SET t = Table FROM sys.Column WHERE Id = c
  DECLARE ex string

  IF web.Form( '$submit' ) != '' 
  BEGIN
    EXECUTE( browse.InsertSql( t, c, p ) ) 
    SET ex = EXCEPTION()
    IF ex = '' 
    BEGIN
      EXEC web.Redirect( 'ShowRow?t=' | t | '&k=' | LASTID() )
      RETURN 
    END
  END
 
  DECLARE title string SET title = 'Add ' | browse.TableTitle( t )

  EXEC web.Head( title )
  SELECT '<b>' | title | '</b><br>'

  IF ex != '' SELECT '<p>Error: ' | ex

  SELECT '<form method=post>' 
  EXECUTE( browse.FormInsertSql( t, c ) )
  SELECT '<p><input name=""$submit"" type=submit value=Save></form>'
  EXEC web.Trailer()
    
  EXEC web.Trailer()
END
CREATE PROCEDURE [handler].[/AddRow]() AS 
BEGIN 
  DECLARE t int SET t = PARSEINT( web.Query('t') )
  DECLARE ex string

  IF web.Form( '$submit' ) != '' 
  BEGIN
    DECLARE lastid int
    SET lastid = LASTID()
    EXECUTE( browse.InsertSql( t, 0, 0 ) ) 
    SET ex = EXCEPTION()
    IF ex = '' 
    BEGIN
      EXEC web.Redirect( 'ShowRow?t=' | t | '&k=' | LASTID() )
      RETURN
    END
  END
  
  EXEC web.Head( 'Add ' | browse.TableTitle( t ) )

  IF ex != '' SELECT '<p>Error: ' | ex

  SELECT '<form method=post>' 
  EXECUTE( browse.FormInsertSql( t, 0 ) )
  SELECT '<p><input name=""$submit"" type=submit value=Save></form>'
  EXEC web.Trailer()

END
CREATE PROCEDURE [handler].[/BrowseColInfo]() AS 
BEGIN 
  DECLARE tid int SET tid = 10
  DECLARE c int SET c = PARSEINT( web.Query( 'k' ) )
  DECLARE t int, colName string
  SET t = Table, colName = Name FROM sys.Column WHERE Id = c

  DECLARE ok int SET ok = 0

  SET ok = Id FROM browse.Column where Id = c
  IF ok != c INSERT INTO browse.Column( Id ) VALUES ( c )

  IF web.Form( '$submit' ) != '' 
  BEGIN
    EXECUTE( browse.UpdateSql( tid, c ) ) 
    EXEC web.Redirect( 'ShowTable?k=' | t )
  END
  ELSE
  BEGIN
    EXEC web.Head( 'Column ' | colName )
    SELECT '<h1>Column ' | colName | '</h1><form method=post>' 
    EXECUTE( browse.FormUpdateSql( tid, c ) )
    SELECT '<p><input name=""$submit"" type=submit value=Save></form>'
    EXEC web.Trailer()
  END
END
CREATE PROCEDURE [handler].[/BrowseInfo]() AS 
BEGIN 
  DECLARE k int SET k = PARSEINT( web.Query( 'k' ) )
  DECLARE tid int SET tid = 9

  DECLARE ok int SET ok = 0

  SET ok = Id FROM browse.Table where Id = k
  IF ok != k INSERT INTO browse.Table( Id ) VALUES ( k )

  IF web.Form( '$submit' ) != '' 
  BEGIN
    EXECUTE( browse.UpdateSql( tid, k ) ) 
    EXEC web.Redirect( 'ShowTable?k=' | k )
  END
  ELSE
  BEGIN
    EXEC web.Head( 'Browse Info for ' | sys.TableName(k) )
    SELECT '<form method=post>' 
    EXECUTE( browse.FormUpdateSql( tid, k ) )
    SELECT '<p><input name=""$submit"" type=submit value=Save></form>'
    EXEC web.Trailer()
  END
END
CREATE PROCEDURE [handler].[/Dump]() AS 
BEGIN 

  EXEC web.SetContentType( 'text/plain' )

  DECLARE ins string, val string
  FOR 
    ins = 'INSERT INTO ' | sys.TableName(Id) | sys.ColNames(Id) | ' VALUES 
',
    val = 'SELECT ''(''|' | sys.ColValues(Id) | '|'')
''' | ' FROM ' | sys.TableName(Id)

    | CASE 
      WHEN Id = 1 THEN ' WHERE Id > 1' -- Schema
      WHEN Id = 2 THEN ' WHERE Id > 7' -- Table
      WHEN Id = 3 THEN ' WHERE Id > 20' -- Column
      ELSE ''
      END
  FROM sys.Table WHERE IsView = 0 AND ( Id < 4 OR Id > 7 ) -- Exclude indexes, functions, procedures
  BEGIN
    SELECT ins
    EXECUTE( val )
  END

  SELECT 'CREATE INDEX ' | Name | ' on ' | sys.TableName( Table ) | sys.IndexCols(Id) | '
' FROM sys.Index WHERE Id > 6

  SELECT 'CREATE FUNCTION ' | sys.Dot( sys.SchemaName(Schema),Name) | Definition | '
' FROM sys.Function ORDER BY Schema, Name

  SELECT 'CREATE PROCEDURE ' | sys.Dot( sys.SchemaName(Schema),Name) | Definition | '
' FROM sys.Procedure ORDER BY Schema, Name
END
CREATE PROCEDURE [handler].[/EditFile]() AS
BEGIN
  DECLARE k int SET k = PARSEINT( web.Query('k') )
  DECLARE path string SET path = web.Form('path')

  IF path != '' UPDATE web.File SET Path = path WHERE Id = k

  EXEC web.Head( 'Edit File' )

  SELECT '<h1>Edit File Path</h1>'

  SELECT '<form method=post>Path: <input name=path size=50 value=""' | Path | '"">'
    | '<p><input type=submit value=Save></form>'
  FROM web.File WHERE Id = k

  EXEC web.Trailer()

END
CREATE PROCEDURE [handler].[/EditFunc]() AS
BEGIN
  DECLARE s string SET s = web.Query('s')
  DECLARE n string SET n = web.Query('n')
  DECLARE sid int SET sid = Id FROM sys.Schema WHERE Name = s

  DECLARE def string, ex string
  SET def = web.Form('def')
  IF def != '' 
  BEGIN
    EXECUTE( 'ALTER FUNCTION ' | sys.Dot(s,n) | def )
    SET ex = EXCEPTION()
  END
  ELSE SET def = Definition FROM sys.Function WHERE Schema = sid AND Name = n 

  EXEC web.Head( 'Edit ' | n )

  IF ex != '' SELECT '<p>Error: ' + htm.Encode(ex)

  SELECT 
     '<form method=post>'
     | '<input type=submit value=""ALTER FUNCTION""> <a href=ShowSchema?s=' | s | '>' | s | '</a> . ' | n 
     | '<br><textarea name=def rows=40 cols=150>' | htm.Encode(def) | '</textarea>'
     | '</form>'

  EXEC web.Trailer()
END
CREATE PROCEDURE [handler].[/EditProc]() AS
BEGIN
  DECLARE s string SET s = web.Query('s')
  DECLARE n string SET n = web.Query('n')
  DECLARE sid int SET sid = Id FROM sys.Schema WHERE Name = s

  DECLARE def string, ex string SET def = web.Form('def')

  IF def != '' 
  BEGIN
    EXECUTE( 'ALTER PROCEDURE ' | sys.Dot(s,n) | def )
    SET ex = EXCEPTION()
  END
  ELSE SET def = Definition FROM sys.Procedure WHERE Schema = sid AND Name = n 

  EXEC web.Head( 'Edit ' | n )

  IF ex != '' SELECT 'Error: ' | htm.Encode( ex )

  SELECT 
     '<p><form method=post>'
     | '<input type=submit value=""ALTER PROCEDURE""> <a href=ShowSchema?s=' | s | '>' | s | '</a> . ' | n 
     | CASE WHEN s = 'handler' THEN ' <a href=' | n | '>Go</a>' ELSE '' END
     | '<br><textarea name=def rows=40 cols=150>' | htm.Encode(def) | '</textarea>' 
     | '</form>' 

  EXEC web.Trailer()
END
CREATE PROCEDURE [handler].[/EditRow]() AS 
BEGIN 
  DECLARE t int SET t = PARSEINT( web.Query('t') )
  DECLARE k int SET k = PARSEINT( web.Query('k') )
  DECLARE ex string

  IF web.Form( '$submit' ) != '' 
  BEGIN
    EXECUTE( browse.UpdateSql( t, k ) ) 
    SET ex = EXCEPTION()
    IF ex = '' 
    BEGIN
      EXEC web.Redirect( 'ShowRow?t=' | t | '&k=' | k )
      RETURN
    END
  END
 
  EXEC web.Head( 'Edit ' | browse.TableTitle( t ) )
  IF ex != '' SELECT '<p>Error: ' + htm.Encode(ex)

  SELECT '<form method=post>' 
  EXECUTE( browse.FormUpdateSql( t, k ) )
  SELECT '<p><input name=""$submit"" type=submit value=Save></form>'
  EXEC web.Trailer()
END
CREATE PROCEDURE [handler].[/EditView]() AS
BEGIN
  DECLARE s string SET s = web.Query('s')
  DECLARE n string SET n = web.Query('n')
  DECLARE sid int SET sid = Id FROM sys.Schema WHERE Name = s
  DECLARE def string, ex string
  SET def = web.Form('def')

  IF def != '' 
  BEGIN
    EXECUTE( 'ALTER VIEW ' | sys.Dot(s,n) | ' AS ' | def )
    SET ex = EXCEPTION()
  END
  ELSE SET def = Definition FROM sys.Table WHERE Schema = sid AND Name = n AND IsView = 1

  EXEC web.Head( 'Edit ' | n )

  IF ex != '' SELECT '<p>Error :' + htm.Encode( ex )

  SELECT 
     '<form method=post>'
     | '<input type=submit value=""ALTER VIEW""> <a href=ShowSchema?s=' | s | '>' | s | '</a> .' | n | ' AS '
     | '<br><textarea name=def rows=20 cols=100>' | htm.Encode(def) | '</textarea>'
     | '</form>'
  EXEC web.Trailer()
END
CREATE PROCEDURE [handler].[/Execute]() AS 
BEGIN
  DECLARE sql string SET sql = web.Form('sql')

  EXEC web.Head( 'Execute' )

  SELECT 
     '<p><form method=post>'
     | 'SQL to <input type=submit value=Execute>'
     | '<br><textarea name=sql rows=20 cols=100' | CASE WHEN sql='' THEN ' placeholder=""Enter SQL here. See Manual for details.""' ELSE '' END | '>' | htm.Encode(sql) | '</textarea>' 
     | '</form>' 

  /* Maybe results should be displayed by special Code which directs ResultSet to display tables as HTML */

  SELECT '<p>Results:<br><textarea rows=10 cols=100>' 
  IF sql != '' 
  BEGIN
    EXECUTE( sql ) 
    DECLARE ex string SET ex = EXCEPTION()
    IF ex != '' SELECT htm.Encode( 'Error : ' | ex ) ELSE SELECT 'ok'
  END
  SELECT '</textarea>'

  SELECT '<p>Example SQL: SELECT ''Hello World'''
     | '<br>CREATE TABLE dbo.Cust( LastName string, Age int )'
     | '<br>CREATE INDEX ByLastName on dbo.Cust(LastName)'
     | '<br>CREATE VIEW dbo.OrderSummary AS SELECT Cust, SUM(Total) as Total, COUNT() as Count FROM dbo.Order GROUP BY Cust'
     | '<br>CREATE PROCEDURE handler.[/MyPage]() AS BEGIN END'


   EXEC web.Trailer()

END
CREATE PROCEDURE [handler].[/FileUpload]() AS
BEGIN
  EXEC web.Head( 'File upload' )

  IF FILEATTR(0,0) = 'file' 
  BEGIN
    SELECT '<p>Filename=' | FILEATTR(0,2) | ' ContentType=' | FILEATTR(0,1)

    DECLARE content binary SET content =  FILECONTENT(0)
    
    INSERT INTO web.File( Path, ContentType, ContentLength, Content )
    VALUES ( '/Uploads/' + FILEATTR(0,2), FILEATTR(0,1), LEN(content), content )
  END

  SELECT '<form method=post enctype=""multipart/form-data""><p><Input name=file type=file><p><input type=submit value=Upload></form>'

  EXEC web.Trailer()
END
CREATE PROCEDURE [handler].[/ListFile]() AS
BEGIN
  EXEC web.Head( 'Files' )
  SELECT '<h1>Files</h1>' 
  SELECT '<p>Path=<a target=_blank href=""' | Path | '"">' | Path | '</a> Type= ' | ContentType 
   | ' Length=' | ContentLength | ' id=' | Id | ' <a href=""/EditFile?k=' | Id | '"">Edit Path</a>'
  FROM web.File
  EXEC web.Trailer()
END
CREATE PROCEDURE [handler].[/Manual]() AS BEGIN

   EXEC web.Head('Manual')

   SELECT '<h1>Manual</h1>'

   SELECT '<p>This manual describes the various SQL statements that are available. Where syntax is described, optional elements are enclosed in square brackets.'

   SELECT '<h2>Schema definition</h2>'

   SELECT '<h3>CREATE SCHEMA</h2>'

   SELECT '<p>CREATE SCHEMA name
   <p>Creates a new schema. Every database object (Table,View,Procedure,Function) has an associated schema. Schemas are used to organise database objects into logical categories.'

   SELECT '<h2>Table definition</h2>'

   SELECT '<h3>CREATE TABLE</h2>'

   SELECT '<p>CREATE TABLE schema.tablename ( Colname1 Coltype1, Colname2 Coltype2, ... )'

   SELECT '<p>Creates a new base table. Every base table is automatically given an Id column, which auto-increments on INSERT ( if no explicit value is supplied).'

   SELECT '<p>The data types are as follows:<ul>
<li>tinyint, smallint, int, bigint : signed integers of size 1, 2, 4 and 8 bytes respectively.
<li>float, double : floating point numbers of size 4 and 8 bytes respectively.
<li>decimal(p,s) : a number with p decimal digits, with s digits after the decimal point. The maximum value of p is 18.
<li>string : a string of unicode characters.
<li>binary : a string of bytes.
<li>bool : boolean ( true or false ).
</ul>

<p>Each data type has a default value : zero for numbers, a zero length string for string and binary, and false for the boolean type. The variable length data types are stored in special system tables, and are encoded so that only one copy of a given string or binary value is stored.'

   SELECT '<h3>ALTER TABLE</h2>'

   SELECT '<p>ALTER TABLE schema.tablename action1, action2 .... '

   SELECT '<p>The actions are as follows:<ul>
<li>ADD Colname Coltype : a new column is added to the table.
<li>RENAME COLUMN Colname TO NewColname : the column is renamed.
<li>MODIFY Colname Coltype : the datatype of an existing column is changed. The only changes allowed are between the different sizes of integers, between float and double, and decimals with the same scale.
<li>DROP Colname : the column is removed from the table.
</ul>'

   SELECT '<h2>Data manipulation statements</h2>'

   SELECT '<h3>INSERT</h3>'

   SELECT '<p>INSERT INTO schema.tablename ( Colname1, Colname2 ... ) VALUES ( Val1, Val2... ) [,] ( Val3, Val4 ...) ...
   <p>The specified values are inserted into the table. The values may be any expressions ( possibly involving local variables or function calls ).

   <p>INSERT INTO schema.tablename ( Colname1, Colname2 ... ) select-expression
   <p>The values specified by the select-expression are inserted into the table.'

   SELECT '<h3>SELECT</h3>'

   SELECT '<p>SELECT expressions FROM source-table [WHERE bool-exp ] [GROUP BY expressions] [ORDER BY expressions]
    <p>A new table is computed, based on the list of expressions and the WHERE, GROUP BY and ORDER BY clauses.
    <p>If the keyword DESC is placed after an ORDER BY expression, the order is reversed ( descending order ).
    <p>The SELECT expressions can be given names using AS.
    <p>source-table can be a named base table, a view or another SELECT enclosed in brackets.
    <p>When used as a stand-alone statement, the results are passed to the code that invoked the batch, and may be displayed to a user or sent to a client for further processing and eventual display. 
   <p>See the web schema for stored procedures that can be used to generate http responses.'

   SELECT '<h3>UPDATE</h3>'

   SELECT '<p>UPDATE schema.tablename SET Colname1 = Exp1, Colname2 = Exp2 .... WHERE bool-exp
   <p>Rows in the table which satisfy the WHERE condition are updated.'

   SELECT '<h3>DELETE</h3>'

   SELECT '<p>DELETE FROM schema.tablename WHERE bool-exp
   <p>Rows in the table which satisfy the WHERE condition are removed.'

   SELECT '<h2>Local variable declaration and assignment statements</h2>'

   SELECT '<h3>DECLARE</h3>'
   SELECT '<p>DECLARE name1 type1, name2 type2 ....
   <p>Local variables are declared with the specified types. Note that the precision makes no difference, tinyint, smallint, int and bigint are all equivalent in this context. The variables are initialised to default values ( but only once, not each time the DECLARE is encountered if there is a loop ).'

   SELECT '<h3>SET</h3>'
   SELECT '<p>SET name1 = exp1, name2 = exp2 .... [ FROM table ] [ WHERE bool-exp ] [ GROUP BY expressions ]
    <p>Local variables are assigned. If the FROM clause is specified, the values are taken from a table row which satisfies the WHERE condition. If there is no such row, the values of the local variables remain unchanged.'

   SELECT '<h3>FOR</h3>'
   SELECT '<p>FOR name1 = exp1, name2 = exp2 .... FROM table [ WHERE bool-exp ] [ GROUP BY expressions ] [ORDER BY expressions] Statement
    <p>Statement is repeatedly executed for each row from the table which satisfies the WHERE condition, with the named local variables being assigned expressions which depend on the rows.'

   SELECT '<h2>Control flow statements</h2>'

   SELECT '<h3>BEGIN .. END</h3>'
   SELECT '<p>BEGIN Statement1 Statement2 ... END
   <p>The statements are executed in order. A BEGIN..END compound statement can be used whenever a single statement is allowed.'

   SELECT '<h3>IF .. THEN ... ELSE ...</h3>'
   SELECT '<p>IF bool-exp THEN Statement1 [ ELSE Statement2 ]
   <p>If bool-exp evaluates to true Statement1 is executed, otherwise Statement2 ( if specified ) is executed.'

   SELECT '<h3>WHILE</h3>'
   SELECT '<p>WHILE bool-exp Statement
   <p>Statement is repeatedly executed as long as bool-exp evaluates to true. See also BREAK.'

   SELECT '<h3>GOTO</h3>'
   SELECT '<p>GOTO label
   <p>Control is transferred to the labelled statement. A label consists of a name followed by a colon (:)'

   SELECT '<h3>BREAK</h3>'
   SELECT '<p>BREAK
   <p>Execution of the enclosing FOR or WHILE loop is terminated.' 

   SELECT '<h2>Batch execution</h2>'
   SELECT '<p>EXECUTE ( string-expression )
   <p>Evaluates the string expression, and then executes the result ( which should be a list of SQL statements ).
   <p>Note that database objects ( tables, views, stored routines ) must be created in a prior batch before being used.'

   SELECT '<h2>Stored Procedures and Functions</h2>'  

   SELECT '<h3>CREATE PROCEDURE</h3>'
   SELECT '<p>CREATE PROCEDURE schema.name ( param1 type1, param2 type2... ) AS BEGIN statements END
   <p>A stored procedure is created, which can later be called by an EXEC statement.'

   SELECT '<h3>EXEC</h3>'
   SELECT '<p>EXEC schema.name( exp1, exp2 ... )
   <p>The stored procedure is called with the supplied parameters.'

   SELECT '<h3>CREATE FUNCTION</h3>'
   SELECT '<p>CREATE FUNCTION schema.name ( param1 type1, param2 type2... ) RETURNS type AS BEGIN statements END
   <p>A stored function is created which can later be used in expressions.'

   SELECT '<h3>RETURN</h3>'
   SELECT 'RETURN expression
   <p>Returns a value from a stored function. RETURN with no expression returns from a stored procedure.'

   SELECT '<h2>Expressions</h2>'
   SELECT '<p>Expressions are composed from literals, named local variables, local parameters and named columns from tables or views. These may be combined using operators, stored functions and pre-defined functions.'

   SELECT '<h3>Literals</h3>'
   SELECT '<p>String literals are written enclosed in single quotes. If a single quote is needed in a string literal, it is written as two single quotes. Binary literals are written in hexadecimal preceded by 0x. Integers are a list of digits (0-9), decimals have a decimal point.'

   SELECT '<h3>Names</h3>' 
   SELECT '<p>Names are enclosed in square brackets and are case sensitive ( although language keywords such as CREATE SELECT are case insensitive, and are written without the square brackets, often in upper case only by convention ). The square brackets can be omitted if the name consists of only letters (A-Z,a-z).'

   SELECT '<h3>Operators</h3>'
   SELECT 'The operators ( all binary, except for - which can be unary ) in order of precedence, high to low, are as follows:<ul>
   <li>*  / % : multiplication, division and remainder (after division) of numbers. Remainder only applies to integers.
   <li>+ - : addition, subtraction of numbers.
   <li>| : concatenation of strings. Other types are automatically converted to strings when an operand of the | operator.
   <li>= != > < >= <= : comparison of any data type.
   <li>IN : tests whether an expression in is in a set. The set may be a list of expressions or a select expression enclosed in brackets.
   <li>AND : boolean operator
   <li>OR : boolean operator
   </ul>
   <p>Brackets can be used where necessary, for example ( a + b ) * c.'

   SELECT '<h3>Pre-defined functions</h3>'
   SELECT '<ul>
   <li>MIN,MAX,SUM,COUNT : these are used in conjunction with GROUP BY to calculate the associated aggregate values. Only aggregates can appear in the SELECT expressions when GROUP BY is used, and if any aggregate function is used, all the expressions must be aggregates. The GROUP BY expressions are included in the result table ( and may be given names using AS ).
   <li>LEN( s string ) : returns the length of s, which must be a string or binary expression.
   <li>SUBSTRING( s string, start int, len int ) : returns the substring of s from start (1-based) length len.
   <li>REPLACE( s string, pat string, sub string ) : returns a copy of s where every occurrence of pat is replaced with sub.
   <li>LASTID() : returns the last Id value allocated by an INSERT statement.
   <li>PARSEINT( s string ) : parses an integer from s.
   <li>PARSEFLOAT( s string ) : parses a floating point number from s.
   <li>PARSEDECIMAL( s string, scale int ) : parses a decimal number from s with the specified scale. The result should be assigned to decimal variable or table column of matching scale.
   <li>EXCEPTION() returns a string with any error that occurred during an EXECUTE statement.
   <li>See the web schema for functions that can be used to access http requests.
   </ul>' 

   SELECT '<h2>Views</h2>'

   SELECT '<h3>CREATE VIEW</h3>'
   SELECT '<p>CREATE VIEW schema.viewname AS SELECT expressions FROM table [WHERE bool-exp ] [GROUP BY expressions]'

   SELECT '<p>Creates a new view. Every expression must have a unique name.'

   SELECT '<h2>Indexes'

   SELECT '<h3>CREATE INDEX</h3>'
   SELECT '<p>CREATE INDEX indexname ON schema.tablename( Colname1, Colname2 ... )'

   SELECT '<p>Creates a new index. Indexes allow efficient access to rows other than by Id values. 
   <p>For example, <br>CREATE INDEX ByCust ON dbo.Order(Cust) 
   <br>creates an index allowing the orders associated with a particular customer to be efficiently retrieved without scanning the entire order table.'

   SELECT '<h2>Rename and Drop</h2>'

   SELECT '<h3>RENAME</h3>'
   SELECT '<p>RENAME object-type object-name TO object-name
   <p>object-type can be any one of SCHEMA,TABLE,VIEW,PROCEDURE or FUNCTION. The name of the specified object is changed.'

   SELECT '<h3>DROP object-type object-name</h3>'
   SELECT '<p>object-type can be any one of SCHEMA,TABLE,VIEW,PROCEDURE or FUNCTION.
   <p>The specified object is removed from the database. In the case of a SCHEMA, all objects in the SCHEMA are also removed. In the case of TABLE, all the rows in the table are also removed.'

   SELECT '<h3>DROP INDEX</h3>'
   SELECT '<p>DROP INDEX indexname ON schema.tablename'
   SELECT '<p>The specified index is removed from the database.'

   SELECT '<h2>Comparison with other SQL implementations</h2>'
   SELECT '<p>There is a single variable length string datatype ""string"" for unicode strings ( equivalent to nvarchar(max) in MSSQL ), no fixed length strings.

   <p>Similarly there is a single binary datatype ""binary"" equivalent to varbinary(max) in MSSQL.
   
   <p>Every table automatically gets an integer Id field ( it doesn''t have to be specified ), which is automatically filled in if not specified in an INSERT statement. Id values must be unique ( an attempt to insert or assign a duplicate Id will raise an exception ). 

   <p>In an aggregate select, only aggregate functions are allowed as expressions, and GROUP BY expressions are added as columns automatically.
   Aggregate functions cannot be arguments. 
   
   <p>PROCEDURE parameters are in brackets, body must have BEGIN ... END.
   
   <p>Local variables cannot be assigned with SELECT, instead SET or FOR is used, can be FROM a table, e.g.
   <p>DECLARE s string SET s = Name FROM sys.Schema WHERE Id = schema

   <p>No cursors ( use FOR instead ).

   <p>Local variables cannot be assigned in a DECLARE statement.
      
   <p>No default schemas. Schema of tables, routines, functions, views etc. must always be stated explicitly.
   
   <p>No nulls. Columns are initialised to default a value if not specified by INSERT, or when new columns are added to a table by ALTER TABLE.
   
   <p>No triggers. No joins. No outer references.' 

   EXEC web.Trailer()

END
CREATE PROCEDURE [handler].[/Menu]() AS
BEGIN
   EXEC web.Head('Menu')

   SELECT '
<p><a href=/OrderSummary>Order Summary</a>
<h1>System</h1>
<p><a href=/Execute>Execute SQL</a>
<p><a href=/ListFile>Files</a>
<p><a href=/FileUpload>File Upload</a>
<p><a target=_blank href=/Dump>Dump</a>
<h1>Schemas</h1>'

   SELECT '<p><a href=ShowSchema?s=' | Name | '>' | Name | '</a>' FROM sys.Schema ORDER BY Name

   EXEC web.Trailer()
END
CREATE PROCEDURE [handler].[/OrderSummary]() AS
BEGIN
  EXEC web.Head( 'Order Summary' )

  SELECT '<table><tr><th>Cust<th>Total<th>#<th>Avg<th>Min<th>Max</tr>'

  SELECT '<tr><td><a href=ShowRow?t=11&k=' | Cust | '>' | dbo.CustName(Cust) | '</a>' 
   | '<td align=right>' | Total
   | '<td align=right>' | Count
   | '<td align=right>' | Total / Count
   | '<td align=right>' | Min
   | '<td align=right>' | Max
   | '</tr>'
  FROM dbo.OrderSummary
  ORDER BY Total / Count DESC

  SELECT '</table>'

  EXEC web.Trailer()
END
CREATE PROCEDURE [handler].[/ShowRow]() AS 
BEGIN
  DECLARE t int SET t = PARSEINT( web.Query('t') )
  DECLARE k int SET k = PARSEINT( web.Query('k') )

  EXECUTE( browse.ShowSql( t, k ) )
END
CREATE PROCEDURE [handler].[/ShowSchema]() AS
BEGIN
  DECLARE s string SET s = web.Query('s')

  DECLARE sid int SET sid = Id FROM sys.Schema WHERE Name = s

  EXEC web.Head( 'Schema ' | s )

  SELECT '<h1>Schema ' | s | '</h1>'

  SELECT '<h2>Tables</h2>'
  SELECT '<p><a href=""ShowTable?k=' | Id | '"">' | Name | '</a>'
  FROM sys.Table WHERE Schema = sid AND IsView = 0 ORDER BY Name

  SELECT '<h2>Views</h2>'
  SELECT '<p><a href=""EditView?s=' | s | '&n=' | Name | '"">' | Name | '</a>'
  FROM sys.Table WHERE Schema = sid AND IsView = 1 ORDER BY Name

  SELECT '<h2>Procedures</h2>' 
  SELECT '<p><a href=""EditProc?s=' | s | '&n=' | Name | '"">' | Name | '</a>'
  FROM sys.Procedure WHERE Schema = sid ORDER BY Name

  SELECT '<h2>Functions</h2>'
  SELECT '<p><a href=""EditFunc?s=' | s | '&n=' | Name | '"">' | Name | '</a>'
  FROM sys.Function WHERE Schema = sid ORDER BY Name

  EXEC web.Trailer()
END
CREATE PROCEDURE [handler].[/ShowTable]() AS 
BEGIN 
  DECLARE t int SET t = PARSEINT( web.Query('k') )
  DECLARE title string SET title = browse.TableTitle( t )
  SET title = title | ' Table'

  EXEC web.Head( title )

  SELECT '<b>' | title | '</b> <a href=/BrowseInfo?k=' | t | '>Settings</a>'   
    | '<p><b>Columns:</b> ' | browse.ColNames( t )

  SELECT '<p><b>Indexes</b>'
  SELECT '<br>' | sys.QuoteName(Name) | ' ' | sys.IndexCols(Id)
  FROM sys.Index WHERE Table = t

  SELECT '<p><b>Rows</b> <a href=""AddRow?t=' | t | '"">Add</a>'
  
  DECLARE orderBy string SET orderBy = DefaultOrder FROM browse.Table WHERE Id = t

  DECLARE sql string SET sql ='SELECT ''<br><a href=""ShowRow?t=' | t | '&k=''| Id |''"">Show</a> ''| ''''|' 
    | browse.ColValues(Id)  
    | ' FROM ' 
    | sys.TableName(Id)
    | CASE WHEN orderBy != '' THEN ' ORDER BY ' | orderBy ELSE '' END
  FROM sys.Table WHERE Id = t

  EXECUTE( sql )

  EXEC web.Trailer()
END
CREATE PROCEDURE [web].[Head]( title string ) AS 
BEGIN 
  EXEC web.SetContentType( 'text/html' )

  SELECT '<html>
<head>
<meta http-equiv=""Content-type"" content=""text/html;charset=UTF-8"">
<link rel=""shortcut icon"" href=""/img/fav.ico""/>
<title>' | title | '</title>
<style>body{font-family:sans-serif;}</style>
</head>
<body>
<div style=""color:white;background:lightblue;padding:4px;"">
<a href=/Menu>Menu</a> 
| <a target=_blank href=/Menu>New Window</a>
| <a href=Manual>Manual</a>
| <a target=_blank href=""EditProc?s=handler&n=' | web.Path() | '"">Code</a>
</div>'
END
CREATE PROCEDURE [web].[Main]() AS 
BEGIN 
  DECLARE path string SET path = web.Path()
  DECLARE ok string SET ok = Name FROM sys.Procedure WHERE Name = path AND Schema = 2
  IF ok = path
  BEGIN
    EXECUTE( 'EXEC ' | sys.Dot('handler',path) | '()' )
    DECLARE ex string
    SET ex = EXCEPTION()
    IF ex != ''
    BEGIN
      EXEC web.Head( 'Error' )
      SELECT '<h1>Error</h1>'
      SELECT htm.Encode( ex )
      SELECT '<p>Use browser back to correct'
      EXEC web.Trailer()
    END
  END
  ELSE
  BEGIN
    DECLARE ct string, content binary
    SET ok = Path, ct = ContentType, content = Content FROM web.File WHERE Path = path
    IF ok = path
    BEGIN
      EXEC web.SendBinary( ct, content )
    END    
    ELSE
    BEGIN
      EXEC web.Head( 'Unknown page')
      SELECT 'Unknown page Path=' | path
      EXEC web.Trailer()
    END
  END
END
CREATE PROCEDURE [web].[Redirect]( url string ) AS
BEGIN
  select 15, url
END
CREATE PROCEDURE [web].[SendBinary]( contenttype string, content binary ) AS
BEGIN
  exec web.SetContentType( contenttype )
  select 11, content
END
CREATE PROCEDURE [web].[SetContentType]( ct string ) AS
BEGIN
  SELECT 10, ct
END
CREATE PROCEDURE [web].[SetCookie]( name string, value string, expires string ) as
BEGIN
  SELECT 16, name, value, expires /* e.g. 01 Jan 2050 */
END
CREATE PROCEDURE [web].[Trailer]() AS
BEGIN
  SELECT '</body></html>'
END
CREATE PROCEDURE [dbo].[MakeOrders]() AS
BEGIN 
  DELETE FROM dbo.Order WHERE 1 = 1
  DECLARE @I int 
  SET @I=0 
  WHILE @I < 50 -- Use 5000000 to stress system a bit!
  BEGIN 
    INSERT INTO dbo.[Order](Cust,Total) Values(1+@I%7, ( 501.00 * (@I%11+@I%7) ) / 100 ) 
    SET @I=@I+1 
  END
END
", null );

  }
}