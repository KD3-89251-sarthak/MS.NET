using AttributeLib;
//using EntityLib;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
namespace ORM
{
    internal class Test
    {
        static void Main(string[] args)
            {
                // Load the assembly containing your entity classes
                string assemblyPath = "F:\\Disk HDD (H)\\netPractice\\Assignment3\\PoJoLib\\bin\\Debug\\net8.0\\EntityLib.dll"; // Update with your actual path
                Assembly assembly = Assembly.LoadFrom(assemblyPath);

                // Get all types from the assembly
                Type[] types = assembly.GetTypes();

                // Prepare to collect all SQL statements
                StringBuilder allSqlStatements = new StringBuilder();

                foreach (Type type in types)
                {
                // Check if the class is marked with DataTable attribute (our "Serialized" marker)

                var serial = type.GetCustomAttribute<SerializableAttribute>();
                var dataTableAttr = type.GetCustomAttribute<DataTable>();
                if (serial == null || dataTableAttr == null)
                    {
                        continue;   
                    }
                // i. Get the object's property array
                PropertyInfo[] properties = type.GetProperties();

                    // ii. Remove the unmapped fields of the data table
                    var mappedProperties = properties
                        .Where(p => !p.IsDefined(typeof(unMapped)))
                        .ToList();

                    // iii. Prepare SQL statements
                    string createTableSql = GenerateCreateTableSql(type, dataTableAttr, mappedProperties);
                    string insertTemplateSql = GenerateInsertTemplateSql(type, dataTableAttr, mappedProperties);

                    allSqlStatements.AppendLine(createTableSql);
                    allSqlStatements.AppendLine(insertTemplateSql);
                    allSqlStatements.AppendLine();
                }

                // iv. Write SQL statements to file
                string outputPath = "F:\\Disk HDD (H)\\netPractice\\Assignment3\\ORM\\sqlQuery.sql";
                FileStream fileStream = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.Write);

                StreamWriter writer = new StreamWriter(fileStream);
                writer.WriteLine(allSqlStatements.ToString());
                writer.Close();
                fileStream.Close();

                Console.WriteLine("Query Written in To SQL File");

                Console.WriteLine("Generated SQL statements:");
                Console.WriteLine(allSqlStatements.ToString());
                Console.WriteLine($"\nSQL statements written to: {outputPath}");
                Console.ReadLine();
            }

            static string GenerateCreateTableSql(Type type, DataTable dataTableAttr, List<PropertyInfo> properties)
            {
                string tableName = dataTableAttr.Tablename ?? type.Name;
                StringBuilder sql = new StringBuilder();

                sql.Append($"CREATE TABLE {tableName} (");

                foreach (var prop in properties)
                {
                    var columnAttr = prop.GetCustomAttribute<DataColumn>();
                    string columnName = columnAttr?.ColumnName ?? prop.Name;
                    string columnType = GetSqlType(prop.PropertyType);

                    sql.Append($"\n  {columnName} {columnType}");

                    if (prop.IsDefined(typeof(KeyColumn)))
                    {
                        sql.Append(" PRIMARY KEY");
                    }

                    sql.Append(",");
                }

                sql.Remove(sql.Length - 1, 1); // Remove trailing comma
                sql.Append("\n);");

                return sql.ToString();
            }

            static string GenerateInsertTemplateSql(Type type, DataTable dataTableAttr, List<PropertyInfo> properties)
            {
                string tableName = dataTableAttr.Tablename ?? type.Name;
                StringBuilder sql = new StringBuilder();

                sql.Append($"INSERT INTO {tableName} (");

                // Column names
                foreach (var prop in properties)
                {
                    var columnAttr = prop.GetCustomAttribute<DataColumn>();
                    string columnName = columnAttr?.ColumnName ?? prop.Name;
                    sql.Append($"{columnName}, ");
                }

                sql.Remove(sql.Length - 2, 2); // Remove trailing comma and space
                sql.Append(") VALUES (");

                // Value placeholders
                foreach (var prop in properties)
                {
                    sql.Append($"@{prop.Name}, ");
                }

                sql.Remove(sql.Length - 2, 2); // Remove trailing comma and space
                sql.Append(");");

                return sql.ToString();
            }

            static string GetSqlType(Type propertyType)
            {
                if (propertyType == typeof(int) || propertyType == typeof(long))
                    return "INT";
                if (propertyType == typeof(string))
                    return "VARCHAR(255)";
                if (propertyType == typeof(decimal) || propertyType == typeof(double))
                    return "DECIMAL(18,2)";
                if (propertyType == typeof(DateTime))
                    return "DATETIME";
                if (propertyType == typeof(bool))
                    return "BIT";

                return "VARCHAR(255)"; // Default for unknown types
            }

    }
}
