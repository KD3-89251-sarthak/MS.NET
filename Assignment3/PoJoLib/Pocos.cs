using AttributeLib;

namespace EntityLib
{
    [DataTable(Tablename ="Employee")]
    [Serializable]
    public class Employee
    {
        [KeyColumn(KeyColumnName ="Primary Key")]
        [DataColumn(ColumnName ="Id", ColumnType = "int")]
        public int EmpNo { get; set; }

        [DataColumn(ColumnName = "Name", ColumnType = "varchar(50)")]
        public string Name { get; set; }

        [DataColumn(ColumnName = "Address", ColumnType = "varchar(50)")]
        public string Address { get; set; }

        [DataColumn(ColumnName = "Salary", ColumnType = "double")]
        public decimal Salary { get; set; }

        [unMapped]
        public decimal AnnualSalary => Salary * 12;

        [DataColumn(ColumnName = "Manager", ColumnType = "varchar(50)")]
        public string Designation { get; set; }
    }


    [DataTable(Tablename ="Students")]
    public class Student
    {
        [KeyColumn(KeyColumnName ="Primary Key")]
        [DataColumn(ColumnName ="RollNo", ColumnType = "int")]
        public int RollNo { get; set; }

        [DataColumn(ColumnName = "Name", ColumnType = "varchar(50)")]
        public string Name { get; set; }

        [DataColumn(ColumnName = "Address", ColumnType = "varchar(50)")]
        public string Address { get; set; }

        [unMapped]
        public string Course { get; set; }
    }
}
