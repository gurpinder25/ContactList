using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactList.Pages
{
    public class UpdateModel : PageModel
    {
        public void OnGet()
        {
            string TotalInput = Request.QueryString.Value;
            string PhoneNumber = TotalInput.Split("=")[2];
            TotalInput = TotalInput.Split("=")[1].Split("&")[0];
            TotalInput = TotalInput.Replace("+", " ");

            try
            {
                //Establishing a new SQLite Connection
                SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=contacts.db;Version=3;New=False;Compress=True;");
                sQLiteConnection.Open();
                SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();

                //Giving DELETE command to remove an entry from our table
                sQLiteCommand.CommandText = "UPDATE contacts SET Phone=" + PhoneNumber + " WHERE Name = " + "'" + TotalInput + "'";
                sQLiteCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
            }
        }
    }
}