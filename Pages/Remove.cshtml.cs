using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactList.Pages
{
    public class RemoveModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            //USER INPUT
            string TotalInput = Request.QueryString.Value;
            TotalInput = TotalInput.Split("=")[1];
            TotalInput = TotalInput.Replace("+", " ");

            try
            {
                //NEW CONNECTION
                SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=contacts.db;Version=3;New=False;Compress=True;");
                sQLiteConnection.Open();
                SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();

                //DELETING FROM DATABASE USING SQLITE COMMAND
                sQLiteCommand.CommandText = "DELETE FROM contacts WHERE Name = " + "'" + TotalInput + "'";

                sQLiteCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}
