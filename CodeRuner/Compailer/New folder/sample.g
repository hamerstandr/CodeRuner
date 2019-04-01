grammar sample;

@parser::members 
{
    CodeRuner.Compailer.Scope SymbolTable = new CodeRuner.Compailer.Scope(); //Symbols table of variables
    CodeRuner.tabdil_noe tabdil_noe = new CodeRuner.tabdil_noe();
	public  List<string> khata_parser = new List<string>();
	public string cod= "class Program "+Environment.NewLine+"{ "+Environment.NewLine;
    //public  int andis = 0;
	public void khata_ezaf_kon(string onsor)
    {
        khata_parser.Add( onsor);
    }
    public void khata_pakon()
    {
        khata_parser.Clear();
    }
    public void khata_kam_kon()
    {
        //andis--;
        //khata_parser[andis] = "";
    }
}

STRING : 'string' ;
REAL : 'int' ;
BOOL : 'bool' ;
IF : 'if' ;
TO : 'to' ;
MFOR : 'mfor';
STEP : 'step' ;
THEN : 'then' ;
BEGIN : 'begin' ;
END : 'end' ;
WHILE : 'while' ;
ELSE : 'else' ;
READ : 'read' ;
WRITE: 'write' ;
MODULE : 'fanction' ;
INPUT : 'input' ;
OUTPUT : 'output' ;
RETURN : 'return' ;
TRUE : 'true' ;
FALSE : 'false' ;
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
AND : 'and' ;
OR : 'or' ;
XOR : 'xor' ;
NOT : 'not' ;
LESSER : '<' ;
FOR : 'for';
BIGGER : '>' ;
LESSEREQUAL : '<=' ;
BIGGEREQUAL : '>=' ;
EQUAl : '==';
OPPOSITE : '<>' ;
OPIF : '?' ;
OPDOT : ':' ;
SEPARATOR : ';' ;
ID  :   ([a-zA-Z]|'_')([a-zA-Z]|('0'..'9')|'_')* ;
WS : [ \t\r\n]+ ->skip;
REALCONST :   ('0'..'9')* '.' ('0'..'9')+ ;
INTCONST :   ('0'..'9')+ ;
HEXCONST :   '0' ('x'|'X') ('0'..'9'|'a'..'f'|'A'..'F')+ ;
STRCONST : '"' ~('\r' | '\n' | '"')* '"' ;
COMMENT1 : '%%'  ~('\r' | '\n')* '\r\n'->skip ;
COMMENT2 : '%%%' .*? '%%%' ->skip;
KAMA : ',';

	
prog : (tabe{cod+=Environment.NewLine+$tabe.Csharp;}|tarife_moteghir{cod+=Environment.NewLine+$tarife_moteghir.Csharp+";";})*/*{cod+=Environment.NewLine;}*/ EOF ;

ghias returns [string Csharp=""] : LESSER {$Csharp="<";} 
								 | BIGGER {$Csharp=">";} 
								 | LESSEREQUAL {$Csharp="<=";} 
								 | BIGGEREQUAL {$Csharp="=>";} 
								 | OPPOSITE {$Csharp="!=";}
								 | EQUAl{$Csharp="==";};
meghdar returns [string Type,string Csharp=""]: 
			ID 
			{
				$Csharp=$ID.text;
				//Check Symbol Exists in Symbol Table
				var symbol = SymbolTable.FindSymbol($ID.text);
				if(symbol == null)
				{
				//console.Beep();
				khata_ezaf_kon("Undefined varaiable "+$ID.text);
				$Type="no_type";
					}
				else 
				{
				$Type=symbol.SymbolType;
				//khata_ezaf_kon( "Type of "+symbol.SymbolName+" is : "+symbol.SymbolType);
				//SymbolType
				}
			}
			|INTCONST {$Csharp=$INTCONST.text;$Type="int";}
			| REALCONST {$Csharp=$REALCONST.text;$Type="int";}
			| farakhan 
			{
				$Csharp=$farakhan.Csharp;
				//Check Symbol Exists in Symbol Table
				var symbol = SymbolTable.FindSymbol($farakhan.text);
				if(symbol == null)
				{
				//console.Beep();
				khata_ezaf_kon("\nUndefined function "+$farakhan.text);
				$Type="no_type";
				}
				else 
				{
				$Type=symbol.SymbolType;
				//khata_ezaf_kon( "Type of "+symbol.SymbolName+" is : "+symbol.SymbolType);
				//SymbolType
				}
			}
			//|OPL shart OPR{$Type="bool";}
			|STRCONST {$Csharp=$STRCONST.text;$Type="string";}
			|TRUE {$Csharp=$TRUE.text;$Type="bool";}
			|FALSE {$Csharp=$FALSE.text;$Type="bool";};


