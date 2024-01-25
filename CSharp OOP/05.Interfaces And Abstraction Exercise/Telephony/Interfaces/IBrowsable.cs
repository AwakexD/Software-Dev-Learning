using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Interfaces
{
    public interface IBrowsable : ICallable
    {
        string Browse(string URL);
    }
}
