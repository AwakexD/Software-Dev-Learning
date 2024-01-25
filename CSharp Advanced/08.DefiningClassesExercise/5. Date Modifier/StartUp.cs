using System;

namespace DefiningClasses
{ 
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Input: Year Month Day
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dm = new DateModifier(firstDate, secondDate);

            dm.CalculateDifference();
        }
    }
}
