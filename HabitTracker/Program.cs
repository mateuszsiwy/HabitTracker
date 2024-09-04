using System;
using Microsoft.Data.Sqlite;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using HabitTracker;
class Program
{
    static void Main(string[] args)
    {

        string connectionString = $"Data Source=habit-tracker.db";
        using (var connection = new SqliteConnection(connectionString))
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



        while (true)
        {
            Console.WriteLine("MAIN MENU\n\n" +
            "What would you like to do?\n\n" +
            "Type 0 to Close Application\n" +
            "Type 1 to View All Records\n" +
            "Type 2 to Insert Record\n" +
            "Type 3 to Delete Record\n" +
            "Type 4 to Update Record\n" +
            "------------------------------------");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    dbMethods.ViewRecords(connectionString);
                    break;
                case "2":
                    dbMethods.InsertRecord(connectionString);
                    break;
                case "3":
                    dbMethods.DeleteRecord(connectionString);
                    break;
                case "4":
                    dbMethods.UpdateRecord(connectionString);
                    break;
                default:
                    Console.WriteLine("Pick a valid option!");
                    break;
            }
        }
    }
}
