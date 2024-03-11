using Antlr4.Runtime;
using Business.Helpers;

namespace Tests.Parsers
{
    public class LogicParserAntlrTests
    {
        [Theory]
        [InlineData("(P & Q)", true)]
        [InlineData("!(!P & Q)", true)]
        [InlineData("(P & Q))", false)]
        [InlineData("(P &) Q)", false)]
        [InlineData("not P", true)]
        [InlineData("(P & Q);(P & Q)entailsP", true)]
        public void ParsesExpression(string input, bool shouldSucceed)
        {
            var errorListener = new ErrorListener();
            Parse(input, errorListener);

            Assert.Equal(shouldSucceed, errorListener.Exception == null);
        }

        [Theory]
        [InlineData("")]
        [InlineData("(")]
        [InlineData("P &")]
        [InlineData("not")]
        [InlineData("(A & ((P&B)<->Q))entailsP(x) & x")]
        public void FailsToParseInvalidExpression(string input)
        {
            var errorListener = new ErrorListener();
            Parse(input, errorListener);

            Assert.NotNull(errorListener.Exception);
        }

        private static void Parse(string input, ErrorListener errorListener)
        {
            var stream = CharStreams.fromString(input);
            var lexer = new LogicLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new LogicParser(tokens);

            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);
            parser.program();
        }
    }
}
