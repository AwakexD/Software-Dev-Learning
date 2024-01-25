using System;

namespace CustomRandomList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("aasda");
            randomList.Add("dada21 ");
            randomList.Add("1231231");
            randomList.Add("zhdzfaljkr31");

            randomList.RandomString();
            randomList.RandomString();
            randomList.RandomString();
        }
    }
}
