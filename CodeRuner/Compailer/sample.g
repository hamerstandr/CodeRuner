grammar sample;

@parser::members 
{
    public CodeRuner.Compailer.Scope SymbolTable = new CodeRuner.Compailer.Scope();
    public CodeRuner.tabdil_noe typeConverter = new CodeRuner.tabdil_noe();
public List<string> khata_parser = new List<string>();
public string cod = "class Program " + Environment.NewLine + "{ " + Environment.NewLine;
    public int errorCount = 0;
    
public void khata_ezaf_kon(string onsor)
    {
        if (!string.IsNullOrEmpty(onsor) && !khata_parser.Contains(onsor))
        {
            khata_parser.Add(onsor);
            errorCount++;
        }
    }
    
    public void khata_pakon()
    {
        khata_parser.Clear();
        errorCount = 0;
    }
}

// Keywords
STRING : 'String' ;
INT : 'Int' ;
BOOL : 'Bool' ;
DOUBLE : 'Double';
BYTE : 'Byte';
IF : 'If' ;
TO : 'To' ;
FOR : 'For';
MFOR : 'Mfor';
STEP : 'Step' ;
THEN : 'Then' ;
BEGIN : 'Begin' ;
END : 'End' ;
WHILE : 'While' ;
ELSE : 'Else' ;
READ : 'Read' ;
READLINE : 'ReadLine' ;
WRITE: 'Write' ;
MODULE : 'Fanction' ;
INPUT : 'Input' ;
OUTPUT : 'Output' ;
RETURN : 'Return' ;
TRUE : 'True' ;
FALSE : 'False' ;
PLUS  : '+' ;
OPL  : '(' ;
OPR  : ')' ;
MINUS : '-' ;
MULTIPLIE : '*' ;
DIVIDE : '/' ;
ASSIGN : '=' ;
PERCENT : '%' ;
FACTORIAL : '!' ;
POWER : '^' ;
AND : 'And' ;
OR : 'Or' ;
XOR : 'Xor' ;
NOT : 'Not' ;
LESSER : '<' ;
BIGGER : '>' ;
LESSEREQUAL : '<=' ;
BIGGEREQUAL : '>=' ;
EQUAL : '==';
OPPOSITE : '<>' ;
OPDOT : ':';
SEPARATOR : ';';
KAMA : ',';

// Literals and Identifiers
ID  :   ([a-zA-Z]|'_')([a-zA-Z0-9]|'_')* ;
WS : [ \t\r\n]+ ->skip;
REALCONST :   ('0'..'9')* '.' ('0'..'9')+ ;
INTCONST :   ('0'..'9')+ ;
HEXCONST :   '0' ('x'|'X') ('0'..'9'|'a'..'f'|'A'..'F')+ ;
STRCONST : '"' ~('\r' | '\n' | '"')* '"' ;
COMMENT1 : '%%'  ~('\r' | '\n')* ('\r\n'|'\n') ->skip ;
COMMENT2 : '%%%' .*? '%%%' ->skip;

// Program structure
prog : (tabe | tarife_moteghir | sakhtar)* EOF ;

// Comparison operators
ghias returns [string Csharp=""] 
    : LESSER {$Csharp="<";} 
    | BIGGER {$Csharp=">";} 
    | LESSEREQUAL {$Csharp="<=";} 
    | BIGGEREQUAL {$Csharp=">=";} 
    | OPPOSITE {$Csharp="!=";}
    | EQUAL {$Csharp="==";};

// Values
meghdar returns [string Type="", string Csharp=""]
    : ID 
      {
          $Csharp = $ID.text;
          var symbol = SymbolTable.FindSymbol($ID.text.ToLower());
          if(symbol == null)
          {
              khata_ezaf_kon("Undefined variable: " + $ID.text);
              $Type = "no_type";
          }
          else 
          {
              $Type = symbol.SymbolType;
          }
      }
    | INTCONST {$Csharp = $INTCONST.text; $Type = "int";}
    | REALCONST {$Csharp = $REALCONST.text; $Type = "double";}
    | STRCONST {$Csharp = $STRCONST.text; $Type = "string";}
    | TRUE {$Csharp = "true"; $Type = "bool";}
    | FALSE {$Csharp = "false"; $Type = "bool";}
    | farakhan;

// Output/Input statements
wr returns [string Csharp=""] 
    : WRITE OPL ebarat OPR {$Csharp = "System.Console.Write(" + $ebarat.Csharp + ")";} 
    | READ OPL ID OPR
      {
          $Csharp = $ID.text + " = System.Console.Read()";
          var symbol = SymbolTable.FindSymbol($ID.text.ToLower());
          if(symbol == null)
              khata_ezaf_kon("Undefined variable: " + $ID.text);
      }
    | READLINE OPL ID OPR
      {
          $Csharp = $ID.text + " = System.Console.ReadLine()";
          var symbol = SymbolTable.FindSymbol($ID.text.ToLower());
          if(symbol == null)
              khata_ezaf_kon("Undefined variable: " + $ID.text);
      }
    | READ OPL OPR {$Csharp = "System.Console.Read()";};

