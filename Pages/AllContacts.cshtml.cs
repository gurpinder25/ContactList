using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactList.Pages
{
    public class AllContactsModel : PageModel
    {
        public string Message { get; set; }
        String ReadData;
        public List<string> display = new List<string> { };
        public List<string> displayCopies = new List<string> { };
        public void OnGet()
        {
            try
            {
                //NEW CONNECTION
                SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=contacts.db;Version=3;New=True;");
                sQLiteConnection.Open();
                SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();

                //READING DATA FROM DATABASE
                sQLiteCommand.CommandText = "SELECT * FROM contacts";
                SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
                while (sQLiteDataReader.Read())
                {

                    //ADDING DATA TO A LIST
                    ReadData = sQLiteDataReader.GetString(0);
                    display.Add(ReadData);
                    displayCopies.Add(sQLiteDataReader.GetString(1));
                }

            }
            catch (Exception e)
            {
                //YOUR ERROR MESSAGE
            }
        }
    }
}
