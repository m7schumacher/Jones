﻿using Jones.Domain.Commands;
using Swiss.Utilities.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Triggers
{
    public class Reflex : Trigger
    {
        Func<string> Method { get; set; }

        #region Constructors

        public Reflex(Func<string> method, BasicCommand command) : base(command)
        {
            Method = method;
        }

        public Reflex(Func<string> method, List<BasicCommand> commands) : base(commands)
        {
            Method = method;
        }

        public Reflex(Func<string> method, params string[] phrases) : base(phrases)
        {
            Method = method;
        }

        #endregion

        public override string GetResult()
        {
            return Method.Invoke();
        }
    }
}
