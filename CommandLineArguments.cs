namespace TextManipulationUtility
{
    using System;
    using System.Collections.Generic;

    class CommandLineArguments
    {
        private Dictionary<string, List<string>> options = new Dictionary<string, List<string>>();
        private string errorMessage = "";

        public CommandLineArguments(string[] args)
        {
            try
            {
                for (var index = 0; index < args.Length; )
                {
                    switch (args[index])
                    {
                        case "-f":
                        case "--function":
                            AddOption(args, ref index, "function");
                            break;

                        case "-i":
                        case "--input-file":
                            AddOption(args, ref index, "input-file");
                            break;

                        case "-p":
                        case "--param":
                            AddOption(args, ref index, "param");
                            break;

                        default:
                            AddInput(args, ref index, "input");
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
        }

        private void AddOption(string[] args, ref int index, string name)
        {
            if ((index + 1) < args.Length)
            {
                if (!options.ContainsKey(name))
                {
                    options[name] = new List<string>();
                }

                options[name].Add(args[index + 1]);

                index += 2;
            }
            else
            {
                throw new ArgumentException(name + " specified without an option value");
            }
        }

        private void AddInput(string[] args, ref int index, string name)
        {
            if (!options.ContainsKey(name))
            {
                options[name] = new List<string>();
            }

            options[name].Add(args[index]);

            ++index;
        }

        public List<string> this[string name]
        {
            get
            {
                if (options.ContainsKey(name))
                {
                    return options[name];
                }
                else
                {
                    return new List<string>();
                }
            }
        }
    }
}
