using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactList.Pages
{
    public class AddModel : PageModel
    {

        public void OnGet()
        {
            //GET INPUT FROM USER
            string TotalInput = Request.QueryString.Value;
            string PhoneNumber = TotalInput.Split("=")[2];
            TotalInput = TotalInput.Split("=")[1].Split("&")[0];
            TotalInput = TotalInput.Replace("+", " ");


            //NEW CONNECTION
            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=contacts.db;Version=3;New=False;Compress=True;");
            sQLiteConnection.Open();
            SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();

            //INSERT INTO MOVIES TABLE
            sQLiteCommand.CommandText = "INSERT INTO contacts (Name, Phone) VALUES (" + "'" + TotalInput + "'" + "," + "'" + PhoneNumber + "'" + ")";
            sQLiteCommand.ExecuteNonQuery();
        }
    }
}
