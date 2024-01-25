using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> ES = new EqualityScale<int>(5, 5);
            Console.WriteLine(ES.AreEqual());
        }
    }
    public class EqualityScale<T> 
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            return left.Equals(right);
        }
    }
}