// Assignment
entesab returns[string Csharp=""]
    : ID ASSIGN ebarat SEPARATOR 
      {
          $Csharp = $ID.text + " = " + $ebarat.Csharp + ";";
          var symbol = SymbolTable.FindSymbol($ID.text.ToLower());
          if(symbol == null)
              khata_ezaf_kon("Undefined variable: " + $ID.text);
          else if (typeConverter.bareCnoe($ebarat.Type, symbol.SymbolType))
              khata_ezaf_kon("Cannot assign " + $ebarat.Type + " to " + symbol.SymbolType);
      };

// Scope block
scope returns[string Csharp=""] 
    : BEGIN 
      {
          $Csharp += "{";
          SymbolTable.EnterScope();
      } 
      (sakhtar{$Csharp += Environment.NewLine + $sakhtar.Csharp;})* 
      END 
      {
          $Csharp += Environment.NewLine + "}";
          SymbolTable.ExitScope();
      };

// If-Then-Else
ifThenElse returns[string Csharp=""] 
    : IF ebarat THEN scope
      {
          if ($ebarat.Type != "bool")
              khata_ezaf_kon("Condition must be boolean but has " + $ebarat.Type);
          $Csharp = "if (" + $ebarat.Csharp + ")" + Environment.NewLine + $scope.Csharp;
      }
      (ELSE ifThenElse{$Csharp += "else " + $ifThenElse.Csharp;})*
      ( ELSE BEGIN {$Csharp += "else" + Environment.NewLine + "{";} 
        (sakhtar{$Csharp += Environment.NewLine + $sakhtar.Csharp;})* 
        END {$Csharp += Environment.NewLine + "}";})?;

// While loop
while returns [string Csharp=""]
    : WHILE ebarat BEGIN 
      {
          if ($ebarat.Type != "bool")
              khata_ezaf_kon("Condition must be boolean but has " + $ebarat.Type);
          $Csharp = "while (" + $ebarat.Csharp + ")" + Environment.NewLine + "{";
      } 
      (sakhtar{$Csharp += Environment.NewLine + $sakhtar.Csharp;})* 
      END {$Csharp += Environment.NewLine + "}";};

// For loop (ascending)
forloop returns[string Csharp=""]
    : FOR ID ASSIGN ebarat TO ebarat THEN BEGIN 
      {
          string counter = $ID.text;
          $Csharp = "for (" + counter + " = " + $ebarat.Csharp + "; " + counter + " <= " + $ebarat.Csharp + "; " + counter + "++)" + Environment.NewLine + "{";
      }
      (sakhtar{$Csharp += Environment.NewLine + $sakhtar.Csharp;})*
      END{$Csharp += Environment.NewLine + "}";};

// For loop (descending)
forsteploop returns[string Csharp=""]
    : MFOR ID ASSIGN ebarat TO ebarat THEN BEGIN 
      {
          string counter = $ID.text;
          $Csharp = "for (" + counter + " = " + $ebarat.Csharp + "; " + counter + " >= " + $ebarat.Csharp + "; " + counter + "--)" + Environment.NewLine + "{";
      }
      (sakhtar{$Csharp += Environment.NewLine + $sakhtar.Csharp;})*
      END{$Csharp += Environment.NewLine + "}";};

// Type declaration
noe returns [string Type="", string Csharp=""] 
    : STRING {$Csharp="string"; $Type = "string";}
    | INT {$Csharp="int"; $Type = "int";}
    | BOOL {$Csharp="bool"; $Type = "bool";}
    | DOUBLE {$Csharp="double"; $Type = "double";}
    | BYTE {$Csharp="byte"; $Type = "byte"};

// Variable declaration
tarife_moteghir returns [string Csharp="", string id=""]
    : ID OPDOT noe SEPARATOR 
      {
          $id = $ID.text.ToLower();
          $Csharp = $noe.Csharp + " " + $ID.text;
          if (!SymbolTable.FindInScope($id, "variable"))
              khata_ezaf_kon("Variable redefinition: " + $ID.text);
          else
              SymbolTable.AddSymbol($id, $noe.Type);
      };

// Function call
farakhan returns [string Type="void", string text="", string Csharp=""]
    : ID OPL (ebarat (KAMA ebarat)*)? OPR  
      {
          $Csharp = $ID.text + "(...)";
          var symbol = SymbolTable.FindSymbol($ID.text.ToLower());
          if(symbol == null){
              khata_ezaf_kon("Undefined function: " + $ID.text);
              $Type = "no_type";
          }
          else {
              $Type = symbol.SymbolType;
              $text = $ID.text;
          }
      };

