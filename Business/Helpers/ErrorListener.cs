using Antlr4.Runtime;

namespace Business.Helpers
{
    public class ErrorListener : BaseErrorListener
    {
        public string? ErrorMessage { get; private set; }
        public RecognitionException? Exception { get; private set; }

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Exception = e;
            ErrorMessage = msg;
        }
    }
}
