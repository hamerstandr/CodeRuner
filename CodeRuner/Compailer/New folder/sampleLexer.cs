//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from sample.g by ANTLR 4.5.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.1")]
[System.CLSCompliant(false)]
public partial class sampleLexer : Lexer {
	public const int
		STRING=1, REAL=2, BOOL=3, IF=4, TO=5, MFOR=6, STEP=7, THEN=8, BEGIN=9, 
		END=10, WHILE=11, ELSE=12, READ=13, WRITE=14, MODULE=15, INPUT=16, OUTPUT=17, 
		RETURN=18, TRUE=19, FALSE=20, PLUS=21, OPL=22, OPR=23, MINUS=24, MULTIPLIE=25, 
		DIVIDE=26, ASSIGN=27, PERCENT=28, FACTORIAL=29, POWER=30, AND=31, OR=32, 
		XOR=33, NOT=34, LESSER=35, FOR=36, BIGGER=37, LESSEREQUAL=38, BIGGEREQUAL=39, 
		EQUAl=40, OPPOSITE=41, OPIF=42, OPDOT=43, SEPARATOR=44, ID=45, WS=46, 
		REALCONST=47, INTCONST=48, HEXCONST=49, STRCONST=50, COMMENT1=51, COMMENT2=52, 
		KAMA=53;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"STRING", "REAL", "BOOL", "IF", "TO", "MFOR", "STEP", "THEN", "BEGIN", 
		"END", "WHILE", "ELSE", "READ", "WRITE", "MODULE", "INPUT", "OUTPUT", 
		"RETURN", "TRUE", "FALSE", "PLUS", "OPL", "OPR", "MINUS", "MULTIPLIE", 
		"DIVIDE", "ASSIGN", "PERCENT", "FACTORIAL", "POWER", "AND", "OR", "XOR", 
		"NOT", "LESSER", "FOR", "BIGGER", "LESSEREQUAL", "BIGGEREQUAL", "EQUAl", 
		"OPPOSITE", "OPIF", "OPDOT", "SEPARATOR", "ID", "WS", "REALCONST", "INTCONST", 
		"HEXCONST", "STRCONST", "COMMENT1", "COMMENT2", "KAMA"
	};


	public sampleLexer(ICharStream input)
		: base(input)
	{
		Interpreter = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "'string'", "'int'", "'bool'", "'if'", "'to'", "'mfor'", "'step'", 
		"'then'", "'begin'", "'end'", "'while'", "'else'", "'read'", "'write'", 
		"'fanction'", "'input'", "'output'", "'return'", "'true'", "'false'", 
		"'+'", "'('", "')'", "'-'", "'*'", "'/'", "'='", "'%'", "'!'", "'^'", 
		"'and'", "'or'", "'xor'", "'not'", "'<'", "'for'", "'>'", "'<='", "'>='", 
		"'=='", "'<>'", "'?'", "':'", "';'", null, null, null, null, null, null, 
		null, null, "','"
	};
	private static readonly string[] _SymbolicNames = {
		null, "STRING", "REAL", "BOOL", "IF", "TO", "MFOR", "STEP", "THEN", "BEGIN", 
		"END", "WHILE", "ELSE", "READ", "WRITE", "MODULE", "INPUT", "OUTPUT", 
		"RETURN", "TRUE", "FALSE", "PLUS", "OPL", "OPR", "MINUS", "MULTIPLIE", 
		"DIVIDE", "ASSIGN", "PERCENT", "FACTORIAL", "POWER", "AND", "OR", "XOR", 
		"NOT", "LESSER", "FOR", "BIGGER", "LESSEREQUAL", "BIGGEREQUAL", "EQUAl", 
		"OPPOSITE", "OPIF", "OPDOT", "SEPARATOR", "ID", "WS", "REALCONST", "INTCONST", 
		"HEXCONST", "STRCONST", "COMMENT1", "COMMENT2", "KAMA"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "sample.g"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\x430\xD6D1\x8206\xAD2D\x4417\xAEF1\x8D80\xAADD\x2\x37\x168\b\x1\x4"+
		"\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b"+
		"\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4"+
		"\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15"+
		"\t\x15\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A"+
		"\x4\x1B\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 "+
		"\t \x4!\t!\x4\"\t\"\x4#\t#\x4$\t$\x4%\t%\x4&\t&\x4\'\t\'\x4(\t(\x4)\t"+
		")\x4*\t*\x4+\t+\x4,\t,\x4-\t-\x4.\t.\x4/\t/\x4\x30\t\x30\x4\x31\t\x31"+
		"\x4\x32\t\x32\x4\x33\t\x33\x4\x34\t\x34\x4\x35\t\x35\x4\x36\t\x36\x3\x2"+
		"\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3\x4\x3"+
		"\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x5\x3\x6\x3\x6\x3\x6\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\b\x3\b\x3\b\x3\b\x3\b\x3\t\x3\t\x3\t\x3\t\x3\t\x3\n\x3"+
		"\n\x3\n\x3\n\x3\n\x3\n\x3\v\x3\v\x3\v\x3\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3"+
		"\f\x3\r\x3\r\x3\r\x3\r\x3\r\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE\x3\xF\x3\xF"+
		"\x3\xF\x3\xF\x3\xF\x3\xF\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3"+
		"\x10\x3\x10\x3\x10\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3\x12\x3"+
		"\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x12\x3\x13\x3\x13\x3\x13\x3\x13\x3"+
		"\x13\x3\x13\x3\x13\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14\x3\x15\x3\x15\x3"+
		"\x15\x3\x15\x3\x15\x3\x15\x3\x16\x3\x16\x3\x17\x3\x17\x3\x18\x3\x18\x3"+
		"\x19\x3\x19\x3\x1A\x3\x1A\x3\x1B\x3\x1B\x3\x1C\x3\x1C\x3\x1D\x3\x1D\x3"+
		"\x1E\x3\x1E\x3\x1F\x3\x1F\x3 \x3 \x3 \x3 \x3!\x3!\x3!\x3\"\x3\"\x3\"\x3"+
		"\"\x3#\x3#\x3#\x3#\x3$\x3$\x3%\x3%\x3%\x3%\x3&\x3&\x3\'\x3\'\x3\'\x3("+
		"\x3(\x3(\x3)\x3)\x3)\x3*\x3*\x3*\x3+\x3+\x3,\x3,\x3-\x3-\x3.\x5.\x119"+
		"\n.\x3.\a.\x11C\n.\f.\xE.\x11F\v.\x3/\x6/\x122\n/\r/\xE/\x123\x3/\x3/"+
		"\x3\x30\a\x30\x129\n\x30\f\x30\xE\x30\x12C\v\x30\x3\x30\x3\x30\x6\x30"+
		"\x130\n\x30\r\x30\xE\x30\x131\x3\x31\x6\x31\x135\n\x31\r\x31\xE\x31\x136"+
		"\x3\x32\x3\x32\x3\x32\x6\x32\x13C\n\x32\r\x32\xE\x32\x13D\x3\x33\x3\x33"+
		"\a\x33\x142\n\x33\f\x33\xE\x33\x145\v\x33\x3\x33\x3\x33\x3\x34\x3\x34"+
		"\x3\x34\x3\x34\a\x34\x14D\n\x34\f\x34\xE\x34\x150\v\x34\x3\x34\x3\x34"+
		"\x3\x34\x3\x34\x3\x34\x3\x35\x3\x35\x3\x35\x3\x35\x3\x35\a\x35\x15C\n"+
		"\x35\f\x35\xE\x35\x15F\v\x35\x3\x35\x3\x35\x3\x35\x3\x35\x3\x35\x3\x35"+
		"\x3\x36\x3\x36\x3\x15D\x2\x37\x3\x3\x5\x4\a\x5\t\x6\v\a\r\b\xF\t\x11\n"+
		"\x13\v\x15\f\x17\r\x19\xE\x1B\xF\x1D\x10\x1F\x11!\x12#\x13%\x14\'\x15"+
		")\x16+\x17-\x18/\x19\x31\x1A\x33\x1B\x35\x1C\x37\x1D\x39\x1E;\x1F= ?!"+
		"\x41\"\x43#\x45$G%I&K\'M(O)Q*S+U,W-Y.[/]\x30_\x31\x61\x32\x63\x33\x65"+
		"\x34g\x35i\x36k\x37\x3\x2\t\x5\x2\x43\\\x61\x61\x63|\x6\x2\x32;\x43\\"+
		"\x61\x61\x63|\x5\x2\v\f\xF\xF\"\"\x4\x2ZZzz\x5\x2\x32;\x43H\x63h\x5\x2"+
		"\f\f\xF\xF$$\x4\x2\f\f\xF\xF\x170\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2"+
		"\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2"+
		"\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2"+
		"\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3"+
		"\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2"+
		"\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2+\x3\x2\x2\x2\x2-\x3\x2\x2\x2"+
		"\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2\x2\x33\x3\x2\x2\x2\x2\x35\x3\x2\x2"+
		"\x2\x2\x37\x3\x2\x2\x2\x2\x39\x3\x2\x2\x2\x2;\x3\x2\x2\x2\x2=\x3\x2\x2"+
		"\x2\x2?\x3\x2\x2\x2\x2\x41\x3\x2\x2\x2\x2\x43\x3\x2\x2\x2\x2\x45\x3\x2"+
		"\x2\x2\x2G\x3\x2\x2\x2\x2I\x3\x2\x2\x2\x2K\x3\x2\x2\x2\x2M\x3\x2\x2\x2"+
		"\x2O\x3\x2\x2\x2\x2Q\x3\x2\x2\x2\x2S\x3\x2\x2\x2\x2U\x3\x2\x2\x2\x2W\x3"+
		"\x2\x2\x2\x2Y\x3\x2\x2\x2\x2[\x3\x2\x2\x2\x2]\x3\x2\x2\x2\x2_\x3\x2\x2"+
		"\x2\x2\x61\x3\x2\x2\x2\x2\x63\x3\x2\x2\x2\x2\x65\x3\x2\x2\x2\x2g\x3\x2"+
		"\x2\x2\x2i\x3\x2\x2\x2\x2k\x3\x2\x2\x2\x3m\x3\x2\x2\x2\x5t\x3\x2\x2\x2"+
		"\ax\x3\x2\x2\x2\t}\x3\x2\x2\x2\v\x80\x3\x2\x2\x2\r\x83\x3\x2\x2\x2\xF"+
		"\x88\x3\x2\x2\x2\x11\x8D\x3\x2\x2\x2\x13\x92\x3\x2\x2\x2\x15\x98\x3\x2"+
		"\x2\x2\x17\x9C\x3\x2\x2\x2\x19\xA2\x3\x2\x2\x2\x1B\xA7\x3\x2\x2\x2\x1D"+
		"\xAC\x3\x2\x2\x2\x1F\xB2\x3\x2\x2\x2!\xBB\x3\x2\x2\x2#\xC1\x3\x2\x2\x2"+
		"%\xC8\x3\x2\x2\x2\'\xCF\x3\x2\x2\x2)\xD4\x3\x2\x2\x2+\xDA\x3\x2\x2\x2"+
		"-\xDC\x3\x2\x2\x2/\xDE\x3\x2\x2\x2\x31\xE0\x3\x2\x2\x2\x33\xE2\x3\x2\x2"+
		"\x2\x35\xE4\x3\x2\x2\x2\x37\xE6\x3\x2\x2\x2\x39\xE8\x3\x2\x2\x2;\xEA\x3"+
		"\x2\x2\x2=\xEC\x3\x2\x2\x2?\xEE\x3\x2\x2\x2\x41\xF2\x3\x2\x2\x2\x43\xF5"+
		"\x3\x2\x2\x2\x45\xF9\x3\x2\x2\x2G\xFD\x3\x2\x2\x2I\xFF\x3\x2\x2\x2K\x103"+
		"\x3\x2\x2\x2M\x105\x3\x2\x2\x2O\x108\x3\x2\x2\x2Q\x10B\x3\x2\x2\x2S\x10E"+
		"\x3\x2\x2\x2U\x111\x3\x2\x2\x2W\x113\x3\x2\x2\x2Y\x115\x3\x2\x2\x2[\x118"+
		"\x3\x2\x2\x2]\x121\x3\x2\x2\x2_\x12A\x3\x2\x2\x2\x61\x134\x3\x2\x2\x2"+
		"\x63\x138\x3\x2\x2\x2\x65\x13F\x3\x2\x2\x2g\x148\x3\x2\x2\x2i\x156\x3"+
		"\x2\x2\x2k\x166\x3\x2\x2\x2mn\au\x2\x2no\av\x2\x2op\at\x2\x2pq\ak\x2\x2"+
		"qr\ap\x2\x2rs\ai\x2\x2s\x4\x3\x2\x2\x2tu\ak\x2\x2uv\ap\x2\x2vw\av\x2\x2"+
		"w\x6\x3\x2\x2\x2xy\a\x64\x2\x2yz\aq\x2\x2z{\aq\x2\x2{|\an\x2\x2|\b\x3"+
		"\x2\x2\x2}~\ak\x2\x2~\x7F\ah\x2\x2\x7F\n\x3\x2\x2\x2\x80\x81\av\x2\x2"+
		"\x81\x82\aq\x2\x2\x82\f\x3\x2\x2\x2\x83\x84\ao\x2\x2\x84\x85\ah\x2\x2"+
		"\x85\x86\aq\x2\x2\x86\x87\at\x2\x2\x87\xE\x3\x2\x2\x2\x88\x89\au\x2\x2"+
		"\x89\x8A\av\x2\x2\x8A\x8B\ag\x2\x2\x8B\x8C\ar\x2\x2\x8C\x10\x3\x2\x2\x2"+
		"\x8D\x8E\av\x2\x2\x8E\x8F\aj\x2\x2\x8F\x90\ag\x2\x2\x90\x91\ap\x2\x2\x91"+
		"\x12\x3\x2\x2\x2\x92\x93\a\x64\x2\x2\x93\x94\ag\x2\x2\x94\x95\ai\x2\x2"+
		"\x95\x96\ak\x2\x2\x96\x97\ap\x2\x2\x97\x14\x3\x2\x2\x2\x98\x99\ag\x2\x2"+
		"\x99\x9A\ap\x2\x2\x9A\x9B\a\x66\x2\x2\x9B\x16\x3\x2\x2\x2\x9C\x9D\ay\x2"+
		"\x2\x9D\x9E\aj\x2\x2\x9E\x9F\ak\x2\x2\x9F\xA0\an\x2\x2\xA0\xA1\ag\x2\x2"+
		"\xA1\x18\x3\x2\x2\x2\xA2\xA3\ag\x2\x2\xA3\xA4\an\x2\x2\xA4\xA5\au\x2\x2"+
		"\xA5\xA6\ag\x2\x2\xA6\x1A\x3\x2\x2\x2\xA7\xA8\at\x2\x2\xA8\xA9\ag\x2\x2"+
		"\xA9\xAA\a\x63\x2\x2\xAA\xAB\a\x66\x2\x2\xAB\x1C\x3\x2\x2\x2\xAC\xAD\a"+
		"y\x2\x2\xAD\xAE\at\x2\x2\xAE\xAF\ak\x2\x2\xAF\xB0\av\x2\x2\xB0\xB1\ag"+
		"\x2\x2\xB1\x1E\x3\x2\x2\x2\xB2\xB3\ah\x2\x2\xB3\xB4\a\x63\x2\x2\xB4\xB5"+
		"\ap\x2\x2\xB5\xB6\a\x65\x2\x2\xB6\xB7\av\x2\x2\xB7\xB8\ak\x2\x2\xB8\xB9"+
		"\aq\x2\x2\xB9\xBA\ap\x2\x2\xBA \x3\x2\x2\x2\xBB\xBC\ak\x2\x2\xBC\xBD\a"+
		"p\x2\x2\xBD\xBE\ar\x2\x2\xBE\xBF\aw\x2\x2\xBF\xC0\av\x2\x2\xC0\"\x3\x2"+
		"\x2\x2\xC1\xC2\aq\x2\x2\xC2\xC3\aw\x2\x2\xC3\xC4\av\x2\x2\xC4\xC5\ar\x2"+
		"\x2\xC5\xC6\aw\x2\x2\xC6\xC7\av\x2\x2\xC7$\x3\x2\x2\x2\xC8\xC9\at\x2\x2"+
		"\xC9\xCA\ag\x2\x2\xCA\xCB\av\x2\x2\xCB\xCC\aw\x2\x2\xCC\xCD\at\x2\x2\xCD"+
		"\xCE\ap\x2\x2\xCE&\x3\x2\x2\x2\xCF\xD0\av\x2\x2\xD0\xD1\at\x2\x2\xD1\xD2"+
		"\aw\x2\x2\xD2\xD3\ag\x2\x2\xD3(\x3\x2\x2\x2\xD4\xD5\ah\x2\x2\xD5\xD6\a"+
		"\x63\x2\x2\xD6\xD7\an\x2\x2\xD7\xD8\au\x2\x2\xD8\xD9\ag\x2\x2\xD9*\x3"+
		"\x2\x2\x2\xDA\xDB\a-\x2\x2\xDB,\x3\x2\x2\x2\xDC\xDD\a*\x2\x2\xDD.\x3\x2"+
		"\x2\x2\xDE\xDF\a+\x2\x2\xDF\x30\x3\x2\x2\x2\xE0\xE1\a/\x2\x2\xE1\x32\x3"+
		"\x2\x2\x2\xE2\xE3\a,\x2\x2\xE3\x34\x3\x2\x2\x2\xE4\xE5\a\x31\x2\x2\xE5"+
		"\x36\x3\x2\x2\x2\xE6\xE7\a?\x2\x2\xE7\x38\x3\x2\x2\x2\xE8\xE9\a\'\x2\x2"+
		"\xE9:\x3\x2\x2\x2\xEA\xEB\a#\x2\x2\xEB<\x3\x2\x2\x2\xEC\xED\a`\x2\x2\xED"+
		">\x3\x2\x2\x2\xEE\xEF\a\x63\x2\x2\xEF\xF0\ap\x2\x2\xF0\xF1\a\x66\x2\x2"+
		"\xF1@\x3\x2\x2\x2\xF2\xF3\aq\x2\x2\xF3\xF4\at\x2\x2\xF4\x42\x3\x2\x2\x2"+
		"\xF5\xF6\az\x2\x2\xF6\xF7\aq\x2\x2\xF7\xF8\at\x2\x2\xF8\x44\x3\x2\x2\x2"+
		"\xF9\xFA\ap\x2\x2\xFA\xFB\aq\x2\x2\xFB\xFC\av\x2\x2\xFC\x46\x3\x2\x2\x2"+
		"\xFD\xFE\a>\x2\x2\xFEH\x3\x2\x2\x2\xFF\x100\ah\x2\x2\x100\x101\aq\x2\x2"+
		"\x101\x102\at\x2\x2\x102J\x3\x2\x2\x2\x103\x104\a@\x2\x2\x104L\x3\x2\x2"+
		"\x2\x105\x106\a>\x2\x2\x106\x107\a?\x2\x2\x107N\x3\x2\x2\x2\x108\x109"+
		"\a@\x2\x2\x109\x10A\a?\x2\x2\x10AP\x3\x2\x2\x2\x10B\x10C\a?\x2\x2\x10C"+
		"\x10D\a?\x2\x2\x10DR\x3\x2\x2\x2\x10E\x10F\a>\x2\x2\x10F\x110\a@\x2\x2"+
		"\x110T\x3\x2\x2\x2\x111\x112\a\x41\x2\x2\x112V\x3\x2\x2\x2\x113\x114\a"+
		"<\x2\x2\x114X\x3\x2\x2\x2\x115\x116\a=\x2\x2\x116Z\x3\x2\x2\x2\x117\x119"+
		"\t\x2\x2\x2\x118\x117\x3\x2\x2\x2\x119\x11D\x3\x2\x2\x2\x11A\x11C\t\x3"+
		"\x2\x2\x11B\x11A\x3\x2\x2\x2\x11C\x11F\x3\x2\x2\x2\x11D\x11B\x3\x2\x2"+
		"\x2\x11D\x11E\x3\x2\x2\x2\x11E\\\x3\x2\x2\x2\x11F\x11D\x3\x2\x2\x2\x120"+
		"\x122\t\x4\x2\x2\x121\x120\x3\x2\x2\x2\x122\x123\x3\x2\x2\x2\x123\x121"+
		"\x3\x2\x2\x2\x123\x124\x3\x2\x2\x2\x124\x125\x3\x2\x2\x2\x125\x126\b/"+
		"\x2\x2\x126^\x3\x2\x2\x2\x127\x129\x4\x32;\x2\x128\x127\x3\x2\x2\x2\x129"+
		"\x12C\x3\x2\x2\x2\x12A\x128\x3\x2\x2\x2\x12A\x12B\x3\x2\x2\x2\x12B\x12D"+
		"\x3\x2\x2\x2\x12C\x12A\x3\x2\x2\x2\x12D\x12F\a\x30\x2\x2\x12E\x130\x4"+
		"\x32;\x2\x12F\x12E\x3\x2\x2\x2\x130\x131\x3\x2\x2\x2\x131\x12F\x3\x2\x2"+
		"\x2\x131\x132\x3\x2\x2\x2\x132`\x3\x2\x2\x2\x133\x135\x4\x32;\x2\x134"+
		"\x133\x3\x2\x2\x2\x135\x136\x3\x2\x2\x2\x136\x134\x3\x2\x2\x2\x136\x137"+
		"\x3\x2\x2\x2\x137\x62\x3\x2\x2\x2\x138\x139\a\x32\x2\x2\x139\x13B\t\x5"+
		"\x2\x2\x13A\x13C\t\x6\x2\x2\x13B\x13A\x3\x2\x2\x2\x13C\x13D\x3\x2\x2\x2"+
		"\x13D\x13B\x3\x2\x2\x2\x13D\x13E\x3\x2\x2\x2\x13E\x64\x3\x2\x2\x2\x13F"+
		"\x143\a$\x2\x2\x140\x142\n\a\x2\x2\x141\x140\x3\x2\x2\x2\x142\x145\x3"+
		"\x2\x2\x2\x143\x141\x3\x2\x2\x2\x143\x144\x3\x2\x2\x2\x144\x146\x3\x2"+
		"\x2\x2\x145\x143\x3\x2\x2\x2\x146\x147\a$\x2\x2\x147\x66\x3\x2\x2\x2\x148"+
		"\x149\a\'\x2\x2\x149\x14A\a\'\x2\x2\x14A\x14E\x3\x2\x2\x2\x14B\x14D\n"+
		"\b\x2\x2\x14C\x14B\x3\x2\x2\x2\x14D\x150\x3\x2\x2\x2\x14E\x14C\x3\x2\x2"+
		"\x2\x14E\x14F\x3\x2\x2\x2\x14F\x151\x3\x2\x2\x2\x150\x14E\x3\x2\x2\x2"+
		"\x151\x152\a\xF\x2\x2\x152\x153\a\f\x2\x2\x153\x154\x3\x2\x2\x2\x154\x155"+
		"\b\x34\x2\x2\x155h\x3\x2\x2\x2\x156\x157\a\'\x2\x2\x157\x158\a\'\x2\x2"+
		"\x158\x159\a\'\x2\x2\x159\x15D\x3\x2\x2\x2\x15A\x15C\v\x2\x2\x2\x15B\x15A"+
		"\x3\x2\x2\x2\x15C\x15F\x3\x2\x2\x2\x15D\x15E\x3\x2\x2\x2\x15D\x15B\x3"+
		"\x2\x2\x2\x15E\x160\x3\x2\x2\x2\x15F\x15D\x3\x2\x2\x2\x160\x161\a\'\x2"+
		"\x2\x161\x162\a\'\x2\x2\x162\x163\a\'\x2\x2\x163\x164\x3\x2\x2\x2\x164"+
		"\x165\b\x35\x2\x2\x165j\x3\x2\x2\x2\x166\x167\a.\x2\x2\x167l\x3\x2\x2"+
		"\x2\xE\x2\x118\x11B\x11D\x123\x12A\x131\x136\x13D\x143\x14E\x15D\x3\b"+
		"\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