// Statements
sakhtar returns [string Type="void", string Csharp=""]
    : entesab {$Csharp = $entesab.Csharp;}
    | RETURN ebarat SEPARATOR {$Csharp = "return " + $ebarat.Csharp + ";"; $Type = $ebarat.Type;}
    | ifThenElse {$Csharp = $ifThenElse.Csharp;}
    | while {$Csharp = $while.Csharp;}
    | farakhan SEPARATOR {$Csharp = $farakhan.Csharp + ";";}
    | wr SEPARATOR {$Csharp = $wr.Csharp + ";";}
    | tarife_moteghir {$Csharp = $tarife_moteghir.Csharp + ";";}
    | forloop {$Csharp = $forloop.Csharp;}
    | forsteploop {$Csharp = $forsteploop.Csharp;}
    | scope {$Csharp = $scope.Csharp;};

// Function definition
tabe returns [string Type="void", string Csharp="", string name="", string paramsStr="", string body=""]
    : MODULE ID 
      {
          $name = $ID.text.ToLower();
          if (!SymbolTable.FindInScope($name, "function"))
              khata_ezaf_kon("Function redefinition: " + $ID.text);
          SymbolTable.EnterScope();
      }
      (INPUT OPDOT (tarife_moteghir{$paramsStr += $tarife_moteghir.Csharp + ", ";})+)? 
      (OUTPUT OPDOT noe SEPARATOR{$Type = $noe.Type;})?  
      BEGIN 
      {
          SymbolTable.EnterScope();
          SymbolTable.AddSymbol($name, $Type);
          string returnType = string.IsNullOrEmpty($Type) || $Type == "void" ? "void" : $Type;
          string methodName = $name == "main" ? "Main" : $name;
          string parameters = $paramsStr.Length > 0 ? $paramsStr.TrimEnd(',', ' ') : "";
          $Csharp = ($name == "main" ? "static " : "") + returnType + " " + methodName + "(" + parameters + ")" + Environment.NewLine + "{";
      } 
      (sakhtar{
          $body += Environment.NewLine + $sakhtar.Csharp;
          if($Type != "void" && $Type != $sakhtar.Type && $sakhtar.Type != "void")
              khata_ezaf_kon("Function must return " + $Type + " but returned " + $sakhtar.Type);
      })*
      END 
      {
          $Csharp += $body + Environment.NewLine + "}";
          SymbolTable.ExitScope();
          SymbolTable.ExitScope();
          if ($name != "main")
              SymbolTable.AddSymbol($name, $Type);
      };

// Expressions with proper precedence
ebarat returns [string Type="void", string Csharp=""]
    : a=ebarat OR b=ebarat 
      {
          $Csharp = $a.Csharp + " || " + $b.Csharp;
          if($a.Type != "bool" || $b.Type != "bool")
              khata_ezaf_kon("OR operator requires boolean operands");
          $Type = "bool";
      }
    | a=ebarat AND b=ebarat 
      {
          $Csharp = $a.Csharp + " && " + $b.Csharp;
          if($a.Type != "bool" || $b.Type != "bool")
              khata_ezaf_kon("AND operator requires boolean operands");
          $Type = "bool";
      }
    | a=ebarat ghias b=ebarat
      {
          $Csharp = $a.Csharp + $ghias.Csharp + $b.Csharp;
          $Type = "bool";
      }
    | a=ebarat PLUS b=ebarat 
      {
          $Csharp = $a.Csharp + " + " + $b.Csharp;
          $Type = typeConverter.karan_bala($a.Type, $b.Type);
      }
    | a=ebarat MINUS b=ebarat 
      {
          $Csharp = $a.Csharp + " - " + $b.Csharp;
          $Type = typeConverter.karan_bala($a.Type, $b.Type);
      }
    | a=ebarat MULTIPLIE b=ebarat
      {
          $Csharp = $a.Csharp + " * " + $b.Csharp;
          $Type = typeConverter.karan_bala($a.Type, $b.Type);
      }
    | a=ebarat DIVIDE b=ebarat 
      {
          $Csharp = $a.Csharp + " / " + $b.Csharp;
          $Type = typeConverter.karan_bala($a.Type, $b.Type);
      }
    | a=ebarat POWER b=ebarat
      {
          $Csharp = "Math.Pow(" + $a.Csharp + ", " + $b.Csharp + ")";
          $Type = "double";
      }
    | OPL a=ebarat OPR
      {
          $Csharp = "(" + $a.Csharp + ")";
          $Type = $a.Type;
      }
    | NOT a=ebarat
      {
          $Csharp = "!" + $a.Csharp;
          if($a.Type != "bool")
              khata_ezaf_kon("NOT operator requires boolean operand");
          $Type = "bool";
      }
    | meghdar {$Csharp = $meghdar.Csharp; $Type = $meghdar.Type;};
