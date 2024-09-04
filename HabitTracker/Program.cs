using System;
using Microsoft.Data.Sqlite;
using System.IO;

class Program
{
    static void Main(string[] args)
    {

        using (var connection = new SqliteConnection($"Data Source=habit-tracker.db"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS drinking_water(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Quantity INTEGER
                )";
            command.ExecuteNonQuery();
            connection.Close();
        }


        Console.WriteLine("MAIN MENU\n\n" +
            "What would you like to do?\n\n" +
            "Type 0 to Close Application\n" +
            "Type 1 to View All Records\n" +
            "Type 2 to Insert Record\n" +
            "Type 3 to Delete Record\n" +
            "Type 4 to Update Record\n" +
            "------------------------------------");

        string? choice = Console.ReadLine();
    }
}
