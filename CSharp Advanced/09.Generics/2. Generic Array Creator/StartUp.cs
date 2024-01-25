using System;
using System.IO;
using System.Linq;


namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator<string>.Create(5, "Pesho");
            int[] integers = ArrayCreator<int>.Create(10, 33);
        }
    }
   
}
