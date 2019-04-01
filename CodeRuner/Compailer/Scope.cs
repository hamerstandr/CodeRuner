using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeRuner.Compailer
{
    public class Scope
    {
        public class Definition
        {
            public string SymbolName { get; set; }
            public string SymbolType { get; set; }
        }


        public Definition[] poshte;
        public int len = 1000;

        public Scope()
        {
            poshte = new Definition[1000];
        }


        // int top= 0;
        public void push(Definition x)
        {
            int i = 0;
            while (poshte[i] != null)
            {
                ++i;
            }

            if (i + 1 >= poshte.Length)
            {
                Array.Resize(ref poshte, poshte.Length * 2);
            }

            poshte[i] = x;
        }

        public Definition pop()
        {
            int i = 0;

            while (i != poshte.Length - 1 && poshte[i] != null)
            {
                i++;
            }
            Definition ret;
            ret = poshte[i - 1];
            poshte[i - 1] = null;
            return ret;
        }
        public Definition FindSymbol(string x)
        {
            //Console.WriteLine("FindSymbol");
            x = x.ToLower();
            int top = 0;
            while (poshte[top] != null)
            {
                ++top;
            }
            //Console.WriteLine(top);

            for (int i = 1; i <= top; i++)
                //if(poshte[top - i]!=null)
                if (poshte[top - i].SymbolName == x)
                    return poshte[top - i];
            return null;
        }
        public bool FindInScope(string x, string typ)
        {
            //Console.WriteLine("FindInScope");
            x = x.ToLower();
            int top = 0;
            while (poshte[top] != null)
            {
                ++top;
            }
            //Console.WriteLine(top);

            for (int i = top - 1; i >= 0; i--)
            //if(poshte[top - i]!=null)
            {
                if (poshte[i].SymbolName == "scopesymbol"/* | (poshte[i].SymbolType == "function" && typ != "function")*/) break;
                if (poshte[i].SymbolName == x)
                {
                    System.Console.WriteLine(typ + " Redefinition!");
                    return false;
                }
            }
            return true;
        }



        /// <summary>
        /// Keep symbol definitions
        /// Dictionary is the .Net generic implementation of hashtable.
        /// The symbol definitions are accessible using their name. 
        /// </summary>
        Dictionary<string, Definition> Symbols = new Dictionary<string, Definition>();
        //System.Collections.Stack stack;
        // Stack stack;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SymbolName"></param>
        /// <returns></returns>



        public void AddSymbol(string SymbolName, string type)
        {
            SymbolName = SymbolName.ToLower();
            //Console.Beep();
            //Console.WriteLine("AddSymbol");
            //if (FindSymbol(SymbolName) != null)
            //   throw new Exception("Duplicate Symbol Definition!");
            //Symbols[SymbolName] = (new Definition()
            //{
            //    SymbolName = SymbolName,
            //    SymbolType = type
            //});
            push(new Definition()
            {
                SymbolName = SymbolName,
                SymbolType = type
            });
        }
        public class Stack
        {
            private string[] s;
            public int length;
            public Stack(int N)
            {
                s = new string[N];
            }

            public void push(string x)
            {
                int i = 0;
                while (s[i] != null)
                {
                    ++i;
                }

                if (i + 1 >= s.Length)
                {
                    Array.Resize(ref s, s.Length * 2);
                }

                s[i] = x;
            }

            public string pop()
            {
                int i = 0;

                while (i != s.Length && s[i] != null)
                {
                    i++;
                }

                s[i] = null;
                return s[i - 1];
            }


        }



        // sc.SymbolName = "ScopeSymbol";
        /// <summary>
        /// This is not required here.
        /// </summary>
        public void EnterScope()
        {

            //         throw new NotImplementedException();


            //Console.WriteLine("Sc0peSymbol");
            AddSymbol("ScopeSymbol", "scopesymbol");
            //push(sc);
        }

        /// <summary>
        /// This is not required here.
        /// </summary>
        public void ExitScope()
        {
            //System.Console.Beep();
            //Console.WriteLine("\n*******\n");
            while (pop().SymbolName != "scopesymbol") ;
            //    throw new NotImplementedException();
        }
        public void ExitFunc()
        {
            //System.Console.Beep();
            //Console.WriteLine("\n*******\n");
            while (true)
            {
                Definition s = pop();
                if (s.SymbolType == "function")
                {
                    AddSymbol(s.SymbolName, s.SymbolType);
                    break;
                }
            }
            ;
            //    throw new NotImplementedException();
        }

    }
}
