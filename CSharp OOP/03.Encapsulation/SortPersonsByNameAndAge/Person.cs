namespace PersonInfo
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        public Person(string firstname, string lastname, int age)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
