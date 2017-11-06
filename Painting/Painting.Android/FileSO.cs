using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Painting.Droid
{
    public class FileSO
    {
        public static void Save()
        {
            var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var filePath = System.IO.Path.Combine(documents, DateTime.UtcNow + ".txt");            
            File.WriteAllText(filePath, "test text");                 
        }

        public static void Load()
        {
            var documents = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var filePath = System.IO.Path.Combine(documents, DateTime.UtcNow + ".txt");
            File.WriteAllText(filePath, "test text");
        }
    }
}