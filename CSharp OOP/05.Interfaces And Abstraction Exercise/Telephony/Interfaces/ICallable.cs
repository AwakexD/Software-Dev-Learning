using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Interfaces
{
    public interface ICallable
    {
        string Call(string number);
    }
}
