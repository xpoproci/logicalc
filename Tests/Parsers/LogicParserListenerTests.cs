using Business.Input;

namespace Tests.Parsers
{
    public class LogicParserListenerTests
    {

        [Theory]
        [InlineData("¬ P", "¬P")]
        [InlineData("((P & Q)&B)", "((P ∧ Q) ∧ B)")]
        [InlineData("(A and B)", "(A ∧ B)")]
        [InlineData("(A ∧ B)", "(A ∧ B)")]
        [InlineData("(A or B)", "(A ∨ B)")]
        [InlineData("(A ∨ B)", "(A ∨ B)")]
        [InlineData("(A|B)", "(A ∨ B)")]
        [InlineData("((P | Q)|B)", "((P ∨ Q) ∨ B)")]
        [InlineData("(((¬P -> Q)<->B)&C)", "(((¬P -> Q) <-> B) ∧ C)")]
        [InlineData("(((P -> Q)<->B)&C)", "(((P -> Q) <-> B) ∧ C)")]
        public void TestPropositionalLogicListenerWithCorrectSimpleWffs(string input, string excepted)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);
            Assert.True(trees.ElementAt(0).IsPropositionalWff());

            var result = trees.ElementAt(0).GetStringRep();
            Assert.Equal(excepted, result);
        }

        [Theory]
        [InlineData("(forall x)(P(x) & Q(x))", "(∀x)(P(x) ∧ Q(x))")]
        [InlineData("P(x)", "P(x)")]
        [InlineData("¬P(x)", "¬P(x)")]
        [InlineData("¬(exists y)(R(y) -> S(y))", "¬(∃y)(R(y) -> S(y))")]
        [InlineData("(exists x)(P(x) or (forall y)(R(y) & S(y)))", "(∃x)(P(x) ∨ (∀y)(R(y) ∧ S(y)))")]
        [InlineData("¬(forall x)(¬(P(x) or Q(x)) and (exists y)(R(y) or ¬S(y)))", "¬(∀x)(¬(P(x) ∨ Q(x)) ∧ (∃y)(R(y) ∨ ¬S(y)))")]
        [InlineData("¬(exists x)¬(P(x) -> (forall y)(Q(y) & (¬R(x, y) or S(x))))", "¬(∃x)¬(P(x) -> (∀y)(Q(y) ∧ (¬R(x,y) ∨ S(x))))")]
        [InlineData("¬(∃x)¬(P(x) -> (∀y)(Q(y) ∧ (¬R(x,y) ∨ S(x))))", "¬(∃x)¬(P(x) -> (∀y)(Q(y) ∧ (¬R(x,y) ∨ S(x))))")]
        public void TestPredicateLogicListenerWithCorrectSimpleWffs(string input, string excepted)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);
            Assert.True(trees.ElementAt(0).IsPredicateWff());
            Assert.True(trees.ElementAt(0).IsValid());

            var result = trees.ElementAt(0).GetStringRep();
            Assert.Equal(excepted, result);
        }

        [Theory]
        [InlineData("¬P", true)]
        [InlineData("P", true)]
        [InlineData("(P | Q)", true)]
        [InlineData("((P | Q) | R)", true)]
        [InlineData("((¬P | Q) | R)", true)]
        public void TestPropositionalLogicListenerWithCorrectCNFWffs(string input, bool excepted)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);
            Assert.True(trees.ElementAt(0).IsPropositionalWff());
            Assert.True(trees.ElementAt(0).IsValid());
            Assert.Equal(excepted, trees.ElementAt(0).IsCNFClausule());

            var result = trees.ElementAt(0).GetStringRep();
        }
    }
}
