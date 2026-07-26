using EFCoreProject.Models;
namespace EFCoreProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ProjectContext())
            {

                //add data on table emplyees
                //Employee e1 = new Employee();
                ////e1.EmpName = "karim";
                ////e1.EmployeeSalary = 600;
                ////e1.EmployeeSsn = 234334;
                ////e1.EmployeeAge = 30;
                ////context.employees.Add(e1);
                ////context.SaveChanges();


                //Case 1: register employee
                //Console.WriteLine("Register employee");

                //Employee e1 = new Employee();

                //Console.WriteLine("enter name");
                //e1.EmpName = Console.ReadLine();

                //Console.WriteLine("enter age");
                //e1.EmployeeAge= int.Parse(Console.ReadLine());

                //Console.WriteLine("enter salary");
                //e1.EmployeeSalary= double.Parse(Console.ReadLine());

                //Console.WriteLine("enter ssn");
                //e1.EmployeeSsn= int.Parse(Console.ReadLine());

                //context.employees.Add(e1);
                //context.SaveChanges();


                //case 2 delete employee
                Console.WriteLine("enter employee ID to delete");
                int id = int.Parse(Console.ReadLine());

                Employee employee = context.employees.FirstOrDefault(e => e.EmployeeId == id);
                if (employee == null)
                {
                    Console.WriteLine("employee not found");
                }
                else
                {
                    context.employees.Remove(employee);
                    context.SaveChanges();
                }
            } //end context

        }
    }
}
