using Microsoft.Data.Sqlite;
string connectionString = "Data Source=Tienda.db;";

// Crear conexión a la base de datos
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
    // Crear tabla si no existe
    // por lo general este tipo de consultas no se implementa en un programa real
    // la aplicamos para poder crear nuestra base de datos desde cero
    string createTableQuery = "CREATE TABLE IF NOT EXISTS Producto (id_producto INTEGER PRIMARY KEY, descripcion TEXT, precio NUMERIC)";
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'Producto' creada o ya existe.");
    }
    
    // Insertar datos
    string insertQuery = "INSERT INTO Producto (descripcion, precio) VALUES ('Auriculares Philips', 45000), ('Auriculares JBL', 90000)";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
            {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Datos insertados en la tabla 'Producto'.");
            }
    // Leer datos
            string selectQuery = "SELECT * FROM Producto";
            using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection))
            using (SqliteDataReader reader = selectCmd.ExecuteReader())
            {
                Console.WriteLine("Datos en la tabla 'Producto':");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id_producto"]}, Descripcion: {reader["descripcion"]}, Precio: {reader["precio"]}");
                }
            }

            connection.Close();
}