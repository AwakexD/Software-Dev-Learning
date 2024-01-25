using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Student);
            object instance = Activator.CreateInstance(type, "Ivan", 19);

            FieldInfo[] fields = type.GetFields((BindingFlags)(60));
            //FieldInfo ageField = type.GetField("age", (BindingFlags)(60));

            //Console.WriteLine($"Age field : {ageField.GetValue(instance)}");

            foreach (FieldInfo field in fields)
            {
                Console.WriteLine($"Field name: {field.Name} = {field.GetValue(instance)}");
            }

        }

        class Student
        {
            public string name;
            private int age;
            private static string id = "47812"; 
            private string cheatCode = "12";

            public Student(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }
    }
}
