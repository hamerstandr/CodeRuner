using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime;

namespace CodeRuner.Compailer
{
    public class RecognitionException1 : Exception
    {

        public int OffendingState { get; protected set; }
        public virtual RuleContext Context { get; }
        public virtual IIntStream InputStream { get; }
        public IToken OffendingToken { get; protected set; }
        //public StartT
        public virtual IRecognizer Recognizer { get; }
        public object StartToken { get; }

    }
}
