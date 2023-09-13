using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFL
{
    public class FirstTask
    {
        private List<string> _alphabet;
        private List<XaxatNtbI> _states;
        public FirstTask()
        {
            using (StreamReader sr = new("./path.txt"))
            {
                string[] input = sr.ReadLine().Split(' ');
                _alphabet = new List<string>(input);
                input = sr.ReadLine().Split(' ');
                _states = new List<XaxatNtbI>();
                foreach (var line in input)
                {
                    XaxatNtbI tmp = new();
                    if(line.Contains("$*"))
                    {
                        var st1 = line.Split("$*");
                        tmp.IsStart = true;
                        tmp.IsAccept = true;
                        tmp.Name = st1[0];
                        _states.Add(tmp);
                    }
                    else if (line.Contains("*"))
                    {
                        var st1 = line.Split("*");
                        tmp.IsAccept = true;
                        tmp.Name = st1[0];
                        _states.Add(tmp);
                    }
                    else if (line.Contains("$"))
                    {
                        var st1 = line.Split("$");
                        tmp.IsStart = true;
                        tmp.Name = st1[0];
                        _states.Add(tmp);
                    }
                    else if (!line.Contains('*') && !line.Contains('$'))
                    {
                        tmp.Name = line;
                        _states.Add(tmp);
                    }
                }
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    var s = str.Split();
                    foreach (var st in _states)
                    {
                        if (st.Name == s[0][0].ToString())
                        {
                            for (int i = 1; i <= _alphabet.Count; i++)
                            {
                                if (s.Length > i && !string.IsNullOrEmpty(s[i]))
                                {
                                    st.Path.Add(s[i][0].ToString(), _states[Int32.Parse(s[i][2].ToString()) - 1]);
                                }
                            }
                        }
                    }
                }
            }
        }

        public List<XaxatNtbI> GetStartStates()
        {
            List<XaxatNtbI> states = new List<XaxatNtbI>();
            foreach (var state in _states)
            {
                if (state.IsStart)
                {
                    states.Add(state);
                }
            }

            return states;
        }

        public void ShowDFA()
        {
            Console.Write("\t");
            foreach (var symbol in _alphabet)
            {
                Console.Write("\t{0}", symbol);
            }
            Console.WriteLine();
            foreach (var state in _states)
            {
                Console.Write("\t");
                Console.Write(state.Name[0]);
                if (state.IsStart)
                {
                    Console.Write("->");
                }
                if (state.IsAccept)
                {
                    Console.Write("*");
                }
                foreach (var trans in state.Path)
                {
                    Console.Write("\t({0},{1})", trans.Key, trans.Value.Name);
                }
                Console.WriteLine();
            }

        }

        public bool? Run(IEnumerable<char> s)
        {
            Console.WriteLine("Chain: {0}", s.ToString());
            var startStates = GetStartStates();
            foreach (var state in startStates)
            {
                var current = state;
                foreach (var c in s)
                {
                    if (current.Path.ContainsKey(c.ToString()))
                    {
                        Console.WriteLine("Symbol - {0}, current state - {1}, transition to state {2}", c, current.Name, current.Path[c.ToString()].Name);
                        current = current.Path[c.ToString()];
                        if (current == null)
                            return null;
                    }
                    else
                    {
                        return null;
                    }

                }
                if (current.IsAccept)
                {
                    Console.WriteLine("True");
                }
                return current.IsAccept;
            }
            return null;
        }
    }
}
