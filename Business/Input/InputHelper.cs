namespace Business.Input
{
    public class InputHelper
    {
        readonly Dictionary<string, string> _specialSymbols = new();

        public InputHelper()
        {            
            InitializeSpecialSymbols();
        }

        public Dictionary<string, List<string>> GetKeyboardSymbols()
        {
            var result = new Dictionary<string, List<string>>();
            var atoms = "A,B,C,D,E,F";
            var predicates = "P,Q,R,S,T,U";
            var variables = "x,y,z,u,v,w";

            result.Add("Spojky", _specialSymbols.Values.ToList());
            result.Add("Atomické formuly", atoms.Split(',').ToList());
            result.Add("Predikáty", predicates.Split(',').ToList());
            result.Add("Premenné", variables.Split(",").ToList());

            return result;
        }

        private void InitializeSpecialSymbols()
        {
            _specialSymbols.Clear();

            _specialSymbols.Add("and", "∧");
            _specialSymbols.Add("or", "∨");
            _specialSymbols.Add("not", "¬");
            _specialSymbols.Add("implies", "->");
            _specialSymbols.Add("iff", "<->");
            _specialSymbols.Add("forall", "∀");
            _specialSymbols.Add("exists", "∃");
            _specialSymbols.Add("(", "(");
            _specialSymbols.Add(")", ")");
        }

        public string TransformInput(string input)
        {
            input = input.Trim();
            foreach (var symbol in _specialSymbols)
            {
                input = input.Replace(symbol.Key, symbol.Value);
            }
            
            return input;
        }

        public string TransformToOutput(string input)
        {
            input = input.Trim();
            foreach (var symbol in _specialSymbols)
            {
                input = input.Replace(symbol.Value, symbol.Key);
            }

            return input;
        }
    }
}
