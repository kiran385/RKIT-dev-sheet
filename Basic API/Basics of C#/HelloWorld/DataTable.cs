using System;
using System.Data;

namespace HelloWorld
{
    public class DataTableDemo
    {
        public static void MyDataTableDemo()
        {
            DataTable table = new DataTable("Employees");
            DataTable DeptTable = new DataTable("Department");

            table.CaseSensitive = false;

            // Define columns
            DataColumn idCol = new DataColumn("ID", typeof(int));
            idCol.Unique = true;
            idCol.AutoIncrement = true;
            idCol.AutoIncrementSeed = 1;

            DataColumn nameCol = new DataColumn("Name", typeof(string));
            DataColumn salaryCol = new DataColumn("Salary", typeof(double));

            table.Columns.AddRange(new DataColumn[] { idCol, nameCol, salaryCol });

            // Set primary key
            table.PrimaryKey = new DataColumn[] { idCol };

            DeptTable.Columns.Add("Name");
            DeptTable.Columns.Add("EmployeeId",typeof(int));

            DataSet ds = new DataSet();
            ds.Tables.Add(table);
            ds.Tables.Add(DeptTable);

            DataRelation relation = new DataRelation(
                "Emp_Dept_FK",
                table.Columns["ID"],
                DeptTable.Columns["EmployeeId"]
            );

            ds.Relations.Add(relation);

            // Add a new row
            DataRow row1 = table.NewRow();
            row1["Name"] = "Employee1";
            row1["Salary"] = 5000;
            table.Rows.Add(row1);

            // Add another row using LoadDataRow
            table.LoadDataRow(new object[] { null, "Employee2", 6000 }, true);

            DeptTable.Rows.Add("FS",1);
            //DeptTable.Rows.Add("QA",10);    //This line gives error because employee with id 10 is not in employees table

            Console.WriteLine("DataTable contents:");
            PrintTable(table);

            // Select rows
            Console.WriteLine("\nSelect rows where Salary > 5500:");
            DataRow[] selected = table.Select("Salary > 5500");
            foreach (var r in selected)
                Console.WriteLine($"{r["ID"]}, {r["Name"]}");

            // Use Compute method
            object sum = table.Compute("SUM(Salary)", "");
            Console.WriteLine($"\nTotal Salary: {sum}");

            // Copy and Clone
            DataTable copy = table.Copy();     // Includes data
            DataTable clone = table.Clone();   // Only schema

            Console.WriteLine("\nCopied table contents:");
            PrintTable(copy);

            Console.WriteLine("\nCloned table (no data):");
            PrintTable(clone);

            // AcceptChanges and RejectChanges
            row1["Salary"] = 5500;
            table.AcceptChanges();

            row1["Salary"] = 7000;
            table.RejectChanges(); // Reverts to last AcceptChanges()

            // GetChanges
            row1["Salary"] = 8000;
            DataTable changes = table.GetChanges();
            Console.WriteLine("\nChanged rows:");
            PrintTable(changes);

            // Remove a row
            table.Rows[0].Delete(); 
            table.AcceptChanges();

            // Write and Read XML
            table.WriteXml("table.xml");
            table.WriteXmlSchema("schema.xml");

            DataTable newTable = new DataTable();
            newTable.ReadXmlSchema("schema.xml");
            newTable.ReadXml("table.xml");

            Console.WriteLine("\nNew table loaded from XML:");
            PrintTable(newTable);

            // Clear all rows
            table.Clear();
            Console.WriteLine("\nTable after Clear:");
            Console.WriteLine($"Row count: {table.Rows.Count}");
        }

        static void PrintTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        Console.Write($"{row[col]} \t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
