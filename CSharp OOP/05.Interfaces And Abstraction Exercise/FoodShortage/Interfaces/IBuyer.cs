using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Interfaces
{
    public interface IBuyer
    {
        void BuyFood();

        int Food { get; }
    }
}
