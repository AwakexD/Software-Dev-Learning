namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FavourtiteFood { get; protected set; }

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavourtiteFood = favouriteFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my favourite food is {this.FavourtiteFood}";
        }
    }
}