wr returns [string Csharp=""] : WRITE OPL ebarat 
	{$Csharp="System.Console.Write("+$ebarat.Csharp+")";} 
	 OPR 
	| READ OPL ID
		{	$Csharp=$ID.text+" = System.Console.Read()";
			//Check Symbol Exists in Symbol Table
			var symbol = SymbolTable.FindSymbol($ID.text.ToLower());
			if(symbol == null)
				{
				//console.Beep();
				khata_ezaf_kon("\nUndefined varaiable "+$ID.text);
				}	 
		}OPR;

entesab returns[string Csharp=""]: ID ASSIGN ebarat 		
		{	
			$Csharp=$ID.text+" = "+$ebarat.Csharp+";";
			//Check Symbol Exists in Symbol Table
			var symbol = SymbolTable.FindSymbol($ID.text.ToLower());
			if(symbol == null)
				{
				//console.Beep();
				khata_ezaf_kon("\nUndefined varaiable "+$ID.text);
				}
			else 
			{
			if (tabdil_noe.tabdil_pazir($ebarat.Type,symbol.SymbolType))
			khata_ezaf_kon( "Assign "+symbol.SymbolType+" to "+$ebarat.Type +" isn't valid");
			//SymbolType
			}
			
		}SEPARATOR ;
scope returns[string Csharp=""] : BEGIN 
								{
								$Csharp+="{";
								SymbolTable.EnterScope();
								} 
							   (sakhtar{$Csharp+=Environment.NewLine+$sakhtar.Csharp;})* 
							   END 
							   {
							   $Csharp+=Environment.NewLine+"}"+Environment.NewLine;
							   SymbolTable.ExitScope();
							   };


ifThenElse returns[string Csharp=""] : IF 
				ebarat
					{
						if (tabdil_noe.tabdil_pazir($ebarat.Type, "bool"))
							{
							khata_ezaf_kon("the condition must have boolean type but have "+$ebarat.Type+" type"); 
							}
					} 
			THEN scope{$Csharp=Environment.NewLine+" if ("+$ebarat.Csharp+") "+Environment.NewLine+$scope.Csharp+Environment.NewLine;}
			(ELSE a=ifThenElse{$Csharp+="else "+$a.Csharp;})*
			( ELSE BEGIN {$Csharp+="else "+Environment.NewLine+"{"+Environment.NewLine;} (sakhtar{$Csharp+=Environment.NewLine+$sakhtar.Csharp;})* END {$Csharp+=Environment.NewLine+"}";})?;
			
while returns [string Csharp=""]: WHILE 
			ebarat 
			{
			$Csharp="while ("+$ebarat.Csharp+")"+Environment.NewLine+"{"+Environment.NewLine;
						if (tabdil_noe.tabdil_pazir($ebarat.Type, "bool"))
							{
							khata_ezaf_kon("the condition must have boolean type but have "+$ebarat.Type+" type"); 
							}
			} 
		BEGIN (sakhtar{$Csharp+=Environment.NewLine+$sakhtar.Csharp;})* END
		{$Csharp+=Environment.NewLine+"}";};
	
forloop returns[string Csharp,string t]:
								FOR{$Csharp+="for (";} 
								(
								a=ID{$t=$a.text;$Csharp+=$a.text+"=0";}|tarife_moteghir{$t=$tarife_moteghir.ID;$Csharp+=$tarife_moteghir.Csharp;}|entesab {$t=$entesab.ID;$Csharp=$entesab.Csharp;}
								)
								{$Csharp+=";";} TO b=ebarat 
								{
									$Csharp+=$t +"<"+ $b.Csharp+";"+$t+"++)"+Environment.NewLine;
								}
								THEN BEGIN {$Csharp+=" {";}
								(sakhtar{$Csharp+=$sakhtar.Csharp;})*
								END{$Csharp+=" }";};
