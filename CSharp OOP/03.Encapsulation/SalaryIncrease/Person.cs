namespace PersonInfo
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        private decimal Salary;

        public Person(string firstname, string lastname, int age, decimal salary)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Salary = salary;
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30)
            {
                percentage = percentage / 2;
            }

            Salary += Salary * percentage / 100;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
