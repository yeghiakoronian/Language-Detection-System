using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP_Language_Detection_Final
{
    class FetchFromFolderFiles
    {
        String folderName;
        String Desktop;
        String FilePath;
        public FetchFromFolderFiles(String Folder)
        {
            folderName = Folder;
            Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            FilePath = Desktop + "\\" + folderName + "\\";

        }

        public DataTable getTrainingDataFor(String language)
        {
            string line;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TWEET", typeof(String));
            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(FilePath + "\\" + language + ".txt");
            while ((line = file.ReadLine()) != null)
            {
                dataTable.Rows.Add(line);
            }

            file.Close();
            return dataTable;
        }



        public Hashtable getTestingDataFor(String language)
        {
            string line;
            Hashtable hashTableForLanguage = new Hashtable();
            DataParser DP = new DataParser();
            System.IO.StreamReader file =
               new System.IO.StreamReader(FilePath + "\\" + language + ".txt");
            while ((line = file.ReadLine()) != null)
            {
                String[] dataLine = line.Split(';');
                hashTableForLanguage.Add(dataLine[0], DP.getCleanString(dataLine[1]));
            }

            file.Close();
            return hashTableForLanguage;
        }
    }   
}
