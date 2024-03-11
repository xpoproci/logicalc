namespace Business.ParserModels
{
    public static class NodeFlag
    {
        public static readonly int PROPOSITIONAL = 0x00000001;

        public static readonly int PREDICATE = 0x00000010;

        public static readonly int IDENTITY = 0x00001000;

        public static readonly int CLOSED = 0x00010000;

        public static readonly int STOP_CLOSE_CHECK = 0x00100000;

        public static readonly int HIGHLIGHT = 0x01000000;

        public static readonly int CNF = 0x10000000;

        public static readonly int DNF = 0x00000100;
    }
}
