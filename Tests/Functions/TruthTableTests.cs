using Business.Functions;
using Business.Input;
namespace Tests.Functions
{
    public class TruthTableTests
    {
        [Theory]
        [InlineData("not P", 1)]
        [InlineData("(A or B)", 2)]
        [InlineData("(A or (B or C))", 3)]
        public void TestGetAtoms(string input, int count)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            var node = trees.ElementAt(0);
            Assert.True(node.IsPropositionalWff());

            var atoms = node.GetAtoms();

            Assert.Equal(count, atoms.Count);
        }

        [Theory]
        [InlineData("not P", 1)]
        [InlineData("(A or B)", 2)]
        [InlineData("(A or (B or C))", 3)]
        [InlineData("((A or (B or C)) & C)", 3)]
        public void TestAtomsTruthValueDistribution(string input, int count)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            var node = trees.ElementAt(0);
            Assert.True(node.IsPropositionalWff());

            var tt = new TruthTable(node);
            tt.GenerateTruthTable();
        }

        [Theory]
        [InlineData("(A or !A)", true)]
        [InlineData("((A -> B) or (B->A))", true)]
        [InlineData("(((A -> B) and (B  -> C)) -> (A  -> C))", true)]
        [InlineData("A", false)]
        [InlineData("!A", false)]
        [InlineData("!(A and !A)", true)]
        [InlineData("!((A and B) and !(A and B))", true)]
        [InlineData("!((A or B) and (!A and !B))", true)]
        [InlineData("!((A -> B) and (A and !B))", true)]
        [InlineData("!((A <-> B) and (A and !B))", true)]
        [InlineData("!((A <-> B) and (B and !A))", true)]
        public void TestTautology(string input, bool expected)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            var node = trees.ElementAt(0);
            Assert.True(node.IsPropositionalWff());

            var tt = new TruthTable(node);
            tt.GenerateTruthTable();

            Assert.Equal(expected, tt.Tautology);
        }

        [Theory]
        [InlineData("(A or !A)", true)]
        [InlineData("((A -> B) or (B->A))", true)]
        [InlineData("(((A -> B) and (B  -> C)) -> (A  -> C))", true)]
        [InlineData("A", false)]
        [InlineData("!A", false)]
        [InlineData("!(A and !A)", true)]
        [InlineData("!((A and B) and !(A and B))", true)]
        [InlineData("!((A or B) and (!A and !B))", true)]
        [InlineData("!((A -> B) and (A and !B))", true)]
        [InlineData("!((A <-> B) and (A and !B))", true)]
        [InlineData("!((A <-> B) and (B and !A))", true)]
        public void TestUCNFClausule(string input, bool expected)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            var node = trees.ElementAt(0);
            Assert.True(node.IsPropositionalWff());

            var tt = new TruthTable(node);
            tt.GenerateTruthTable();

            var c = tt.GetUCNFClausule(true);
            c.FixLiteralsValues();

            Assert.Equal(expected, tt.Tautology);
            Assert.Equal(c.Clausules.Count == 0, expected);
        }

        [Theory]
        [InlineData("A", false)]
        [InlineData("!A", false)]
        [InlineData("((!A | B) | C)", false)]
        [InlineData("((!A & B) & C)", false)]
        public void TestUCNFClausuleFromTree(string input, bool expected)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            var node = trees.ElementAt(0);
            Assert.True(node.IsPropositionalWff());

            var tt = new TruthTable(node);
            tt.GenerateTruthTable();

            var c = tt.GetUCNFClausule();

            Assert.Equal(expected, tt.Tautology);
            Assert.Equal(c.Clausules.Count == 0, expected);
        }

        [Theory]
        [InlineData("(A and !A)", false)] // Unsatisfiable, negation is satisfiable
        [InlineData("((A and B) and !(A and B))", false)] // Unsatisfiable, negation is satisfiable
        [InlineData("((A or B) and (!A and !B))", false)] // Unsatisfiable, negation is satisfiable
        [InlineData("((A -> B) and (A and !B))", false)] // Unsatisfiable, negation is satisfiable
        [InlineData("((A <-> B) and (A and !B))", false)] // Unsatisfiable, negation is satisfiable
        [InlineData("((A <-> B) and (B and !A))", false)] // Unsatisfiable, negation is satisfiable
        [InlineData("A", true)] // Always satisfiable
        [InlineData("(A or !A)", true)] // Law of excluded middle, always satisfiable
        [InlineData("((A and B) or !(A and B))", true)] // Law of excluded middle, always satisfiable
        [InlineData("((A -> B) or !(A -> B))", true)] // Law of excluded middle, always satisfiable
        [InlineData("((A <-> B) or !(A <-> B))", true)] // Law of excluded middle, always satisfiable
        public void TestSatisfiability(string input, bool expected)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            var node = trees.ElementAt(0);
            Assert.True(node.IsPropositionalWff());

            var tt = new TruthTable(node);
            tt.GenerateTruthTable();

            Assert.Equal(expected, tt.Solvable);
        }

        [Theory]
        [InlineData("!(A or !A)", true)]
        [InlineData("!((A -> B) or (B->A))", true)]
        [InlineData("(A and !A)", true)]
        [InlineData("((A and B) and !(A and B))", true)]
        [InlineData("((A or B) and (!A and !B))", true)] 
        [InlineData("((A -> B) and (A and !B))", true)]
        [InlineData("((A <-> B) and (A and !B))", true)]
        [InlineData("((A <-> B) and (B and !A))", true)]
        public void TestContradiction(string input, bool expected) {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            var node = trees.ElementAt(0);
            Assert.True(node.IsPropositionalWff());

            var tt = new TruthTable(node);
            tt.GenerateTruthTable();

            Assert.Equal(expected, tt.Contradiction);
        }

        [Theory]
        [InlineData("((A and B) and !(A and B))", "((A and B) and !(A and B))", true)]
        [InlineData("((A and B) and !(A and B))", "!((A -> B) or (B -> A))", true)]
        [InlineData("((A and B) and C)", "!((A -> B) or (B -> A))", false)]
        [InlineData("(A and B)", "(B or A)", false)]
        public void TestEquivalency(string input, string input2, bool expected)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            var node = trees.ElementAt(0);
            Assert.True(node.IsPropositionalWff());

            var tt1 = new TruthTable(node);

            trees = adapter.GetAbstractSyntaxTree(input2);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            node = trees.ElementAt(0);
            Assert.True(node.IsPropositionalWff());

            Assert.Equal(expected, tt1.IsEquivalentFormula(node));
        }
    }
}
