using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Business.Helpers;
using Business.ParserModels;

namespace Business.Input
{
    public class LogicParserAdapter
    {
        public bool IsValid { get; set; } = true;

        public List<WellFormedFormula> GetAbstractSyntaxTree(string wff)
        {
            var parser = ParseStream(wff);
            var result = parser.GetSyntaxTrees();
            
            if(result.Count == 0) {
                IsValid = false;
            }
            else
            {
                IsValid = true;
            }

            return result.ToList();
        }

        private static LogicParserListener ParseStream(string input)
        {
            var charStream = CharStreams.fromString(input);
            var lexer = new LogicLexer(charStream);
            var errorListener = new ErrorListener();

            // Connect token stream to lexer
            var tokens = new CommonTokenStream(lexer);

            // Connect parser to token stream
            var parser = new LogicParser(tokens);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);
            var tree = parser.program();

            // Now do the parsing, and walk the parse tree with our listeners
            var walker = new ParseTreeWalker();
            var compiler = new LogicParserListener(parser);
            walker.Walk(compiler, tree);

            return compiler;
        }
    }
}