forsteploop returns[string Csharp]:
								MFOR{$Csharp+="for (";} 
								(a=ID{$Csharp+=$a.text+"=0";}|tarife_moteghir{$Csharp+=$tarife_moteghir.Csharp;}||entesab {$Csharp=$entesab.Csharp;})
								{$Csharp+=";";} TO b=ebarat 
								{
									$Csharp+=$a.text+">"+ $b.Csharp+";"+$a.text+"--)"+Environment.NewLine;
								}
								THEN BEGIN {$Csharp+=" {";}
								(sakhtar{$Csharp+=$sakhtar.Csharp;})*
								END{$Csharp+=" }";};

noe returns [string Type,string Csharp] 
							: STRING {$Csharp="string";$Type = "string"; }
							| REAL {$Csharp="int";$Type = "int"; }
							| BOOL {$Csharp="bool";$Type = "bool"; };
							
tarife_moteghir returns [string Csharp=""]: 
										ID OPDOT noe SEPARATOR 
										{
										$Csharp+=$noe.Csharp+" "+$ID.text;
										if (SymbolTable.FindInScope($ID.text.ToLower(),"varaiable"))
											SymbolTable.AddSymbol($ID.text.ToLower(),$noe.Type);
										} ;

farakhan returns [string Type,string text,string Csharp=""] : 
									ID{$Csharp+=$ID.text+"(";} 
									OPL (ebarat{$Csharp+=$ebarat.Csharp;} 
									( KAMA ebarat{$Csharp+=","+$ebarat.Csharp;})*)?
									{{$Csharp+=")";}} OPR  
									{
									var symbol = SymbolTable.FindSymbol($ID.text);
									if(symbol == null){khata_ezaf_kon( "\nUndefined function "+$ID.text);$Type="no_type";}
									else {
										khata_ezaf_kon( "Type of "+symbol.SymbolName+" is : "+symbol.SymbolType+" ");
										$Type=symbol.SymbolType;
										$text=$ID.text;
										 }
									};

sakhtar returns [string Type="void",string Csharp=""]:   
					(entesab {$Csharp=$entesab.Csharp;}
					| RETURN ebarat SEPARATOR
											 {
												$Csharp="return "+$ebarat.Csharp+";";
												if($Type=="void")$Type=$ebarat.Type;
											 }
					| ifThenElse {$Csharp=$ifThenElse.Csharp;}
					| while {$Csharp=$while.Csharp;}
					| farakhan SEPARATOR {$Csharp=$farakhan.Csharp+";";}
					| wr SEPARATOR {$Csharp=$wr.Csharp+";";}
					| tarife_moteghir {$Csharp=$tarife_moteghir.Csharp+";";}
					| forloop {$Csharp=$forloop.Csharp;}
					| forsteploop {$Csharp=$forsteploop.Csharp;}
					|scope{$Csharp=$scope.Csharp;});//======== 

tabe returns [string Type="void",string Csharp="",string A="void",string B="",string C="",string D=""]
					: MODULE ID 
					{$B=$ID.text.ToLower();
					if (SymbolTable.FindInScope($ID.text.ToLower(),"function"))
					/*SymbolTable.AddSymbol($ID.text.ToLower(),"function");*/
					SymbolTable.EnterScope();
					}
					(INPUT OPDOT (tarife_moteghir{$C+=$tarife_moteghir.Csharp+",";})+)? 
					(OUTPUT OPDOT noe SEPARATOR{$A=$noe.Csharp;$Type=$noe.Type;})?  
					BEGIN {SymbolTable.EnterScope();SymbolTable.AddSymbol($ID.text.ToLower(),$Type);} 
					(sakhtar{
							$D+=Environment.NewLine+$sakhtar.Csharp;
							if($Type!=$sakhtar.Type)
								{
								if($Type=="void"){khata_ezaf_kon("void function can't return something ");}
								else if(tabdil_noe.tabdil_pazir($Type,$sakhtar.Type))
								khata_ezaf_kon("the function must return "+$Type+" but returned "+$sakhtar.Type);
								}
							}) *
					END 
					{
					//s=s.Remove(s.Length-1);
					if($C.Length!=0)$C=$C.Remove($C.Length-1);
					if($B=="main")$Csharp="static "+$A+" "+"Main"+"("+$C+")"+Environment.NewLine+"{"+$D+Environment.NewLine+"}"+Environment.NewLine;
					else $Csharp=$A+" "+$B+"("+$C+")"+Environment.NewLine+"{"+$D+Environment.NewLine+"}"+Environment.NewLine;
					Console.Write("@@@ "+$Csharp+" @@@");
					SymbolTable.ExitScope();SymbolTable.ExitScope();
					SymbolTable.AddSymbol($ID.text.ToLower(),$Type);
					};

