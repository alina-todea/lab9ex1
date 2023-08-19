// See https://aka.ms/new-console-template for more information

using lab9ex1;
using System.Reflection;
using System.Linq;


/*
 * Exercitii
• Pentru a citi mai usor solutiile voastre va rog sa copiati intr-un comentariu textul fiecarei probleme si sa il puneti la inceputul fiecarei rezolvari.
IMPORTANT
• Folositi OOP pentru a rezlova problemele
• Folosiți expresii lambda si metodele clasei List<T>
• Folositi https://app.diagrams.net/ pentru a realiza diagramele UML
 Spor la treaba
 Proiectati diagramele UML pe cat posibil INAINTEA redactarii programului.

Angajatul va fi caracterizat de
• Nume
• Id :Guid
• Salary : double
• Department
• ToString – returneaza intr-o maniera prietenoasa toate informatiile despre angajat
Departamentele pot fi
• Development
• Testing
• HumanResources
• Maintenance
• Logistics
Initializati si populati o lista de angajati si scrieti query-urile de mai jos. Folositi expresii lambda, functiile clasei List<T>: ForEach, findAll, Count, metode linq, etc.
NU folositi instructiunea foreach:
Scenarii pentru query-uri
• noOfWellPayedEmployees
o lista cu toti angajatii cu salariul mai mare decat valoarea numerica oferita ca parametru • employeesFromMaintenance
o lista cu toti angajatii din departamentul Maintenance • maxSalary
o angajatii cu cel mai mare salariu la nivel de companie • maxSalaryForDevelopment
o angajatii cu cel mai mare salariu din departamentul Development. • totalCost
o suma tuturor salariilor din companie • costForDepartment
o suma tuturor salariilor din departamentul Logistics • IncreaseSalary
o Va mari salariul unui angajat identificat prin Id cu 25% • IncreaseSalaryForTesting
o va mari salariile tuturor angajatilor din departamentul Testing cu 10% • Ordered HumanResources
o Va afisa toti angajatii din departamentul HumanResources in ordine crescatoare alfabetica si descrescatoare a salariului.
• PoorestDevelopmentEmployee
o Determinati primul angajat din departamentul Development cu salariul egal cu salariul minim din companie.
• LogisticsWithRangeExists
o Afiseaza „exista” in cazul in care in lista angajatilor exista cel putin un angajat in departamentul Logistics cu
salariul intre 5000 si 6000;
Suplimentar
• Definiti o lista de 3 departamente
• maxSalaryByDepartment
o determinati angajatul cu cel mai mare salariu din fiecare departament din lista definita.
 
 * 
 */


var angajati = new List<Angajat>()
{
new Angajat ("Mickey Mouse", 1300, Department.Development),
new Angajat ("Minnie Mouse", 1000, Department.Development),
new Angajat ("Donald Duck", 2000, Department.HumanResources),
new Angajat ("Daisy Duck", 2500, Department.HumanResources),
new Angajat ("Della Duck", 1200, Department.Maintenance),
new Angajat ("Huey Duck", 1800, Department.Testing),
new Angajat ("Dewey Duck", 1600, Department.Testing),
new Angajat ("Louie Duck", 2200, Department.Testing),
new Angajat ("Scrooge McDuck", 2400, Department.Maintenance),
new Angajat ("Quackmore Duck", 2100, Department.Logistics),
new Angajat ("Hortense Duck", 5500, Department.Logistics)

};



var limit = 3500;

Console.WriteLine("noOfWellPayedEmployees: ");
angajati.FindAll(S => S.Salary > limit).ToList().ForEach(o => Console.WriteLine(o.Name)); ;
Console.WriteLine("===================");

Console.WriteLine("employeesFromMaintenance");
angajati.FindAll(s => s.Department == Department.Maintenance).ToList().ForEach(o => Console.WriteLine(o.ToString()));
Console.WriteLine("===================");

List<Angajat> maxSalary = angajati.FindAll(s => s.Salary == angajati.Max(d => s.Salary));
Console.WriteLine($"maxSalary: {maxSalary}");
Console.WriteLine("===================");

Console.WriteLine("angajatiDevelopment: ");
List<Angajat> angajatiDevelopment = angajati.FindAll(s => s.Department == Department.Development && s.Salary == angajati.Max(d => s.Salary));

angajatiDevelopment.ToList().ForEach(o => Console.WriteLine(o.ToString()));
Console.WriteLine("===================");

var maxSalaryForDevelopment = angajatiDevelopment.Max(s => s.Salary);
Console.WriteLine($"maxSalaryForDevelopment: {maxSalaryForDevelopment}");
Console.WriteLine("===================");

var totalCost = angajati.Sum(s => s.Salary);
Console.WriteLine($"totalCost: {totalCost}");
Console.WriteLine("===================");

List<Angajat> angajatiLogistics = angajati.FindAll(s => s.Department == Department.Logistics);
var costForDepartment = angajatiLogistics.Sum(s => s.Salary);
Console.WriteLine($"costForDepartment: {costForDepartment}");
Console.WriteLine("===================");

var id = angajati[3].GetId();
Console.WriteLine($"IncreaseSalary ");
angajati.FirstOrDefault(s => s.GetId() == id).IncreaseSalary(25); 
Console.WriteLine($"salariul crescut pentru: {angajati[3].ToString()}");
Console.WriteLine("===================");

Console.WriteLine($"IncreaseSalaryForTesting");
angajati.FindAll(s => s.Department == Department.Testing).ToList().ForEach(o => o.IncreaseSalary(10));
angajati.FindAll(s => s.Department == Department.Testing).ToList().ForEach(o => Console.WriteLine($"salariul crescut pentru: {o.ToString()}"));
Console.WriteLine("===================");


Console.WriteLine("OrderedHumanResources");
angajati.Where(s => s.Department==Department.HumanResources).OrderBy(s => s.Name)
    .ThenByDescending(s => s.Salary).ToList().ForEach(o => Console.WriteLine(o.ToString()));
Console.WriteLine("==================="); ;
//foreach (Angajat angajat in OrderedHumanResources){Console.WriteLine(angajat.ToString());}
Console.WriteLine("===================");

var minSalary = angajati.Min(s => s.Salary);
Console.WriteLine($"minSalary: {minSalary}");
var PoorestDevelopmentEmployee = angajati.FirstOrDefault(s => s.Department == Department.Development && s.Salary == angajati.Min(s => s.Salary));
Console.WriteLine($"PoorestDevelopmentEmployee: {PoorestDevelopmentEmployee.ToString()}");
Console.WriteLine("===================");


if (angajati.FirstOrDefault(s => s.Department == Department.Logistics && s.Salary >= 5000 && s.Salary <= 6000) != null)
    {
        Console.WriteLine("LogisticsWithRangeExists: exists");
    }



