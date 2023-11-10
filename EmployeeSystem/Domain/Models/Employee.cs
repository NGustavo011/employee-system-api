namespace EmployeeSystem.Domain.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string? photo { get; set; }

        public Employee(string name, int age, string? photo)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.age = age;
            this.photo = photo;
        }
    }
}
