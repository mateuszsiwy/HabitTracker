using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HabitTracker
{
    internal class dbMethods
    {
        public static void ViewRecords(string connectionString)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"SELECT * FROM drinking_water";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var date = reader.GetString(1);
                        var quantity = reader.GetString(2);
                        Console.WriteLine($"id: {id}, date: {date}, quantity: {quantity}");
                    }
                }
                connection.Close();
            }
        }
        public static void InsertRecord(string connectionString)
        {
            string date = getUserDate();
            int quantity = getUserQuantity();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $"INSERT INTO drinking_water(Date, Quantity) VALUES('{date}', {quantity})";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void DeleteRecord(string connectionString)
        {
            Console.WriteLine("Please enter the id of the record to be deleted");
            string? delete = Console.ReadLine();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $"DELETE FROM drinking_water WHERE id = '{delete}'";
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public static void UpdateRecord(string connectionString)
        {
            Console.WriteLine("Please enter the id of the record to be updated");
            string? update = Console.ReadLine();
            string? newDate = getUserDate();
            int? newQuantity = getUserQuantity();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    $"UPDATE drinking_water SET Date = '{newDate}', Quantity = '{newQuantity}' WHERE id = '{update}'";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        static string getUserDate()
        {
            while (true)
            {
                Console.WriteLine("Please enter the date in the following format (dd-mm-yy)");
                string date = Console.ReadLine();
                string format = "MM-dd-yy";
                DateTime dateValue;
                bool isValidDate = DateTime.TryParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None,
                    out dateValue);
                if (isValidDate)
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Please enter the date in the correct format!");
                }
            }
        }

        static int getUserQuantity()
        {
            Console.WriteLine("Please enter the quantity");
        
            while (true)
            {
                try
                {
                    string? quantity = Console.ReadLine();
                    int number = int.Parse(quantity ?? "-1");
                    return number;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }
    }
}
