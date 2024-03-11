namespace Business.ParserModels.Nodes
{
    public class ImpNode : WellFormedFormula
    {

        public ImpNode(string symbol) : base(symbol, NodeType.IMP)
        {
        }

        public ImpNode() : this("->")
        {            
        }

        public override string GetStringRep()
        {
            var left = GetChildAt(0);
            var right = GetChildAt(1);

            return $"({left.GetStringRep()} {Symbol} {right.GetStringRep()})";
        }

        public override bool IsValid()
        {
            return ChildrenSize() == 2;
        }

        public override bool IsCNFClausule()
        {
            return false;
        }

        public override bool Evaluate()
        {
            var left = GetChildAt(0);
            var right = GetChildAt(1);

            if(left.Evaluate() && !right.Evaluate())
            {
                return false;
            }

            return true;
        }

        public override WellFormedFormula Copy()
        {
            var node = new ImpNode(Symbol)
            {
                Flags = Flags
            };

            foreach (var child in Children)
            {
                node.AddChild(child.Copy());
            }

            return node;
        }
    }
}