//aemal : PLUS | MINUS | MULTIPLIE | DIVIDE | PERCENT | POWER | AND | OR | XOR ;

ebarat returns [string Type,string Csharp] 
									:a=ebarat  PLUS b=ebarat {$Csharp+=$a.Csharp+" + "+$b.Csharp;$Type = tabdil_noe.karan_bala($a.Type,$b.Type);} 
									|a= ebarat MINUS b= ebarat {$Csharp+=$a.Csharp+" - "+$b.Csharp;if(!tabdil_noe.tabdil_pazir($a.Type,"int")&!tabdil_noe.tabdil_pazir($b.Type,"int")){$Type="int";}
																else {khata_ezaf_kon("subtraction  not compare with "+$a.Type+" and "+$b.Type);$Type="no_type";}} 
																					
									|a=ebarat MULTIPLIE b=ebarat{$Csharp+=$a.Csharp+" * "+$b.Csharp;if(!tabdil_noe.tabdil_pazir($a.Type,"int")&!tabdil_noe.tabdil_pazir($b.Type,"int")){$Type="int";}
																 else {khata_ezaf_kon("multiply  not compare with "+$a.Type+" and "+$b.Type);$Type="no_type";}} 
																					 
									|a=ebarat DIVIDE b=ebarat {$Csharp+=$a.Csharp+@" \ "+$b.Csharp;if(!tabdil_noe.tabdil_pazir($a.Type,"int")&!tabdil_noe.tabdil_pazir($b.Type,"int")){$Type="int";}
																 else {khata_ezaf_kon("subtraction  not compare with "+$a.Type+" and "+$b.Type);$Type="no_type";}}
																			   
									|OPL a=ebarat OPR{$Csharp="("+$a.Csharp+")";$Type=$a.Type;}
									|a=ebarat POWER b=ebarat{$Csharp+=$a.Csharp+" ^ "+$b.Csharp;if(!tabdil_noe.tabdil_pazir($a.Type,"int")&!tabdil_noe.tabdil_pazir($b.Type,"int"))$Type="int";
															   else {khata_ezaf_kon("power  not compare with "+$a.Type+" and "+$b.Type);$Type="no_type";}}
									|a=ebarat AND b=ebarat 
										{	
											$Csharp+=$a.Csharp+" & "+$b.Csharp;
											if(tabdil_noe.tabdil_pazir($a.Type,"bool"))
											{
											khata_ezaf_kon("AND operator can't use for "+$a.Type+" type");
											$Type="no_type";
											}
											if(tabdil_noe.tabdil_pazir($b.Type,"bool" ))
											{
											khata_ezaf_kon("AND operator can't use for "+$b.Type+" type");
											$Type="no_type";
											}
										}
																			 
									|a=ebarat OR b=ebarat 
										{
											$Csharp+=$a.Csharp+" | "+$b.Csharp;
											if(tabdil_noe.tabdil_pazir($a.Type,"bool"))
											{
											
											khata_ezaf_kon("OR operator can't use for "+$a.Type+" type");
											$Type="no_type";
											}
											if(tabdil_noe.tabdil_pazir($b.Type,"bool" ))
											{
											khata_ezaf_kon("OR operator can't use for "+$b.Type+" type");
											$Type="no_type";
											}
										}
									|a=ebarat ghias b=ebarat
																			|a=ebarat OR b=ebarat 
										{
											$Csharp+=$a.Csharp+$ghias.Csharp+$b.Csharp;
											if(tabdil_noe.tabdil_pazir($a.Type,"bool")|tabdil_noe.tabdil_pazir($b.Type,"bool"))
											{
											
											khata_ezaf_kon("can not compare between "+$a.Type+" and "+$b.Type);
											$Type="no_type";
											}
										}
									|meghdar {
												$Csharp=$meghdar.Csharp;
												$Type=$meghdar.Type;
											 };
