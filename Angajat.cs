using System;
using lab9ex1;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace lab9ex1
{
    public class Angajat
    {
        public string Name { get; set; }
        public Guid Id { get; private set; }
        public double Salary = 0.0;
        public Department Department { get; set; }
       // delegate double IncreaseSal(double x, double y);



        public Angajat(string name, int salary, Department department)
        {

            this.Name = name;
            this.Id = Guid.NewGuid();
            this.Salary = salary;
            this.Department = department;

        }

        //IncreaseSal increase = (double x, double y) => { return x * (y / 100); };



        public void IncreaseSalary(double percent)
        {
            //increase(Salary, percent);
            Salary += Salary * (percent / 100);
        }

        public string GetId()
        {
            return this.Id.ToString();
        }
        //  public override string ToString() =>  $”XName: {Name}, Id: {Id}, Salar: {Salary}, Department: {Department}”;

        public override string ToString()
        {

            string descriere = $"Nume: {Name}, Id: {Id}, Salar: {Salary}, Departament:  {Department} ";

            return descriere.ToString();
        }
    }
}

