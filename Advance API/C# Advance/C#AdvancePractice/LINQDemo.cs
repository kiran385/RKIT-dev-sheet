using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpAdvancePractice
{
    /// <summary>
    /// Class containing LINQ demo
    /// </summary>
    internal class LINQDemo
    {
        /// <summary>
        /// Employee data
        /// </summary>
        static List<Employee> employeeList = new List<Employee>
        {
            new Employee { EmployeeId = 101, EmployeeName = "Ajay", EmployeeAge = 20, Salary = 25000, DepartmentId = 3 },
            new Employee { EmployeeId = 102, EmployeeName = "Akshay", EmployeeAge = 26, Salary = 35000, DepartmentId = 1 },
            new Employee { EmployeeId = 103, EmployeeName = "Rahul", EmployeeAge = 22, Salary = 45000, DepartmentId = 2 },
            new Employee { EmployeeId = 104, EmployeeName = "Harsh", EmployeeAge = 24, Salary = 40000, DepartmentId = 2 },
            new Employee { EmployeeId = 105, EmployeeName = "Jay", EmployeeAge = 22, Salary = 26000, DepartmentId = 3 }
        };

        /// <summary>
        /// Department data
        /// </summary>
        static List<Department> departmentList = new List<Department>
        {
            new Department { DepartmentId = 1, DepartmentName = "HR"},
            new Department { DepartmentId = 2, DepartmentName = "Development"},
            new Department { DepartmentId = 3, DepartmentName = "Designer"},
            new Department { DepartmentId = 4, DepartmentName = "Support Staff"},
        };

        /// <summary>
        /// Method containing different LINQ methods demo
        /// </summary>
        public static void MyLINQDemo()
        {
            //Console.WriteLine("\nFilter Methods\n");
            FilterMethods();

            //Console.WriteLine("\nProjection Methods\n");
            //ProjectionMethods();

            //Console.WriteLine("\nSorting Methods\n");
            //SortingMethods();

            //Console.WriteLine("\nQuantifier Methods\n");
            //QuantifierMethods();

            //Console.WriteLine("\nSet Methods\n");
            //SetMethods();

            //Console.WriteLine("\nJoin Methods\n");
            //JoinMethods();

            //Console.WriteLine("\nAggregate Methods\n");
            //AggregateMethods();

            //Console.WriteLine("\nGroup Methods\n");
            //GroupMethods();

            //Console.WriteLine("\nPartition Methods\n");
            //PartitionMethods();

            //Console.WriteLine("\nConversion Methods\n");
            //ConversionMethods();
        }

        public static void FilterMethods()
        {
            //Where method
            Console.Write("Where(Method syntax): ");
            foreach(Employee emp in employeeList.Where(e => e.EmployeeAge >= 25))
            {
                Console.WriteLine(emp.EmployeeName);
            }

            var greaterThan25 = from emp in employeeList
                                where emp.EmployeeAge >= 25
                                select emp;
            Console.Write("Where(Query syntax): ");
            foreach(Employee emp in greaterThan25)
            {
                Console.WriteLine(emp.EmployeeName);
            }

            //OfType method
            Object[] temp = { 1, "hello", 2, 3.14, 3 };
            Console.WriteLine("\nOfType(Method syntax): " + string.Join(", ", temp.OfType<double>()));

            var ints = from i in temp
                    where i is int
                    select i;
            Console.WriteLine("OfType(Query syntax): " + string.Join(',',ints));

            //First method
            Console.WriteLine("\nFirst(Method syntax): " + employeeList.First(e => e.EmployeeAge>=22).EmployeeName);

            Employee firstEmployee = (from emp in employeeList
                                 select emp).First(e => e.DepartmentId == 2);
            Console.WriteLine("First(Query syntax): " + firstEmployee.EmployeeName);

            //FirstOrDefault
            Console.WriteLine("\nFirstOrDefault(Method syntax): " + (employeeList.FirstOrDefault(e => e.EmployeeAge>=30) ?.EmployeeName ?? "None"));
            string firstDefault = (from emp in employeeList
                                   select emp).FirstOrDefault(e => e.DepartmentId == 1)?.EmployeeName ?? "None"; 
            Console.WriteLine("FirstOrDefault(Query syntax): " + firstDefault);

            //Last method
            Console.WriteLine("\nLast(Method syntax): " + employeeList.Last(e => e.EmployeeAge >= 22).EmployeeName);

            Employee lastEmployee = (from emp in employeeList
                                      select emp).Last(e => e.DepartmentId == 2);
            Console.WriteLine("Last(Query syntax): " + lastEmployee.EmployeeName);

            //LastOrDefault
            Console.WriteLine("\nLastOrDefault(Method syntax): " + (employeeList.LastOrDefault(e => e.EmployeeAge >= 30)?.EmployeeName ?? "None"));
            string lastDefault = (from emp in employeeList
                                   select emp).LastOrDefault(e => e.DepartmentId == 1)?.EmployeeName ?? "None";
            Console.WriteLine("LastOrDefault(Query syntax): " + lastDefault);

            //Single method
            Console.Write("\nSingle(Method syntax): ");
            try
            {
                Console.WriteLine(employeeList.Single(e => e.DepartmentId==1).EmployeeName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("Single(Query syntax): ");
            try
            {
                Employee single = (from emp in employeeList
                              select emp).Single();
                Console.WriteLine(single);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //ElementAt method
            Console.WriteLine("\nElementAt(Method syntax): " + employeeList.ElementAt(2).EmployeeName);

            Employee elementAt = (from emp in employeeList
                                  select emp).ElementAt(3);
            Console.WriteLine("ElementAt(Query syntax): " + elementAt.EmployeeName);

            //ElementAtOrDefault method
            Console.WriteLine("\nElementAtOrDefault(Method syntax): " + (employeeList.ElementAtOrDefault(10)?.EmployeeName ?? "None"));

            string elementAtOrDefault = (from emp in employeeList
                                         select emp).ElementAtOrDefault(-3)?.EmployeeName ?? "None";
            Console.WriteLine("ElementAtOrDefault(Query syntax): " + elementAtOrDefault);
        }

        public static void ProjectionMethods()
        {
            List<string> names = new List<string> { "Ajay", "Harsh", "Jay" };

            //Select method - projects element
            Console.WriteLine("\nSelect: " + string.Join(", ", names.Select(n => n.ToCharArray())));

            //SelectMany method - projects and flattens element
            Console.WriteLine("\nSelectMany: " + string.Join(", ", names.SelectMany(n => n.ToCharArray())));
        }

        public static void SortingMethods()
        {
            //OrderBy method
            Console.WriteLine("\nOrderBy: ");
            foreach(Employee emp in employeeList.OrderBy(e => e.EmployeeAge))
            {
                Console.WriteLine($"{emp.EmployeeName} - {emp.EmployeeAge}");
            }

            //OrderByDescending method
            Console.WriteLine("\nOrderByDescending: ");
            foreach (Employee emp in employeeList.OrderByDescending(e => e.EmployeeAge))
            {
                Console.WriteLine($"{emp.EmployeeName} - {emp.EmployeeAge}");
            }

            //ThenBy method
            Console.WriteLine("\nThenBy: ");
            foreach (Employee emp in employeeList.OrderBy(e => e.EmployeeAge).ThenBy(e => e.Salary))
            {
                Console.WriteLine($"{emp.EmployeeName} - {emp.EmployeeAge} - {emp.Salary}");
            }

            //ThenByDescending method
            Console.WriteLine("\nThenByDescending: ");
            foreach (Employee emp in employeeList.OrderByDescending(e => e.EmployeeAge).ThenByDescending(e => e.Salary))
            {
                Console.WriteLine($"{emp.EmployeeName} - {emp.EmployeeAge} - {emp.Salary}");
            }

            //Reverse
            Console.WriteLine("\nReverse: ");
            foreach(Employee emp in employeeList.AsEnumerable().Reverse())
            {
                Console.WriteLine(emp.EmployeeName);
            }
        }

        public static void QuantifierMethods()
        {
            //Any method
            Console.WriteLine("Any greater than age 25: " + employeeList.Any(e => e.EmployeeAge > 25));

            //All method
            Console.WriteLine("All greater than age 25: " + employeeList.All(e => e.EmployeeAge > 25));

            //Contains method
            Console.WriteLine("Contains DepartmentId 4: " + employeeList.Select(e => e.DepartmentId).Contains(3));
        }

        public static void SetMethods()
        {
            List<int> set1 = new List<int> { 1, 2, 2, 3 };
            List<int> set2 = new List<int> { 3, 3, 4, 5 };

            //Distinct
            Console.WriteLine("Distinct Set1: " + string.Join(", ", set1.Distinct()));

            //Union
            Console.WriteLine("Union: " + string.Join(", ", set1.Union(set2)));

            //Intersect
            Console.WriteLine("Intersect: " + string.Join(", ", set1.Intersect(set2)));

            //Except
            Console.WriteLine("Except: " + string.Join(", ", set1.Except(set2)));

            //Concat
            Console.WriteLine("Concat: " + string.Join(", ", set1.Concat(set2)));
        }

        public static void JoinMethods()
        {
            //Join method
            Console.WriteLine("\nJoin(Method syntax)");
            var employeeDepartment = employeeList.Join(departmentList, 
                e => e.DepartmentId, 
                d => d.DepartmentId, 
                (e, d) => new { e.EmployeeName , d.DepartmentName });
            foreach(var ed in employeeDepartment)
            {
                Console.WriteLine($"{ed.EmployeeName} - {ed.DepartmentName}");
            }

            Console.WriteLine("\nJoin(Query syntax)");
            var empDept = from e in employeeList
                          join d in departmentList
                          on e.DepartmentId equals d.DepartmentId
                          select new { e.EmployeeName , d.DepartmentName };
            foreach (var ed in empDept)
            {
                Console.WriteLine($"{ed.EmployeeName} - {ed.DepartmentName}");
            }

            //GroupJoin method
            Console.WriteLine("\nGroupJoin(Method syntax)");
            var departmentEmployees = departmentList.GroupJoin(employeeList, 
                d => d.DepartmentId, 
                e => e.DepartmentId, 
                (d,e) => new {d.DepartmentName, 
                    empList = e.Select(e => e.EmployeeName)});
            foreach (var ed in departmentEmployees)
            {
                Console.WriteLine($"{ed.DepartmentName} - {string.Join(',', ed.empList)}");
            }

            Console.WriteLine("\nGroupJoin(Query syntax)");
            var deptEmp = from d in departmentList
                          join e in employeeList
                          on d.DepartmentId equals e.DepartmentId
                          into deptGroup
                          select new {d.DepartmentName, 
                              empList = deptGroup.Select(e => e.EmployeeName)};
            foreach (var ed in deptEmp)
            {
                Console.WriteLine($"{ed.DepartmentName} - {string.Join(',', ed.empList)}");
            }
        }

        public static void AggregateMethods()
        {
            //Count method
            Console.WriteLine("Count employee age > 25: " + employeeList.Count(e => e.EmployeeAge > 25));

            //Sum method
            Console.WriteLine("Sum of employee salary: " + employeeList.Sum(e => e.Salary));

            //Min method
            Console.WriteLine("Min employee salary: " + employeeList.Min(e => e.Salary));

            //Max method
            Console.WriteLine("Max employee salary: " + employeeList.Max(e => e.Salary));

            //Average method
            Console.WriteLine("Average employee salary: " + employeeList.Average(e => e.Salary));

            //Aggregate method
            Console.WriteLine("Aggregate: " + employeeList.Aggregate(" ", (a,b) => a + b.EmployeeName + " "));
        }

        public static void GroupMethods()
        {
            //GroupBy method
            Console.WriteLine("\nGroupBy department(Method syntax)");
            foreach(var empGroup in employeeList.GroupBy(e => e.DepartmentId))
            {
                Console.WriteLine($"{empGroup.Key} : {string.Join(", ",empGroup.Select(e => e.EmployeeName))}");
            }

            Console.WriteLine("\nGroupBy department(Query syntax)");
            var t = from e in employeeList
                    group e by e.DepartmentId into empGroup
                    select empGroup;
            foreach(var e in  t)
            {
                Console.WriteLine($"{e.Key} : {string.Join(", ",e.Select(e => e.EmployeeName))}");
            }
        }

        public static void PartitionMethods()
        {
            List<int> numbers = new List<int> { 5, 10, 15, 20, 25 };

            //Take method
            Console.WriteLine("Take: " + string.Join(", ", numbers.Take(1..3)));

            //TakeLast method
            Console.WriteLine("Take last 3: " + string.Join(", ", numbers.TakeLast(3)));

            //TakeWhile method
            Console.WriteLine("Take until n < 15: " + string.Join(", ", numbers.TakeWhile(n => n < 15)));

            //Skip method
            Console.WriteLine("Skip first 3: " + string.Join(", ", numbers.Skip(3)));

            //SkipLast method
            Console.WriteLine("Skip last 3: " + string.Join(", ", numbers.SkipLast(3)));

            //SkipWhile method
            Console.WriteLine("Skip until n < 15: " + string.Join(", ", numbers.SkipWhile(n => n < 15)));
        }

        public static void ConversionMethods()
        {
            //ToList method
            List<string> namesList = employeeList.Select(e => e.EmployeeName).ToList();
            Console.WriteLine("ToList: " + string.Join(", ", namesList));

            //ToArray method
            string[] namesArray = employeeList.Select(e => e.EmployeeName).ToArray();
            Console.WriteLine("ToArray: " + string.Join(", ", namesArray));

            //ToDictionary method
            Dictionary<int, string> namesDict = departmentList.ToDictionary(d => d.DepartmentId, d => d.DepartmentName);
            Console.WriteLine("ToDictionary");
            foreach(KeyValuePair<int, string> kvp in namesDict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

            //ToLookup method
            var deptEmp = employeeList.ToLookup(e => e.DepartmentId);
            Console.WriteLine("ToLookup");
            foreach(var emp in deptEmp)
            {
                Console.WriteLine($"{emp.Key}: {string.Join(", ",emp.Select(e => e.EmployeeName))}");
            }
        }
    }
}
