namespace Business.ParserModels.Nodes
{
    public class IdentityNode : WellFormedFormula
    {
        public IdentityNode() : base("=", NodeType.IDENTITY)
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

        public override WellFormedFormula Copy()
        {
            var node = new IdentityNode()
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
