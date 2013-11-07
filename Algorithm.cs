
using System;
namespace TextManipulationUtility
{
    class Algorithm
    {
        private Func<string, string> apply;

        public Algorithm(string group, string name, Func<string, string> apply)
        {
            this.Group = group;
            this.Name = name;
            this.apply = apply;
        }

        public string Group { get; private set; }
        public string Name { get; private set; }

        public string Apply(string input)
        {
            return apply(input);
        }
    }
}
