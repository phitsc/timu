namespace TextManipulationUtility
{
    using System;

    internal class Algorithm
    {
        private Func<string, string, string> apply;

        public Algorithm(string group, string name, bool requiresParam, string inputHint, string paramHint, Func<string, string, string> apply)
        {
            this.Group = group;
            this.Name = name;
            this.RequiresParam = requiresParam;
            this.InputHint = inputHint;
            this.ParamHint = paramHint;
            this.apply = apply;
        }

        public string Group { get; private set; }

        public string Name { get; private set; }

        public bool RequiresParam { get; private set; }

        public string InputHint { get; private set; }
        
        public string ParamHint { get; private set; }

        public string Apply(string input, string param)
        {
            return this.apply(input, param);
        }
    }
}
