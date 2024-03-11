// Generated from f:\School\bakalarka\src\Logicalc\Business\Grammars\Logic.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class LLATLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		WHITESPACE=1, COMMENT=2, OPEN_PAREN=3, CLOSE_PAREN=4, COMMA=5, SEMICOLON=6, 
		AND=7, OR=8, IMP=9, BICOND=10, NEG=11, XOR=12, IDENTITY=13, ATOM=14, CONSTANT=15, 
		VARIABLE=16, EXISTENTIAL=17, UNIVERSAL=18, THEREFORE=19, SEMANTIC_ENTAILMENT=20;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"WHITESPACE", "COMMENT", "DIGIT", "LOWER_CASE_LTR", "UPPER_CASE_LTR", 
			"ANY_CASE_LTR", "UNDERSCORE", "SINGLE_QUOTE", "DOUBLE_QUOTE", "ANYCHAR", 
			"NEWLINE", "CARRIAGE_RET", "TAB", "NULL_CHAR", "ESCAPED_CHAR", "AND_LIT", 
			"OR_LIT", "IMP_LIT", "BICOND_LIT", "NEG_LIT", "XOR_LIT", "IDENTITY_LIT", 
			"OPEN_PAREN", "CLOSE_PAREN", "COMMA", "SEMICOLON", "AND", "OR", "IMP", 
			"BICOND", "NEG", "XOR", "IDENTITY", "ATOM", "CONSTANT", "VARIABLE", "EXISTENTIAL", 
			"UNIVERSAL", "THEREFORE", "SEMANTIC_ENTAILMENT"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, "'('", "')'", "','", "';'", null, null, null, null, 
			null, null, null, null, null, null, "'\u00E2\uFFFD\uFFFD'", "'\u00E2\uFFFD\u20AC'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "WHITESPACE", "COMMENT", "OPEN_PAREN", "CLOSE_PAREN", "COMMA", 
			"SEMICOLON", "AND", "OR", "IMP", "BICOND", "NEG", "XOR", "IDENTITY", 
			"ATOM", "CONSTANT", "VARIABLE", "EXISTENTIAL", "UNIVERSAL", "THEREFORE", 
			"SEMANTIC_ENTAILMENT"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public LLATLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Logic.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\26\u014a\b\1\4\2"+
		"\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4"+
		"\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31"+
		"\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t"+
		" \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\3\2\6\2U\n"+
		"\2\r\2\16\2V\3\2\3\2\3\3\3\3\3\3\3\3\7\3_\n\3\f\3\16\3b\13\3\3\3\3\3\3"+
		"\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\t\3\t\3\n\3\n\3\13\3"+
		"\13\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\17\3\20\3\20\3\20\3\21\3\21"+
		"\3\21\3\21\3\21\3\21\5\21\u008a\n\21\3\22\3\22\3\22\3\22\5\22\u0090\n"+
		"\22\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3\23\3"+
		"\23\5\23\u00a0\n\23\3\24\3\24\3\24\3\24\3\24\3\24\5\24\u00a8\n\24\3\25"+
		"\3\25\3\25\3\25\3\25\3\25\5\25\u00b0\n\25\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\5\26\u00b8\n\26\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27"+
		"\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\3\27\5\27\u00ce\n\27\3\30\3\30"+
		"\3\31\3\31\3\32\3\32\3\33\3\33\3\34\3\34\3\34\3\34\3\34\3\34\3\34\3\34"+
		"\5\34\u00e0\n\34\3\35\3\35\3\35\3\35\3\35\3\35\3\35\3\35\5\35\u00ea\n"+
		"\35\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\36\5"+
		"\36\u00f9\n\36\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3\37"+
		"\3\37\3\37\3\37\3\37\5\37\u010a\n\37\3 \3 \3 \3 \3 \3 \3 \5 \u0113\n "+
		"\3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\3!\5!\u0125\n!\3\"\3\"\5"+
		"\"\u0129\n\"\3#\3#\3$\3$\3%\3%\3&\3&\3&\3&\3\'\3\'\3\'\3\'\3(\3(\3(\3"+
		"(\3(\3(\3(\3(\5(\u0141\n(\3)\3)\3)\3)\3)\3)\5)\u0149\n)\3`\2*\3\3\5\4"+
		"\7\2\t\2\13\2\r\2\17\2\21\2\23\2\25\2\27\2\31\2\33\2\35\2\37\2!\2#\2%"+
		"\2\'\2)\2+\2-\2/\5\61\6\63\7\65\b\67\t9\n;\13=\f?\rA\16C\17E\20G\21I\22"+
		"K\23M\24O\25Q\26\3\2\n\5\2\13\f\17\17\"\"\3\2\62;\3\2c|\3\2C\\\4\2C\\"+
		"c|\5\2\u0080\u0080\u223e\u223e\uff60\uff60\3\2cv\3\2w|\2\u015d\2\3\3\2"+
		"\2\2\2\5\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67"+
		"\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2\2C\3\2"+
		"\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O\3\2\2\2"+
		"\2Q\3\2\2\2\3T\3\2\2\2\5Z\3\2\2\2\7g\3\2\2\2\ti\3\2\2\2\13k\3\2\2\2\r"+
		"m\3\2\2\2\17o\3\2\2\2\21q\3\2\2\2\23s\3\2\2\2\25u\3\2\2\2\27w\3\2\2\2"+
		"\31y\3\2\2\2\33{\3\2\2\2\35}\3\2\2\2\37\u0080\3\2\2\2!\u0089\3\2\2\2#"+
		"\u008f\3\2\2\2%\u009f\3\2\2\2\'\u00a7\3\2\2\2)\u00af\3\2\2\2+\u00b7\3"+
		"\2\2\2-\u00cd\3\2\2\2/\u00cf\3\2\2\2\61\u00d1\3\2\2\2\63\u00d3\3\2\2\2"+
		"\65\u00d5\3\2\2\2\67\u00df\3\2\2\29\u00e9\3\2\2\2;\u00f8\3\2\2\2=\u0109"+
		"\3\2\2\2?\u0112\3\2\2\2A\u0124\3\2\2\2C\u0128\3\2\2\2E\u012a\3\2\2\2G"+
		"\u012c\3\2\2\2I\u012e\3\2\2\2K\u0130\3\2\2\2M\u0134\3\2\2\2O\u0140\3\2"+
		"\2\2Q\u0148\3\2\2\2SU\t\2\2\2TS\3\2\2\2UV\3\2\2\2VT\3\2\2\2VW\3\2\2\2"+
		"WX\3\2\2\2XY\b\2\2\2Y\4\3\2\2\2Z[\7\61\2\2[\\\7\61\2\2\\`\3\2\2\2]_\13"+
		"\2\2\2^]\3\2\2\2_b\3\2\2\2`a\3\2\2\2`^\3\2\2\2ac\3\2\2\2b`\3\2\2\2cd\5"+
		"\27\f\2de\3\2\2\2ef\b\3\2\2f\6\3\2\2\2gh\t\3\2\2h\b\3\2\2\2ij\t\4\2\2"+
		"j\n\3\2\2\2kl\t\5\2\2l\f\3\2\2\2mn\t\6\2\2n\16\3\2\2\2op\7a\2\2p\20\3"+
		"\2\2\2qr\7)\2\2r\22\3\2\2\2st\7$\2\2t\24\3\2\2\2uv\13\2\2\2v\26\3\2\2"+
		"\2wx\7\f\2\2x\30\3\2\2\2yz\7\17\2\2z\32\3\2\2\2{|\7\13\2\2|\34\3\2\2\2"+
		"}~\7^\2\2~\177\7\62\2\2\177\36\3\2\2\2\u0080\u0081\7^\2\2\u0081\u0082"+
		"\13\2\2\2\u0082 \3\2\2\2\u0083\u0084\7C\2\2\u0084\u0085\7P\2\2\u0085\u008a"+
		"\7F\2\2\u0086\u0087\7c\2\2\u0087\u0088\7p\2\2\u0088\u008a\7f\2\2\u0089"+
		"\u0083\3\2\2\2\u0089\u0086\3\2\2\2\u008a\"\3\2\2\2\u008b\u008c\7Q\2\2"+
		"\u008c\u0090\7T\2\2\u008d\u008e\7q\2\2\u008e\u0090\7t\2\2\u008f\u008b"+
		"\3\2\2\2\u008f\u008d\3\2\2\2\u0090$\3\2\2\2\u0091\u0092\7K\2\2\u0092\u0093"+
		"\7O\2\2\u0093\u0094\7R\2\2\u0094\u0095\7N\2\2\u0095\u0096\7K\2\2\u0096"+
		"\u0097\7G\2\2\u0097\u00a0\7U\2\2\u0098\u0099\7k\2\2\u0099\u009a\7o\2\2"+
		"\u009a\u009b\7r\2\2\u009b\u009c\7n\2\2\u009c\u009d\7k\2\2\u009d\u009e"+
		"\7g\2\2\u009e\u00a0\7u\2\2\u009f\u0091\3\2\2\2\u009f\u0098\3\2\2\2\u00a0"+
		"&\3\2\2\2\u00a1\u00a2\7K\2\2\u00a2\u00a3\7H\2\2\u00a3\u00a8\7H\2\2\u00a4"+
		"\u00a5\7k\2\2\u00a5\u00a6\7h\2\2\u00a6\u00a8\7h\2\2\u00a7\u00a1\3\2\2"+
		"\2\u00a7\u00a4\3\2\2\2\u00a8(\3\2\2\2\u00a9\u00aa\7P\2\2\u00aa\u00ab\7"+
		"Q\2\2\u00ab\u00b0\7V\2\2\u00ac\u00ad\7p\2\2\u00ad\u00ae\7q\2\2\u00ae\u00b0"+
		"\7v\2\2\u00af\u00a9\3\2\2\2\u00af\u00ac\3\2\2\2\u00b0*\3\2\2\2\u00b1\u00b2"+
		"\7Z\2\2\u00b2\u00b3\7Q\2\2\u00b3\u00b8\7T\2\2\u00b4\u00b5\7z\2\2\u00b5"+
		"\u00b6\7q\2\2\u00b6\u00b8\7t\2\2\u00b7\u00b1\3\2\2\2\u00b7\u00b4\3\2\2"+
		"\2\u00b8,\3\2\2\2\u00b9\u00ba\7G\2\2\u00ba\u00bb\7S\2\2\u00bb\u00bc\7"+
		"W\2\2\u00bc\u00bd\7K\2\2\u00bd\u00be\7X\2\2\u00be\u00bf\7C\2\2\u00bf\u00c0"+
		"\7N\2\2\u00c0\u00c1\7G\2\2\u00c1\u00c2\7P\2\2\u00c2\u00ce\7V\2\2\u00c3"+
		"\u00c4\7g\2\2\u00c4\u00c5\7s\2\2\u00c5\u00c6\7w\2\2\u00c6\u00c7\7k\2\2"+
		"\u00c7\u00c8\7x\2\2\u00c8\u00c9\7c\2\2\u00c9\u00ca\7n\2\2\u00ca\u00cb"+
		"\7g\2\2\u00cb\u00cc\7p\2\2\u00cc\u00ce\7v\2\2\u00cd\u00b9\3\2\2\2\u00cd"+
		"\u00c3\3\2\2\2\u00ce.\3\2\2\2\u00cf\u00d0\7*\2\2\u00d0\60\3\2\2\2\u00d1"+
		"\u00d2\7+\2\2\u00d2\62\3\2\2\2\u00d3\u00d4\7.\2\2\u00d4\64\3\2\2\2\u00d5"+
		"\u00d6\7=\2\2\u00d6\66\3\2\2\2\u00d7\u00e0\7(\2\2\u00d8\u00d9\7\u00e4"+
		"\2\2\u00d9\u00da\7\uffff\2\2\u00da\u00e0\7\u00a9\2\2\u00db\u00e0\7`\2"+
		"\2\u00dc\u00dd\7\u00c4\2\2\u00dd\u00e0\7\u00b9\2\2\u00de\u00e0\5!\21\2"+
		"\u00df\u00d7\3\2\2\2\u00df\u00d8\3\2\2\2\u00df\u00db\3\2\2\2\u00df\u00dc"+
		"\3\2\2\2\u00df\u00de\3\2\2\2\u00e08\3\2\2\2\u00e1\u00ea\7~\2\2\u00e2\u00e3"+
		"\7\u00e4\2\2\u00e3\u00e4\7\uffff\2\2\u00e4\u00ea\7\u00aa\2\2\u00e5\u00ea"+
		"\7-\2\2\u00e6\u00e7\7~\2\2\u00e7\u00ea\7~\2\2\u00e8\u00ea\5#\22\2\u00e9"+
		"\u00e1\3\2\2\2\u00e9\u00e2\3\2\2\2\u00e9\u00e5\3\2\2\2\u00e9\u00e6\3\2"+
		"\2\2\u00e9\u00e8\3\2\2\2\u00ea:\3\2\2\2\u00eb\u00ec\7/\2\2\u00ec\u00f9"+
		"\7@\2\2\u00ed\u00ee\7\u00e4\2\2\u00ee\u00ef\7\u2022\2\2\u00ef\u00f9\7"+
		"\u201b\2\2\u00f0\u00f1\7\u00e4\2\2\u00f1\u00f2\7\u2023\2\2\u00f2\u00f9"+
		"\7\u201b\2\2\u00f3\u00f4\7\u00e4\2\2\u00f4\u00f5\7\u0162\2\2\u00f5\u00f9"+
		"\7\uffff\2\2\u00f6\u00f9\7@\2\2\u00f7\u00f9\5%\23\2\u00f8\u00eb\3\2\2"+
		"\2\u00f8\u00ed\3\2\2\2\u00f8\u00f0\3\2\2\2\u00f8\u00f3\3\2\2\2\u00f8\u00f6"+
		"\3\2\2\2\u00f8\u00f7\3\2\2\2\u00f9<\3\2\2\2\u00fa\u00fb\7>\2\2\u00fb\u00fc"+
		"\7/\2\2\u00fc\u010a\7@\2\2\u00fd\u00fe\7\u00e4\2\2\u00fe\u00ff\7\u2023"+
		"\2\2\u00ff\u010a\7\u201f\2\2\u0100\u0101\7\u00e4\2\2\u0101\u0102\7\u2032"+
		"\2\2\u0102\u010a\7\u02c9\2\2\u0103\u0104\7\u00e4\2\2\u0104\u0105\7\u2022"+
		"\2\2\u0105\u010a\7\u201f\2\2\u0106\u0107\7>\2\2\u0107\u010a\7@\2\2\u0108"+
		"\u010a\5\'\24\2\u0109\u00fa\3\2\2\2\u0109\u00fd\3\2\2\2\u0109\u0100\3"+
		"\2\2\2\u0109\u0103\3\2\2\2\u0109\u0106\3\2\2\2\u0109\u0108\3\2\2\2\u010a"+
		">\3\2\2\2\u010b\u010c\7\u00cd\2\2\u010c\u0113\7\u015d\2\2\u010d\u0113"+
		"\t\7\2\2\u010e\u010f\7\u00c4\2\2\u010f\u0113\7\u00ae\2\2\u0110\u0113\7"+
		"#\2\2\u0111\u0113\5)\25\2\u0112\u010b\3\2\2\2\u0112\u010d\3\2\2\2\u0112"+
		"\u010e\3\2\2\2\u0112\u0110\3\2\2\2\u0112\u0111\3\2\2\2\u0113@\3\2\2\2"+
		"\u0114\u0115\7\u00e4\2\2\u0115\u0116\7\u0162\2\2\u0116\u0125\7\u2024\2"+
		"\2\u0117\u0118\7\u00e4\2\2\u0118\u0119\7\u0162\2\2\u0119\u0125\7\u00bd"+
		"\2\2\u011a\u011b\7\u00e4\2\2\u011b\u011c\7\u2032\2\2\u011c\u0125\7\u02da"+
		"\2\2\u011d\u011e\7\u00e4\2\2\u011e\u011f\7\u00ab\2\2\u011f\u0125\7\u201b"+
		"\2\2\u0120\u0121\7\u00e4\2\2\u0121\u0122\7\u2022\2\2\u0122\u0125\7\u00b0"+
		"\2\2\u0123\u0125\5+\26\2\u0124\u0114\3\2\2\2\u0124\u0117\3\2\2\2\u0124"+
		"\u011a\3\2\2\2\u0124\u011d\3\2\2\2\u0124\u0120\3\2\2\2\u0124\u0123\3\2"+
		"\2\2\u0125B\3\2\2\2\u0126\u0129\7?\2\2\u0127\u0129\5-\27\2\u0128\u0126"+
		"\3\2\2\2\u0128\u0127\3\2\2\2\u0129D\3\2\2\2\u012a\u012b\5\13\6\2\u012b"+
		"F\3\2\2\2\u012c\u012d\t\b\2\2\u012dH\3\2\2\2\u012e\u012f\t\t\2\2\u012f"+
		"J\3\2\2\2\u0130\u0131\7\u00e4\2\2\u0131\u0132\7\uffff\2\2\u0132\u0133"+
		"\7\uffff\2\2\u0133L\3\2\2\2\u0134\u0135\7\u00e4\2\2\u0135\u0136\7\uffff"+
		"\2\2\u0136\u0137\7\u20ae\2\2\u0137N\3\2\2\2\u0138\u0139\7\u00e4\2\2\u0139"+
		"\u013a\7\u0162\2\2\u013a\u0141\7\u02da\2\2\u013b\u013c\7\u00e4\2\2\u013c"+
		"\u013d\7\uffff\2\2\u013d\u0141\7\u00b6\2\2\u013e\u013f\7?\2\2\u013f\u0141"+
		"\7@\2\2\u0140\u0138\3\2\2\2\u0140\u013b\3\2\2\2\u0140\u013e\3\2\2\2\u0141"+
		"P\3\2\2\2\u0142\u0143\7\u00e4\2\2\u0143\u0144\7\u0162\2\2\u0144\u0149"+
		"\7\u00a9\2\2\u0145\u0146\7\u00e4\2\2\u0146\u0147\7\u0162\2\2\u0147\u0149"+
		"\7\u00aa\2\2\u0148\u0142\3\2\2\2\u0148\u0145\3\2\2\2\u0149R\3\2\2\2\25"+
		"\2V`\u0089\u008f\u009f\u00a7\u00af\u00b7\u00cd\u00df\u00e9\u00f8\u0109"+
		"\u0112\u0124\u0128\u0140\u0148\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}