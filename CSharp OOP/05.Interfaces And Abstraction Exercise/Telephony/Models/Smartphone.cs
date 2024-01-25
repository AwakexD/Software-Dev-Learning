using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : IBrowsable, ICallable
    {
        public string Browse(string URL)
        {
            foreach (char character in URL)
            {
                if (char.IsDigit(character))
                {
                    throw new Exception();
                }
            }

            return $"Browsing: {URL}!";
        }

        public string Call(string number)
        {
            foreach (char character in number)
            {
                if (!char.IsDigit(character))
                {
                    throw new Exception();
                }
            }

            return $"Calling... {number}";
        }
    }
}
