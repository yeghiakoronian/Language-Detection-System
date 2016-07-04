using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP_Language_Detection_Final
{
    class FetchFromDB
    {
        MySqlConnection Connection = new MySqlConnection("host=localhost;user=root;password=1234;database=tweetngram;");
        String TrainingTemplateQuery = "SELECT TWEET FROM TRAININGTWEETS WHERE LANGUAGE=";
        String TestingTemplateQuery = "SELECT TWEET FROM TESTINGTWEETS  WHERE LANGUAGE=";


        public DataTable getTrainingDataFor(String Language)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand Command = new MySqlCommand(TrainingTemplateQuery + Language, Connection);
            Connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(Command);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }



        public DataTable getTestingDataFor(String Language)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand Command = new MySqlCommand(TestingTemplateQuery + Language, Connection);
            Connection.Open();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(Command);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }



        public void closeConnection()
        {
            if (Connection != null)
                Connection.Close();
        }



    }
}
