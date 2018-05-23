using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Text;

namespace ConexionDB_ODBC
{
    class Program
    {
        //Creación de string de conexion "global" obtenido a través de App.config:
        //Para acceder a los valores del App.config, usted debe hacer click derecho sobre Referencias, luego
        //seleccionar "Agregar referencia"
        static string _connectionString = ConfigurationManager.ConnectionStrings["ConexionDB_ODBC.Properties.Settings.OrigenODBC"].ConnectionString;
        static void Main(string[] args)
        {
            //Llamada al metodo privado para obtener las personas registradas en la base de datos:
            GetPersonas();
            Console.WriteLine("\n\nPresione cualquier tecla para salir de la aplicación");
            Console.ReadKey();

        }

        static void GetPersonas()
        {
            //Consulta que realizaremos a la base de datos:
            string query = "SELECT * FROM Personas";
            OdbcCommand command = new OdbcCommand(query);

            using (OdbcConnection connection = new OdbcConnection(_connectionString))
            {
                command.Connection = connection;
                connection.Open();
                //Ejecución de Query.
                //"reader", almacenará la respuesta de la consulta:
                OdbcDataReader reader = command.ExecuteReader();


                Console.WriteLine("***********************************");
                Console.WriteLine("Lista de personas registradas en la tabla: Personas.\n");            
                List<Persona> listPersonasObtenidas = new List<Persona>();
                while (reader.Read())
                {
                    //Por cada respuesta obtenida, creamos un objeto de tipo Persona.
                    //Esto nos sirve para crear modificaciones al momento de su creación
                    //Para mostrar un ejemplo mejor: El primer nombre, de todas las personas serán en mayúsculas
                    //Modificación realizada en la clase Persona
                    Persona persona = new Persona()
                    {
                        Id = (int)reader[0],
                        PrimerNombre = reader[1].ToString(),
                        SegundoNombre = reader[2].ToString(),
                        PrimerApellido = reader[3].ToString(),
                        SegundoApellido = reader[4].ToString(),
                        Rut = reader[5].ToString()
                    };
                    listPersonasObtenidas.Add(persona);                    
                }
                //Impresión del resultado obtenido:
                if(listPersonasObtenidas.Count > 0)
                {
                    foreach (Persona item in listPersonasObtenidas)
                    {
                        Console.WriteLine($"{item.Id}   -   {item.PrimerNombre}   -   {item.SegundoNombre} -   {item.PrimerApellido}   -   {item.SegundoApellido}   -   {item.Rut}");
                    }
                }
                else
                {
                    Console.WriteLine("No se han encontrado registro de personas en las base de datos");
                }
              
            }
        }
    }
}
