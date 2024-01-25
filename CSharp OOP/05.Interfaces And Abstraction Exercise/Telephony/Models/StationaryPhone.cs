using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            foreach (char character in number)
            {
                if (!char.IsDigit(character))
                {
                    throw new Exception();
                }
            }

            return $"Dialing... {number}";
        }
    }
}
