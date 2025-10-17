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
    string insertQuery1 = "INSERT INTO Producto (descripcion, precio) VALUES ('Auriculares Philips', 45000), ('Auriculares JBL', 90000)";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery1, connection))
            {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Datos insertados en la tabla 'Producto'.");
            }
    
    string insertQuery2 = "INSERT INTO Presupuesto (nombre_destinatario, fecha_creacion) VALUES ('Milagros Sosa', '2025-07-15')";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery2, connection))
            {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Datos insertados en la tabla 'Presupuesto'.");
            }

    string insertQuery3 = "INSERT INTO PresupuestoDetalle (id_presupuesto, id_producto, cantidad) VALUES (3, 4, 3)";
            using (SqliteCommand insertCmd = new SqliteCommand(insertQuery3, connection))
            {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Datos insertados en la tabla 'PresupuestoDetalle'.");
            }
    //modificar datos
    string updateQuery = "UPDATE Presupuesto SET nombre_destinatario = 'Luis German Fernandez' WHERE id_presupuesto = 1";
        using (SqliteCommand updateCmd = new SqliteCommand(updateQuery, connection))
        {
            updateCmd.ExecuteNonQuery();
            Console.WriteLine("Datos actualizados en la tabla 'Presupuesto'.");
        }

    string deleteQuery = "DELETE FROM Presupuesto WHERE id_presupuesto = 3";
        using (SqliteCommand deleteCmd = new SqliteCommand(deleteQuery, connection))
        {
            deleteCmd.ExecuteNonQuery();
            Console.WriteLine("Dato eliminado de la tabla 'Presupuesto'.");
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