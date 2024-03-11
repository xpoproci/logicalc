namespace Business.ParserModels.Nodes
{
    public class AtomNode : WellFormedFormula, IComparable<AtomNode>
    {
        private readonly string _currentlyUsedSymbol;

        private bool _truthValue = true;

        public AtomNode(string symbol) : base(NodeType.ATOM)
        {
            Symbol = symbol;
            _currentlyUsedSymbol = symbol;
        }

        public override string GetStringRep()
        {
            return _currentlyUsedSymbol;
        }

        public override bool Evaluate()
        {
            return _truthValue;
        }

        public void SetTruthValue(bool t)
        {
            _truthValue = t;
        }

        public string GetTruthValue()
        {
            return _truthValue ? "1" : "0";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            AtomNode other = (AtomNode)obj;
            return _currentlyUsedSymbol == other._currentlyUsedSymbol;
        }

        public override int GetHashCode()
        {
            return _currentlyUsedSymbol != null ? _currentlyUsedSymbol.GetHashCode() : 0;
        }

        public override bool IsValid() => _currentlyUsedSymbol != null && ChildrenSize() == 0;

        public override WellFormedFormula Copy()
        {
            var node = new AtomNode(_currentlyUsedSymbol)
            {
                Flags = Flags
            };
            return node;
        }

        public override string ToString()
        {
            return $"{base.ToString()}: {_currentlyUsedSymbol}";
        }

        public int CompareTo(AtomNode? other)
        {
            return Equals(other) ? 0 : 1;
        }
    }
}
