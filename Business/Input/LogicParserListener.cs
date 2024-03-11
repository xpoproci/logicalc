using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Business.ParserModels;
using Business.ParserModels.Nodes;

namespace Business.Input
{
    public class LogicParserListener : LogicBaseListener
    {
        private readonly ParseTreeProperty<WellFormedFormula> _parseTree;

        private readonly LogicParser _parser;

        private readonly Stack<WellFormedFormula> _treeRoots;

        private readonly LinkedList<WellFormedFormula> _currentTrees;

        private WellFormedFormula _tree = new();

        public LogicParserListener(LogicParser parser) : base()
        {
            _parser = parser;
            _parseTree = new();
            _treeRoots = new();
            _currentTrees = new();
        }

        #region Propositional
        public override void EnterPropositionalWff([NotNull] LogicParser.PropositionalWffContext context)
        {
            if (_tree.IsPredicateWff())
            {
                throw new ArgumentException("Cannot be propositional and predicate at the same time");
            }

            _tree.Flags = NodeFlag.PROPOSITIONAL;
        }

        public override void ExitPropositionalWff([NotNull] LogicParser.PropositionalWffContext context)
        {
            _currentTrees.AddLast(_tree.Copy());
        }

        public override void EnterAtom([NotNull] LogicParser.AtomContext context)
        {
            var node = new AtomNode(context.ATOM().GetText());
            _parseTree.Put(context, node);
        }

        public override void ExitPropWff([NotNull] LogicParser.PropWffContext context)
        {
            if(context.atom() != null)
            {
                _tree.AddChild(_parseTree.Get(context.atom()));
            }
        }

        public override void EnterPropNegRule([NotNull] LogicParser.PropNegRuleContext context)
        {
            var negNode = new NegNode();
            _treeRoots.Push(_tree);
            _tree = negNode;
        }

        public override void ExitPropNegRule([NotNull] LogicParser.PropNegRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPropAndRule([NotNull] LogicParser.PropAndRuleContext context)
        {
            var node = new AndNode();
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPropAndRule([NotNull] LogicParser.PropAndRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPropOrRule([NotNull] LogicParser.PropOrRuleContext context)
        {
            var node = new OrNode();
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPropOrRule([NotNull] LogicParser.PropOrRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPropImpRule([NotNull] LogicParser.PropImpRuleContext context)
        {
            var node = new ImpNode();
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPropImpRule([NotNull] LogicParser.PropImpRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPropBicondRule([NotNull] LogicParser.PropBicondRuleContext context)
        {
            var node = new BicondNode();
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPropBicondRule([NotNull] LogicParser.PropBicondRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPropExclusiveOrRule([NotNull] LogicParser.PropExclusiveOrRuleContext context)
        {
            var node = new XorNode(context.XOR().GetText());
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPropExclusiveOrRule([NotNull] LogicParser.PropExclusiveOrRuleContext context)
        {
            PopTreeRoot();
        }
        #endregion


        #region Predicate
        public override void EnterPredicateWff([NotNull] LogicParser.PredicateWffContext context)
        {
            if (_tree.IsPropositionalWff())
            {
                throw new ArgumentException("Cannot be propositional and predicate at the same time");
            }
            _tree.Flags = NodeFlag.PREDICATE;
        }

        public override void ExitPredicateWff([NotNull] LogicParser.PredicateWffContext context)
        {
            _currentTrees.AddLast(_tree.Copy());
        }

        public override void ExitPredicate([NotNull] LogicParser.PredicateContext context)
        {
            var test = _parseTree.Get(context.atom());
            var node = (AtomNode)_parseTree.Get(context.atom());

            var parameters = new LinkedList<WellFormedFormula>();
            for (int i = 1; i < context.ChildCount; i++)
            {
                parameters.AddLast(_parseTree.Get(context.GetChild(i)));
            }

            var atomLetter = node.ToString().Replace("ATOM: ", "");
            var predicate = new PredicateNode(atomLetter, parameters);
            _tree.AddChild(predicate);
        }

        public override void EnterConstant([NotNull] LogicParser.ConstantContext context)
        {
            var node = new ConstantNode(context.CONSTANT().GetText());
            _parseTree.Put(context, node);
        }

        public override void EnterVariable([NotNull] LogicParser.VariableContext context)
        {
            var node = new VariableNode(context.VARIABLE().GetText());
            _parseTree.Put(context, node);
        }

        public override void ExitPredQuantifier([NotNull] LogicParser.PredQuantifierContext context)
        {
            PopTreeRoot();
        }

        public override void ExitUniversal([NotNull] LogicParser.UniversalContext context)
        {
            VariableNode node;
            if(context.variable()!= null)
            {
                node = (VariableNode)_parseTree.Get(context.variable());
            }
            else
            {
                throw new ArgumentException("missing variable for quantifier");
            }

            var uqn = new UniversalQunatifierNode(node.Symbol);
            _treeRoots.Push(_tree);
            _tree = uqn;
        }

        public override void ExitExistential([NotNull] LogicParser.ExistentialContext context)
        {
            VariableNode node;
            if (context.variable() != null)
            {
                node = (VariableNode)_parseTree.Get(context.variable());
            }
            else
            {
                throw new ArgumentException("missing variable for quantifier");
            }

            var eqn = new ExistentialQuantifierNode(node.Symbol);
            _treeRoots.Push(_tree);
            _tree = eqn;
        }

        public override void EnterPredNegRule([NotNull] LogicParser.PredNegRuleContext context)
        {
            var node = new NegNode();
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPredNegRule([NotNull] LogicParser.PredNegRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPredAndRule([NotNull] LogicParser.PredAndRuleContext context)
        {
            var node = new AndNode();
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPredAndRule([NotNull] LogicParser.PredAndRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPredOrRule([NotNull] LogicParser.PredOrRuleContext context)
        {
            var node = new OrNode();
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPredOrRule([NotNull] LogicParser.PredOrRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPredImpRule([NotNull] LogicParser.PredImpRuleContext context)
        {
            var node = new ImpNode();
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPredImpRule([NotNull] LogicParser.PredImpRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPredBicondRule([NotNull] LogicParser.PredBicondRuleContext context)
        {
            var node = new BicondNode();
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPredBicondRule([NotNull] LogicParser.PredBicondRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPredExclusiveOrRule([NotNull] LogicParser.PredExclusiveOrRuleContext context)
        {
            var node = new XorNode(context.XOR().GetText());
            _treeRoots.Push(_tree);
            _tree = node;
        }

        public override void ExitPredExclusiveOrRule([NotNull] LogicParser.PredExclusiveOrRuleContext context)
        {
            PopTreeRoot();
        }

        public override void EnterPredIdentityRule([NotNull] LogicParser.PredIdentityRuleContext context)
        {
            var node = new IdentityNode();
            node.AddChild(_parseTree.Get(context.GetChild(0)));
            node.AddChild(_parseTree.Get(context.GetChild(2)));

            _tree.AddChild(node);
        }
        #endregion

        public LinkedList<WellFormedFormula> GetSyntaxTrees()
        {
            return _currentTrees;
        }

        private void PopTreeRoot()
        {
            WellFormedFormula oldRoot = _treeRoots.Pop(); // Remove the old root from the stack.
            oldRoot.AddChild(_tree); // Add the current running-node as a child of the old root.
            _tree = oldRoot; // Reassign the root to be the old one.
        }
    }
}
