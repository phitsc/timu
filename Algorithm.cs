namespace TextManipulationUtility
{
    using System;
using System.Collections.Generic;

    internal class Algorithm
    {
        private Func<string /*input*/, List<string> /*parameters*/, bool /*ignoreCase*/, bool /*reverseOutputDirection*/, string /*result*/> apply;

        public Algorithm(string group, string name, string inputHint, Func<string, List<string>, bool, bool, string> apply)
        {
            this.Group = group;
            this.Name = name;
            this.InputHint = inputHint;
            this.ParamHints = new List<string>();
            this.apply = apply;
        }

        public Algorithm(string group, string name, string inputHint, List<string> paramHints, Func<string, List<string>, bool, bool, string> apply)
        {
            this.Group = group;
            this.Name = name;
            this.InputHint = inputHint;
            this.ParamHints = paramHints;
            this.apply = apply;
        }

        public string Group { get; private set; }

        public string Name { get; private set; }

        public string InputHint { get; private set; }
        
        public List<string> ParamHints { get; private set; }

        public string Apply(string input, List<string> parameters, bool ignoreCase, bool reverseOutputDirection)
        {
            return this.apply(input, parameters, ignoreCase, reverseOutputDirection);
        }
    }
}
