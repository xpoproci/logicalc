// Generated from f:\School\bakalarka\src\Logicalc\Business\Grammars\Logic.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class LogicParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		WHITESPACE=1, COMMENT=2, OPEN_PAREN=3, CLOSE_PAREN=4, COMMA=5, SEMICOLON=6, 
		AND=7, OR=8, IMP=9, BICOND=10, NEG=11, XOR=12, IDENTITY=13, ATOM=14, CONSTANT=15, 
		VARIABLE=16, EXISTENTIAL=17, UNIVERSAL=18, THEREFORE=19, SEMANTIC_ENTAILMENT=20;
	public static final int
		RULE_program = 0, RULE_atom = 1, RULE_propositionalWff = 2, RULE_propWff = 3, 
		RULE_propNegRule = 4, RULE_propAndRule = 5, RULE_propOrRule = 6, RULE_propImpRule = 7, 
		RULE_propBicondRule = 8, RULE_propExclusiveOrRule = 9, RULE_constant = 10, 
		RULE_variable = 11, RULE_universal = 12, RULE_existential = 13, RULE_predicate = 14, 
		RULE_predicateWff = 15, RULE_predWff = 16, RULE_predQuantifier = 17, RULE_predNegRule = 18, 
		RULE_predAndRule = 19, RULE_predOrRule = 20, RULE_predImpRule = 21, RULE_predBicondRule = 22, 
		RULE_predExclusiveOrRule = 23, RULE_predIdentityRule = 24, RULE_predPremise = 25, 
		RULE_predConclusion = 26, RULE_predProof = 27, RULE_propPremise = 28, 
		RULE_propConclusion = 29, RULE_propProof = 30, RULE_predSemanticEntailment = 31, 
		RULE_propSemanticEntailment = 32;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "atom", "propositionalWff", "propWff", "propNegRule", "propAndRule", 
			"propOrRule", "propImpRule", "propBicondRule", "propExclusiveOrRule", 
			"constant", "variable", "universal", "existential", "predicate", "predicateWff", 
			"predWff", "predQuantifier", "predNegRule", "predAndRule", "predOrRule", 
			"predImpRule", "predBicondRule", "predExclusiveOrRule", "predIdentityRule", 
			"predPremise", "predConclusion", "predProof", "propPremise", "propConclusion", 
			"propProof", "predSemanticEntailment", "propSemanticEntailment"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, "'('", "')'", "','", "';'"
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

	@Override
	public String getGrammarFileName() { return "Logic.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public LogicParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ProgramContext extends ParserRuleContext {
		public PredProofContext predProof() {
			return getRuleContext(PredProofContext.class,0);
		}
		public TerminalNode EOF() { return getToken(LogicParser.EOF, 0); }
		public PropProofContext propProof() {
			return getRuleContext(PropProofContext.class,0);
		}
		public PredSemanticEntailmentContext predSemanticEntailment() {
			return getRuleContext(PredSemanticEntailmentContext.class,0);
		}
		public PropSemanticEntailmentContext propSemanticEntailment() {
			return getRuleContext(PropSemanticEntailmentContext.class,0);
		}
		public List<PropositionalWffContext> propositionalWff() {
			return getRuleContexts(PropositionalWffContext.class);
		}
		public PropositionalWffContext propositionalWff(int i) {
			return getRuleContext(PropositionalWffContext.class,i);
		}
		public TerminalNode COMMA() { return getToken(LogicParser.COMMA, 0); }
		public List<PredicateWffContext> predicateWff() {
			return getRuleContexts(PredicateWffContext.class);
		}
		public PredicateWffContext predicateWff(int i) {
			return getRuleContext(PredicateWffContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		try {
			setState(94);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(66);
				predProof();
				setState(67);
				match(EOF);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				{
				setState(69);
				propProof();
				setState(70);
				match(EOF);
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				{
				setState(72);
				predSemanticEntailment();
				setState(73);
				match(EOF);
				}
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				{
				setState(75);
				propSemanticEntailment();
				setState(76);
				match(EOF);
				}
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				{
				setState(78);
				propositionalWff();
				setState(79);
				match(COMMA);
				setState(80);
				propositionalWff();
				setState(81);
				match(EOF);
				}
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				{
				setState(83);
				predicateWff();
				setState(84);
				match(COMMA);
				setState(85);
				predicateWff();
				setState(86);
				match(EOF);
				}
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				{
				setState(88);
				propositionalWff();
				setState(89);
				match(EOF);
				}
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				{
				setState(91);
				predicateWff();
				setState(92);
				match(EOF);
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AtomContext extends ParserRuleContext {
		public TerminalNode ATOM() { return getToken(LogicParser.ATOM, 0); }
		public AtomContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_atom; }
	}

	public final AtomContext atom() throws RecognitionException {
		AtomContext _localctx = new AtomContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_atom);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(96);
			match(ATOM);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropositionalWffContext extends ParserRuleContext {
		public PropWffContext propWff() {
			return getRuleContext(PropWffContext.class,0);
		}
		public PropositionalWffContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propositionalWff; }
	}

	public final PropositionalWffContext propositionalWff() throws RecognitionException {
		PropositionalWffContext _localctx = new PropositionalWffContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_propositionalWff);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(98);
			propWff();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropWffContext extends ParserRuleContext {
		public AtomContext atom() {
			return getRuleContext(AtomContext.class,0);
		}
		public PropNegRuleContext propNegRule() {
			return getRuleContext(PropNegRuleContext.class,0);
		}
		public PropAndRuleContext propAndRule() {
			return getRuleContext(PropAndRuleContext.class,0);
		}
		public PropOrRuleContext propOrRule() {
			return getRuleContext(PropOrRuleContext.class,0);
		}
		public PropImpRuleContext propImpRule() {
			return getRuleContext(PropImpRuleContext.class,0);
		}
		public PropBicondRuleContext propBicondRule() {
			return getRuleContext(PropBicondRuleContext.class,0);
		}
		public PropExclusiveOrRuleContext propExclusiveOrRule() {
			return getRuleContext(PropExclusiveOrRuleContext.class,0);
		}
		public PropWffContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propWff; }
	}

	public final PropWffContext propWff() throws RecognitionException {
		PropWffContext _localctx = new PropWffContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_propWff);
		try {
			setState(107);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(100);
				atom();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(101);
				propNegRule();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(102);
				propAndRule();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(103);
				propOrRule();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(104);
				propImpRule();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(105);
				propBicondRule();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(106);
				propExclusiveOrRule();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropNegRuleContext extends ParserRuleContext {
		public TerminalNode NEG() { return getToken(LogicParser.NEG, 0); }
		public PropWffContext propWff() {
			return getRuleContext(PropWffContext.class,0);
		}
		public PropNegRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propNegRule; }
	}

	public final PropNegRuleContext propNegRule() throws RecognitionException {
		PropNegRuleContext _localctx = new PropNegRuleContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_propNegRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			match(NEG);
			setState(110);
			propWff();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropAndRuleContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public List<PropWffContext> propWff() {
			return getRuleContexts(PropWffContext.class);
		}
		public PropWffContext propWff(int i) {
			return getRuleContext(PropWffContext.class,i);
		}
		public TerminalNode AND() { return getToken(LogicParser.AND, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public PropAndRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propAndRule; }
	}

	public final PropAndRuleContext propAndRule() throws RecognitionException {
		PropAndRuleContext _localctx = new PropAndRuleContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_propAndRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(112);
			match(OPEN_PAREN);
			setState(113);
			propWff();
			setState(114);
			match(AND);
			setState(115);
			propWff();
			setState(116);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropOrRuleContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public List<PropWffContext> propWff() {
			return getRuleContexts(PropWffContext.class);
		}
		public PropWffContext propWff(int i) {
			return getRuleContext(PropWffContext.class,i);
		}
		public TerminalNode OR() { return getToken(LogicParser.OR, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public PropOrRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propOrRule; }
	}

	public final PropOrRuleContext propOrRule() throws RecognitionException {
		PropOrRuleContext _localctx = new PropOrRuleContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_propOrRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(118);
			match(OPEN_PAREN);
			setState(119);
			propWff();
			setState(120);
			match(OR);
			setState(121);
			propWff();
			setState(122);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropImpRuleContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public List<PropWffContext> propWff() {
			return getRuleContexts(PropWffContext.class);
		}
		public PropWffContext propWff(int i) {
			return getRuleContext(PropWffContext.class,i);
		}
		public TerminalNode IMP() { return getToken(LogicParser.IMP, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public PropImpRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propImpRule; }
	}

	public final PropImpRuleContext propImpRule() throws RecognitionException {
		PropImpRuleContext _localctx = new PropImpRuleContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_propImpRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(124);
			match(OPEN_PAREN);
			setState(125);
			propWff();
			setState(126);
			match(IMP);
			setState(127);
			propWff();
			setState(128);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropBicondRuleContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public List<PropWffContext> propWff() {
			return getRuleContexts(PropWffContext.class);
		}
		public PropWffContext propWff(int i) {
			return getRuleContext(PropWffContext.class,i);
		}
		public TerminalNode BICOND() { return getToken(LogicParser.BICOND, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public PropBicondRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propBicondRule; }
	}

	public final PropBicondRuleContext propBicondRule() throws RecognitionException {
		PropBicondRuleContext _localctx = new PropBicondRuleContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_propBicondRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(130);
			match(OPEN_PAREN);
			setState(131);
			propWff();
			setState(132);
			match(BICOND);
			setState(133);
			propWff();
			setState(134);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropExclusiveOrRuleContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public List<PropWffContext> propWff() {
			return getRuleContexts(PropWffContext.class);
		}
		public PropWffContext propWff(int i) {
			return getRuleContext(PropWffContext.class,i);
		}
		public TerminalNode XOR() { return getToken(LogicParser.XOR, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public PropExclusiveOrRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propExclusiveOrRule; }
	}

	public final PropExclusiveOrRuleContext propExclusiveOrRule() throws RecognitionException {
		PropExclusiveOrRuleContext _localctx = new PropExclusiveOrRuleContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_propExclusiveOrRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(136);
			match(OPEN_PAREN);
			setState(137);
			propWff();
			setState(138);
			match(XOR);
			setState(139);
			propWff();
			setState(140);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ConstantContext extends ParserRuleContext {
		public TerminalNode CONSTANT() { return getToken(LogicParser.CONSTANT, 0); }
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_constant);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(142);
			match(CONSTANT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VariableContext extends ParserRuleContext {
		public TerminalNode VARIABLE() { return getToken(LogicParser.VARIABLE, 0); }
		public VariableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variable; }
	}

	public final VariableContext variable() throws RecognitionException {
		VariableContext _localctx = new VariableContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_variable);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(144);
			match(VARIABLE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class UniversalContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public TerminalNode UNIVERSAL() { return getToken(LogicParser.UNIVERSAL, 0); }
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public UniversalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_universal; }
	}

	public final UniversalContext universal() throws RecognitionException {
		UniversalContext _localctx = new UniversalContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_universal);
		try {
			setState(155);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				{
				setState(146);
				match(OPEN_PAREN);
				setState(147);
				match(UNIVERSAL);
				setState(148);
				variable();
				setState(149);
				match(CLOSE_PAREN);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(151);
				match(OPEN_PAREN);
				setState(152);
				variable();
				setState(153);
				match(CLOSE_PAREN);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExistentialContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public TerminalNode EXISTENTIAL() { return getToken(LogicParser.EXISTENTIAL, 0); }
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public ExistentialContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_existential; }
	}

	public final ExistentialContext existential() throws RecognitionException {
		ExistentialContext _localctx = new ExistentialContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_existential);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(157);
			match(OPEN_PAREN);
			setState(158);
			match(EXISTENTIAL);
			setState(159);
			variable();
			setState(160);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredicateContext extends ParserRuleContext {
		public AtomContext atom() {
			return getRuleContext(AtomContext.class,0);
		}
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public List<ConstantContext> constant() {
			return getRuleContexts(ConstantContext.class);
		}
		public ConstantContext constant(int i) {
			return getRuleContext(ConstantContext.class,i);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(LogicParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(LogicParser.COMMA, i);
		}
		public PredicateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predicate; }
	}

	public final PredicateContext predicate() throws RecognitionException {
		PredicateContext _localctx = new PredicateContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_predicate);
		int _la;
		try {
			int _alt;
			setState(191);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(162);
				atom();
				setState(163);
				match(OPEN_PAREN);
				setState(178); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					setState(178);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case CONSTANT:
						{
						setState(164);
						constant();
						setState(168);
						_errHandler.sync(this);
						_la = _input.LA(1);
						while (_la==COMMA) {
							{
							{
							setState(165);
							match(COMMA);
							}
							}
							setState(170);
							_errHandler.sync(this);
							_la = _input.LA(1);
						}
						}
						break;
					case VARIABLE:
						{
						setState(171);
						variable();
						setState(175);
						_errHandler.sync(this);
						_la = _input.LA(1);
						while (_la==COMMA) {
							{
							{
							setState(172);
							match(COMMA);
							}
							}
							setState(177);
							_errHandler.sync(this);
							_la = _input.LA(1);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					}
					setState(180); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( _la==CONSTANT || _la==VARIABLE );
				setState(182);
				match(CLOSE_PAREN);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(184);
				atom();
				setState(187); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						setState(187);
						_errHandler.sync(this);
						switch (_input.LA(1)) {
						case CONSTANT:
							{
							setState(185);
							constant();
							}
							break;
						case VARIABLE:
							{
							setState(186);
							variable();
							}
							break;
						default:
							throw new NoViableAltException(this);
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(189); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
				} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredicateWffContext extends ParserRuleContext {
		public PredWffContext predWff() {
			return getRuleContext(PredWffContext.class,0);
		}
		public PredicateWffContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predicateWff; }
	}

	public final PredicateWffContext predicateWff() throws RecognitionException {
		PredicateWffContext _localctx = new PredicateWffContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_predicateWff);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(193);
			predWff();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredWffContext extends ParserRuleContext {
		public PredicateContext predicate() {
			return getRuleContext(PredicateContext.class,0);
		}
		public PredNegRuleContext predNegRule() {
			return getRuleContext(PredNegRuleContext.class,0);
		}
		public PredQuantifierContext predQuantifier() {
			return getRuleContext(PredQuantifierContext.class,0);
		}
		public PredAndRuleContext predAndRule() {
			return getRuleContext(PredAndRuleContext.class,0);
		}
		public PredOrRuleContext predOrRule() {
			return getRuleContext(PredOrRuleContext.class,0);
		}
		public PredImpRuleContext predImpRule() {
			return getRuleContext(PredImpRuleContext.class,0);
		}
		public PredBicondRuleContext predBicondRule() {
			return getRuleContext(PredBicondRuleContext.class,0);
		}
		public PredExclusiveOrRuleContext predExclusiveOrRule() {
			return getRuleContext(PredExclusiveOrRuleContext.class,0);
		}
		public PredIdentityRuleContext predIdentityRule() {
			return getRuleContext(PredIdentityRuleContext.class,0);
		}
		public PredWffContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predWff; }
	}

	public final PredWffContext predWff() throws RecognitionException {
		PredWffContext _localctx = new PredWffContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_predWff);
		try {
			setState(204);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(195);
				predicate();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(196);
				predNegRule();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(197);
				predQuantifier();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(198);
				predAndRule();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(199);
				predOrRule();
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(200);
				predImpRule();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(201);
				predBicondRule();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(202);
				predExclusiveOrRule();
				}
				break;
			case 9:
				enterOuterAlt(_localctx, 9);
				{
				setState(203);
				predIdentityRule();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredQuantifierContext extends ParserRuleContext {
		public PredWffContext predWff() {
			return getRuleContext(PredWffContext.class,0);
		}
		public ExistentialContext existential() {
			return getRuleContext(ExistentialContext.class,0);
		}
		public UniversalContext universal() {
			return getRuleContext(UniversalContext.class,0);
		}
		public TerminalNode NEG() { return getToken(LogicParser.NEG, 0); }
		public PredQuantifierContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predQuantifier; }
	}

	public final PredQuantifierContext predQuantifier() throws RecognitionException {
		PredQuantifierContext _localctx = new PredQuantifierContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_predQuantifier);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(207);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NEG) {
				{
				setState(206);
				match(NEG);
				}
			}

			setState(211);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
			case 1:
				{
				setState(209);
				existential();
				}
				break;
			case 2:
				{
				setState(210);
				universal();
				}
				break;
			}
			setState(213);
			predWff();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredNegRuleContext extends ParserRuleContext {
		public TerminalNode NEG() { return getToken(LogicParser.NEG, 0); }
		public PredWffContext predWff() {
			return getRuleContext(PredWffContext.class,0);
		}
		public PredNegRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predNegRule; }
	}

	public final PredNegRuleContext predNegRule() throws RecognitionException {
		PredNegRuleContext _localctx = new PredNegRuleContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_predNegRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(215);
			match(NEG);
			setState(216);
			predWff();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredAndRuleContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public List<PredWffContext> predWff() {
			return getRuleContexts(PredWffContext.class);
		}
		public PredWffContext predWff(int i) {
			return getRuleContext(PredWffContext.class,i);
		}
		public TerminalNode AND() { return getToken(LogicParser.AND, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public PredAndRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predAndRule; }
	}

	public final PredAndRuleContext predAndRule() throws RecognitionException {
		PredAndRuleContext _localctx = new PredAndRuleContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_predAndRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(218);
			match(OPEN_PAREN);
			setState(219);
			predWff();
			setState(220);
			match(AND);
			setState(221);
			predWff();
			setState(222);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredOrRuleContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public List<PredWffContext> predWff() {
			return getRuleContexts(PredWffContext.class);
		}
		public PredWffContext predWff(int i) {
			return getRuleContext(PredWffContext.class,i);
		}
		public TerminalNode OR() { return getToken(LogicParser.OR, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public PredOrRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predOrRule; }
	}

	public final PredOrRuleContext predOrRule() throws RecognitionException {
		PredOrRuleContext _localctx = new PredOrRuleContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_predOrRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(224);
			match(OPEN_PAREN);
			setState(225);
			predWff();
			setState(226);
			match(OR);
			setState(227);
			predWff();
			setState(228);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredImpRuleContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public List<PredWffContext> predWff() {
			return getRuleContexts(PredWffContext.class);
		}
		public PredWffContext predWff(int i) {
			return getRuleContext(PredWffContext.class,i);
		}
		public TerminalNode IMP() { return getToken(LogicParser.IMP, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public PredImpRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predImpRule; }
	}

	public final PredImpRuleContext predImpRule() throws RecognitionException {
		PredImpRuleContext _localctx = new PredImpRuleContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_predImpRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(230);
			match(OPEN_PAREN);
			setState(231);
			predWff();
			setState(232);
			match(IMP);
			setState(233);
			predWff();
			setState(234);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredBicondRuleContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public List<PredWffContext> predWff() {
			return getRuleContexts(PredWffContext.class);
		}
		public PredWffContext predWff(int i) {
			return getRuleContext(PredWffContext.class,i);
		}
		public TerminalNode BICOND() { return getToken(LogicParser.BICOND, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public PredBicondRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predBicondRule; }
	}

	public final PredBicondRuleContext predBicondRule() throws RecognitionException {
		PredBicondRuleContext _localctx = new PredBicondRuleContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_predBicondRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(236);
			match(OPEN_PAREN);
			setState(237);
			predWff();
			setState(238);
			match(BICOND);
			setState(239);
			predWff();
			setState(240);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredExclusiveOrRuleContext extends ParserRuleContext {
		public TerminalNode OPEN_PAREN() { return getToken(LogicParser.OPEN_PAREN, 0); }
		public List<PredWffContext> predWff() {
			return getRuleContexts(PredWffContext.class);
		}
		public PredWffContext predWff(int i) {
			return getRuleContext(PredWffContext.class,i);
		}
		public TerminalNode XOR() { return getToken(LogicParser.XOR, 0); }
		public TerminalNode CLOSE_PAREN() { return getToken(LogicParser.CLOSE_PAREN, 0); }
		public PredExclusiveOrRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predExclusiveOrRule; }
	}

	public final PredExclusiveOrRuleContext predExclusiveOrRule() throws RecognitionException {
		PredExclusiveOrRuleContext _localctx = new PredExclusiveOrRuleContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_predExclusiveOrRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(242);
			match(OPEN_PAREN);
			setState(243);
			predWff();
			setState(244);
			match(XOR);
			setState(245);
			predWff();
			setState(246);
			match(CLOSE_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredIdentityRuleContext extends ParserRuleContext {
		public TerminalNode IDENTITY() { return getToken(LogicParser.IDENTITY, 0); }
		public List<ConstantContext> constant() {
			return getRuleContexts(ConstantContext.class);
		}
		public ConstantContext constant(int i) {
			return getRuleContext(ConstantContext.class,i);
		}
		public List<VariableContext> variable() {
			return getRuleContexts(VariableContext.class);
		}
		public VariableContext variable(int i) {
			return getRuleContext(VariableContext.class,i);
		}
		public PredIdentityRuleContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predIdentityRule; }
	}

	public final PredIdentityRuleContext predIdentityRule() throws RecognitionException {
		PredIdentityRuleContext _localctx = new PredIdentityRuleContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_predIdentityRule);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(250);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case CONSTANT:
				{
				setState(248);
				constant();
				}
				break;
			case VARIABLE:
				{
				setState(249);
				variable();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(252);
			match(IDENTITY);
			setState(255);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case CONSTANT:
				{
				setState(253);
				constant();
				}
				break;
			case VARIABLE:
				{
				setState(254);
				variable();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredPremiseContext extends ParserRuleContext {
		public PredicateWffContext predicateWff() {
			return getRuleContext(PredicateWffContext.class,0);
		}
		public TerminalNode COMMA() { return getToken(LogicParser.COMMA, 0); }
		public TerminalNode SEMICOLON() { return getToken(LogicParser.SEMICOLON, 0); }
		public PredPremiseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predPremise; }
	}

	public final PredPremiseContext predPremise() throws RecognitionException {
		PredPremiseContext _localctx = new PredPremiseContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_predPremise);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(261);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				{
				{
				setState(257);
				predicateWff();
				setState(258);
				_la = _input.LA(1);
				if ( !(_la==COMMA || _la==SEMICOLON) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				}
				break;
			case 2:
				{
				setState(260);
				predicateWff();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredConclusionContext extends ParserRuleContext {
		public PredicateWffContext predicateWff() {
			return getRuleContext(PredicateWffContext.class,0);
		}
		public PredConclusionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predConclusion; }
	}

	public final PredConclusionContext predConclusion() throws RecognitionException {
		PredConclusionContext _localctx = new PredConclusionContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_predConclusion);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(263);
			predicateWff();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredProofContext extends ParserRuleContext {
		public TerminalNode THEREFORE() { return getToken(LogicParser.THEREFORE, 0); }
		public PredConclusionContext predConclusion() {
			return getRuleContext(PredConclusionContext.class,0);
		}
		public List<PredPremiseContext> predPremise() {
			return getRuleContexts(PredPremiseContext.class);
		}
		public PredPremiseContext predPremise(int i) {
			return getRuleContext(PredPremiseContext.class,i);
		}
		public PredProofContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predProof; }
	}

	public final PredProofContext predProof() throws RecognitionException {
		PredProofContext _localctx = new PredProofContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_predProof);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(266); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(265);
				predPremise();
				}
				}
				setState(268); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NEG) | (1L << ATOM) | (1L << CONSTANT) | (1L << VARIABLE))) != 0) );
			setState(270);
			match(THEREFORE);
			setState(271);
			predConclusion();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropPremiseContext extends ParserRuleContext {
		public PropositionalWffContext propositionalWff() {
			return getRuleContext(PropositionalWffContext.class,0);
		}
		public TerminalNode COMMA() { return getToken(LogicParser.COMMA, 0); }
		public TerminalNode SEMICOLON() { return getToken(LogicParser.SEMICOLON, 0); }
		public PropPremiseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propPremise; }
	}

	public final PropPremiseContext propPremise() throws RecognitionException {
		PropPremiseContext _localctx = new PropPremiseContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_propPremise);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(277);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				{
				{
				setState(273);
				propositionalWff();
				setState(274);
				_la = _input.LA(1);
				if ( !(_la==COMMA || _la==SEMICOLON) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				}
				break;
			case 2:
				{
				setState(276);
				propositionalWff();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropConclusionContext extends ParserRuleContext {
		public PropositionalWffContext propositionalWff() {
			return getRuleContext(PropositionalWffContext.class,0);
		}
		public PropConclusionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propConclusion; }
	}

	public final PropConclusionContext propConclusion() throws RecognitionException {
		PropConclusionContext _localctx = new PropConclusionContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_propConclusion);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(279);
			propositionalWff();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropProofContext extends ParserRuleContext {
		public TerminalNode THEREFORE() { return getToken(LogicParser.THEREFORE, 0); }
		public PropConclusionContext propConclusion() {
			return getRuleContext(PropConclusionContext.class,0);
		}
		public List<PropPremiseContext> propPremise() {
			return getRuleContexts(PropPremiseContext.class);
		}
		public PropPremiseContext propPremise(int i) {
			return getRuleContext(PropPremiseContext.class,i);
		}
		public PropProofContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propProof; }
	}

	public final PropProofContext propProof() throws RecognitionException {
		PropProofContext _localctx = new PropProofContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_propProof);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(282); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(281);
				propPremise();
				}
				}
				setState(284); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NEG) | (1L << ATOM))) != 0) );
			setState(286);
			match(THEREFORE);
			setState(287);
			propConclusion();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredSemanticEntailmentContext extends ParserRuleContext {
		public TerminalNode SEMANTIC_ENTAILMENT() { return getToken(LogicParser.SEMANTIC_ENTAILMENT, 0); }
		public PredicateWffContext predicateWff() {
			return getRuleContext(PredicateWffContext.class,0);
		}
		public List<PredPremiseContext> predPremise() {
			return getRuleContexts(PredPremiseContext.class);
		}
		public PredPremiseContext predPremise(int i) {
			return getRuleContext(PredPremiseContext.class,i);
		}
		public PredSemanticEntailmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predSemanticEntailment; }
	}

	public final PredSemanticEntailmentContext predSemanticEntailment() throws RecognitionException {
		PredSemanticEntailmentContext _localctx = new PredSemanticEntailmentContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_predSemanticEntailment);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(290); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(289);
				predPremise();
				}
				}
				setState(292); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NEG) | (1L << ATOM) | (1L << CONSTANT) | (1L << VARIABLE))) != 0) );
			setState(294);
			match(SEMANTIC_ENTAILMENT);
			setState(295);
			predicateWff();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PropSemanticEntailmentContext extends ParserRuleContext {
		public TerminalNode SEMANTIC_ENTAILMENT() { return getToken(LogicParser.SEMANTIC_ENTAILMENT, 0); }
		public PropositionalWffContext propositionalWff() {
			return getRuleContext(PropositionalWffContext.class,0);
		}
		public List<PropPremiseContext> propPremise() {
			return getRuleContexts(PropPremiseContext.class);
		}
		public PropPremiseContext propPremise(int i) {
			return getRuleContext(PropPremiseContext.class,i);
		}
		public PropSemanticEntailmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_propSemanticEntailment; }
	}

	public final PropSemanticEntailmentContext propSemanticEntailment() throws RecognitionException {
		PropSemanticEntailmentContext _localctx = new PropSemanticEntailmentContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_propSemanticEntailment);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(298); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(297);
				propPremise();
				}
				}
				setState(300); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPEN_PAREN) | (1L << NEG) | (1L << ATOM))) != 0) );
			setState(302);
			match(SEMANTIC_ENTAILMENT);
			setState(303);
			propositionalWff();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\26\u0134\4\2\t\2"+
		"\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3"+
		"\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\3\2\5\2a\n\2\3\3\3"+
		"\3\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5\3\5\5\5n\n\5\3\6\3\6\3\6\3\7\3\7\3"+
		"\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\t\3\n\3\n"+
		"\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\r\3\r\3\16\3"+
		"\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\5\16\u009e\n\16\3\17\3\17\3\17"+
		"\3\17\3\17\3\20\3\20\3\20\3\20\7\20\u00a9\n\20\f\20\16\20\u00ac\13\20"+
		"\3\20\3\20\7\20\u00b0\n\20\f\20\16\20\u00b3\13\20\6\20\u00b5\n\20\r\20"+
		"\16\20\u00b6\3\20\3\20\3\20\3\20\3\20\6\20\u00be\n\20\r\20\16\20\u00bf"+
		"\5\20\u00c2\n\20\3\21\3\21\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22\3\22"+
		"\5\22\u00cf\n\22\3\23\5\23\u00d2\n\23\3\23\3\23\5\23\u00d6\n\23\3\23\3"+
		"\23\3\24\3\24\3\24\3\25\3\25\3\25\3\25\3\25\3\25\3\26\3\26\3\26\3\26\3"+
		"\26\3\26\3\27\3\27\3\27\3\27\3\27\3\27\3\30\3\30\3\30\3\30\3\30\3\30\3"+
		"\31\3\31\3\31\3\31\3\31\3\31\3\32\3\32\5\32\u00fd\n\32\3\32\3\32\3\32"+
		"\5\32\u0102\n\32\3\33\3\33\3\33\3\33\5\33\u0108\n\33\3\34\3\34\3\35\6"+
		"\35\u010d\n\35\r\35\16\35\u010e\3\35\3\35\3\35\3\36\3\36\3\36\3\36\5\36"+
		"\u0118\n\36\3\37\3\37\3 \6 \u011d\n \r \16 \u011e\3 \3 \3 \3!\6!\u0125"+
		"\n!\r!\16!\u0126\3!\3!\3!\3\"\6\"\u012d\n\"\r\"\16\"\u012e\3\"\3\"\3\""+
		"\3\"\2\2#\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\66"+
		"8:<>@B\2\3\3\2\7\b\2\u0139\2`\3\2\2\2\4b\3\2\2\2\6d\3\2\2\2\bm\3\2\2\2"+
		"\no\3\2\2\2\fr\3\2\2\2\16x\3\2\2\2\20~\3\2\2\2\22\u0084\3\2\2\2\24\u008a"+
		"\3\2\2\2\26\u0090\3\2\2\2\30\u0092\3\2\2\2\32\u009d\3\2\2\2\34\u009f\3"+
		"\2\2\2\36\u00c1\3\2\2\2 \u00c3\3\2\2\2\"\u00ce\3\2\2\2$\u00d1\3\2\2\2"+
		"&\u00d9\3\2\2\2(\u00dc\3\2\2\2*\u00e2\3\2\2\2,\u00e8\3\2\2\2.\u00ee\3"+
		"\2\2\2\60\u00f4\3\2\2\2\62\u00fc\3\2\2\2\64\u0107\3\2\2\2\66\u0109\3\2"+
		"\2\28\u010c\3\2\2\2:\u0117\3\2\2\2<\u0119\3\2\2\2>\u011c\3\2\2\2@\u0124"+
		"\3\2\2\2B\u012c\3\2\2\2DE\58\35\2EF\7\2\2\3Fa\3\2\2\2GH\5> \2HI\7\2\2"+
		"\3Ia\3\2\2\2JK\5@!\2KL\7\2\2\3La\3\2\2\2MN\5B\"\2NO\7\2\2\3Oa\3\2\2\2"+
		"PQ\5\6\4\2QR\7\7\2\2RS\5\6\4\2ST\7\2\2\3Ta\3\2\2\2UV\5 \21\2VW\7\7\2\2"+
		"WX\5 \21\2XY\7\2\2\3Ya\3\2\2\2Z[\5\6\4\2[\\\7\2\2\3\\a\3\2\2\2]^\5 \21"+
		"\2^_\7\2\2\3_a\3\2\2\2`D\3\2\2\2`G\3\2\2\2`J\3\2\2\2`M\3\2\2\2`P\3\2\2"+
		"\2`U\3\2\2\2`Z\3\2\2\2`]\3\2\2\2a\3\3\2\2\2bc\7\20\2\2c\5\3\2\2\2de\5"+
		"\b\5\2e\7\3\2\2\2fn\5\4\3\2gn\5\n\6\2hn\5\f\7\2in\5\16\b\2jn\5\20\t\2"+
		"kn\5\22\n\2ln\5\24\13\2mf\3\2\2\2mg\3\2\2\2mh\3\2\2\2mi\3\2\2\2mj\3\2"+
		"\2\2mk\3\2\2\2ml\3\2\2\2n\t\3\2\2\2op\7\r\2\2pq\5\b\5\2q\13\3\2\2\2rs"+
		"\7\5\2\2st\5\b\5\2tu\7\t\2\2uv\5\b\5\2vw\7\6\2\2w\r\3\2\2\2xy\7\5\2\2"+
		"yz\5\b\5\2z{\7\n\2\2{|\5\b\5\2|}\7\6\2\2}\17\3\2\2\2~\177\7\5\2\2\177"+
		"\u0080\5\b\5\2\u0080\u0081\7\13\2\2\u0081\u0082\5\b\5\2\u0082\u0083\7"+
		"\6\2\2\u0083\21\3\2\2\2\u0084\u0085\7\5\2\2\u0085\u0086\5\b\5\2\u0086"+
		"\u0087\7\f\2\2\u0087\u0088\5\b\5\2\u0088\u0089\7\6\2\2\u0089\23\3\2\2"+
		"\2\u008a\u008b\7\5\2\2\u008b\u008c\5\b\5\2\u008c\u008d\7\16\2\2\u008d"+
		"\u008e\5\b\5\2\u008e\u008f\7\6\2\2\u008f\25\3\2\2\2\u0090\u0091\7\21\2"+
		"\2\u0091\27\3\2\2\2\u0092\u0093\7\22\2\2\u0093\31\3\2\2\2\u0094\u0095"+
		"\7\5\2\2\u0095\u0096\7\24\2\2\u0096\u0097\5\30\r\2\u0097\u0098\7\6\2\2"+
		"\u0098\u009e\3\2\2\2\u0099\u009a\7\5\2\2\u009a\u009b\5\30\r\2\u009b\u009c"+
		"\7\6\2\2\u009c\u009e\3\2\2\2\u009d\u0094\3\2\2\2\u009d\u0099\3\2\2\2\u009e"+
		"\33\3\2\2\2\u009f\u00a0\7\5\2\2\u00a0\u00a1\7\23\2\2\u00a1\u00a2\5\30"+
		"\r\2\u00a2\u00a3\7\6\2\2\u00a3\35\3\2\2\2\u00a4\u00a5\5\4\3\2\u00a5\u00b4"+
		"\7\5\2\2\u00a6\u00aa\5\26\f\2\u00a7\u00a9\7\7\2\2\u00a8\u00a7\3\2\2\2"+
		"\u00a9\u00ac\3\2\2\2\u00aa\u00a8\3\2\2\2\u00aa\u00ab\3\2\2\2\u00ab\u00b5"+
		"\3\2\2\2\u00ac\u00aa\3\2\2\2\u00ad\u00b1\5\30\r\2\u00ae\u00b0\7\7\2\2"+
		"\u00af\u00ae\3\2\2\2\u00b0\u00b3\3\2\2\2\u00b1\u00af\3\2\2\2\u00b1\u00b2"+
		"\3\2\2\2\u00b2\u00b5\3\2\2\2\u00b3\u00b1\3\2\2\2\u00b4\u00a6\3\2\2\2\u00b4"+
		"\u00ad\3\2\2\2\u00b5\u00b6\3\2\2\2\u00b6\u00b4\3\2\2\2\u00b6\u00b7\3\2"+
		"\2\2\u00b7\u00b8\3\2\2\2\u00b8\u00b9\7\6\2\2\u00b9\u00c2\3\2\2\2\u00ba"+
		"\u00bd\5\4\3\2\u00bb\u00be\5\26\f\2\u00bc\u00be\5\30\r\2\u00bd\u00bb\3"+
		"\2\2\2\u00bd\u00bc\3\2\2\2\u00be\u00bf\3\2\2\2\u00bf\u00bd\3\2\2\2\u00bf"+
		"\u00c0\3\2\2\2\u00c0\u00c2\3\2\2\2\u00c1\u00a4\3\2\2\2\u00c1\u00ba\3\2"+
		"\2\2\u00c2\37\3\2\2\2\u00c3\u00c4\5\"\22\2\u00c4!\3\2\2\2\u00c5\u00cf"+
		"\5\36\20\2\u00c6\u00cf\5&\24\2\u00c7\u00cf\5$\23\2\u00c8\u00cf\5(\25\2"+
		"\u00c9\u00cf\5*\26\2\u00ca\u00cf\5,\27\2\u00cb\u00cf\5.\30\2\u00cc\u00cf"+
		"\5\60\31\2\u00cd\u00cf\5\62\32\2\u00ce\u00c5\3\2\2\2\u00ce\u00c6\3\2\2"+
		"\2\u00ce\u00c7\3\2\2\2\u00ce\u00c8\3\2\2\2\u00ce\u00c9\3\2\2\2\u00ce\u00ca"+
		"\3\2\2\2\u00ce\u00cb\3\2\2\2\u00ce\u00cc\3\2\2\2\u00ce\u00cd\3\2\2\2\u00cf"+
		"#\3\2\2\2\u00d0\u00d2\7\r\2\2\u00d1\u00d0\3\2\2\2\u00d1\u00d2\3\2\2\2"+
		"\u00d2\u00d5\3\2\2\2\u00d3\u00d6\5\34\17\2\u00d4\u00d6\5\32\16\2\u00d5"+
		"\u00d3\3\2\2\2\u00d5\u00d4\3\2\2\2\u00d6\u00d7\3\2\2\2\u00d7\u00d8\5\""+
		"\22\2\u00d8%\3\2\2\2\u00d9\u00da\7\r\2\2\u00da\u00db\5\"\22\2\u00db\'"+
		"\3\2\2\2\u00dc\u00dd\7\5\2\2\u00dd\u00de\5\"\22\2\u00de\u00df\7\t\2\2"+
		"\u00df\u00e0\5\"\22\2\u00e0\u00e1\7\6\2\2\u00e1)\3\2\2\2\u00e2\u00e3\7"+
		"\5\2\2\u00e3\u00e4\5\"\22\2\u00e4\u00e5\7\n\2\2\u00e5\u00e6\5\"\22\2\u00e6"+
		"\u00e7\7\6\2\2\u00e7+\3\2\2\2\u00e8\u00e9\7\5\2\2\u00e9\u00ea\5\"\22\2"+
		"\u00ea\u00eb\7\13\2\2\u00eb\u00ec\5\"\22\2\u00ec\u00ed\7\6\2\2\u00ed-"+
		"\3\2\2\2\u00ee\u00ef\7\5\2\2\u00ef\u00f0\5\"\22\2\u00f0\u00f1\7\f\2\2"+
		"\u00f1\u00f2\5\"\22\2\u00f2\u00f3\7\6\2\2\u00f3/\3\2\2\2\u00f4\u00f5\7"+
		"\5\2\2\u00f5\u00f6\5\"\22\2\u00f6\u00f7\7\16\2\2\u00f7\u00f8\5\"\22\2"+
		"\u00f8\u00f9\7\6\2\2\u00f9\61\3\2\2\2\u00fa\u00fd\5\26\f\2\u00fb\u00fd"+
		"\5\30\r\2\u00fc\u00fa\3\2\2\2\u00fc\u00fb\3\2\2\2\u00fd\u00fe\3\2\2\2"+
		"\u00fe\u0101\7\17\2\2\u00ff\u0102\5\26\f\2\u0100\u0102\5\30\r\2\u0101"+
		"\u00ff\3\2\2\2\u0101\u0100\3\2\2\2\u0102\63\3\2\2\2\u0103\u0104\5 \21"+
		"\2\u0104\u0105\t\2\2\2\u0105\u0108\3\2\2\2\u0106\u0108\5 \21\2\u0107\u0103"+
		"\3\2\2\2\u0107\u0106\3\2\2\2\u0108\65\3\2\2\2\u0109\u010a\5 \21\2\u010a"+
		"\67\3\2\2\2\u010b\u010d\5\64\33\2\u010c\u010b\3\2\2\2\u010d\u010e\3\2"+
		"\2\2\u010e\u010c\3\2\2\2\u010e\u010f\3\2\2\2\u010f\u0110\3\2\2\2\u0110"+
		"\u0111\7\25\2\2\u0111\u0112\5\66\34\2\u01129\3\2\2\2\u0113\u0114\5\6\4"+
		"\2\u0114\u0115\t\2\2\2\u0115\u0118\3\2\2\2\u0116\u0118\5\6\4\2\u0117\u0113"+
		"\3\2\2\2\u0117\u0116\3\2\2\2\u0118;\3\2\2\2\u0119\u011a\5\6\4\2\u011a"+
		"=\3\2\2\2\u011b\u011d\5:\36\2\u011c\u011b\3\2\2\2\u011d\u011e\3\2\2\2"+
		"\u011e\u011c\3\2\2\2\u011e\u011f\3\2\2\2\u011f\u0120\3\2\2\2\u0120\u0121"+
		"\7\25\2\2\u0121\u0122\5<\37\2\u0122?\3\2\2\2\u0123\u0125\5\64\33\2\u0124"+
		"\u0123\3\2\2\2\u0125\u0126\3\2\2\2\u0126\u0124\3\2\2\2\u0126\u0127\3\2"+
		"\2\2\u0127\u0128\3\2\2\2\u0128\u0129\7\26\2\2\u0129\u012a\5 \21\2\u012a"+
		"A\3\2\2\2\u012b\u012d\5:\36\2\u012c\u012b\3\2\2\2\u012d\u012e\3\2\2\2"+
		"\u012e\u012c\3\2\2\2\u012e\u012f\3\2\2\2\u012f\u0130\3\2\2\2\u0130\u0131"+
		"\7\26\2\2\u0131\u0132\5\6\4\2\u0132C\3\2\2\2\27`m\u009d\u00aa\u00b1\u00b4"+
		"\u00b6\u00bd\u00bf\u00c1\u00ce\u00d1\u00d5\u00fc\u0101\u0107\u010e\u0117"+
		"\u011e\u0126\u012e";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}