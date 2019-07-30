﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactList.Pages
{
    public class SearchModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            try
            {
                /*
                 * NEW CONNECTIONS
                 */
                SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=contacts.db;Version=3;New=False;Compress=True;");
                sQLiteConnection.Open();
                SQLiteCommand sQLiteCommand = sQLiteConnection.CreateCommand();
                sQLiteCommand.CommandText = "CREATE TABLE contacts (Name varchar, Phone varchar)";
                sQLiteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
        }
    }
}
