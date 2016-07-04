using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLP_Language_Detection_Final
{

    public partial class MainForm : Form
    {
        Dictionary<String, LanguageObject> gramDictionary = new Dictionary<string,LanguageObject>() ;
        Double[,] labelingUniMatrixFrequency = new Double[6, 6];
        Double[,] labelingBiMatrixFrequency = new Double[6, 6];
        String[] Languages =    "eu,ca,gl,es,en,pt".Split(',');
        String[] LanguagesFull = "Basque    ,Catalan   ,Galician  ,Spanish   ,English   ,Portuguese".Split(',');
        int totalTweet = 18318;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_buildNgramfromDB_Click(object sender, EventArgs e)
        {

            String[] Languages = "'eu';,'ca';,'gl';,'es';,'en';,'pt';".Split(',');
            FileWriter FW = new FileWriter();
            for (int i = 0; i < Languages.Length; i++)
            {
                FetchFromDB fetchFromDatabase = new FetchFromDB();
                DataTable dataTable = fetchFromDatabase.getTrainingDataFor(Languages[i]);
                fetchFromDatabase.closeConnection();

                DataParser DP = new DataParser();
                DataTable cleanTable = new DataTable();
                cleanTable = DP.getCleanTable(dataTable);

                NgramBuilder NB = new NgramBuilder();

                DataTable uniGram = new DataTable();
                uniGram = NB.GetGram(cleanTable, 1);
                double uniGramN = NB.getTotalFrequency();

                DataTable smoothedUniGram = new DataTable();
                smoothedUniGram = NB.applySmoothing(uniGram, 0.1);
                double uniGramSmoothedN = NB.getTotalFrequency();



                DataTable biGram = new DataTable();
                biGram = NB.GetGram(cleanTable, 2);
                double biGramN = NB.getTotalFrequency();


                DataTable smoothedBiGram = new DataTable();
                smoothedBiGram = NB.applySmoothing(biGram, 0.1);
                double BiGramSmoothedN = NB.getTotalFrequency();

                //FileWriter FW = new FileWriter();

                FW.writeUniGram(uniGram, Languages[i], "False", uniGramN);
                FW.writeUniGram(smoothedUniGram, Languages[i], "True", uniGramSmoothedN);

                FW.writeBiGram(biGram, Languages[i], "False", biGramN);
                FW.writeBiGram(smoothedBiGram, Languages[i], "True", BiGramSmoothedN);

                MessageBox.Show("Done " + Languages[i]);

            }
            FW.closeWriter();

        }








        private void btn_buildNgramfromFile_Click(object sender, EventArgs e)
        {
            String[] Languages = "eu,ca,gl,es,en,pt".Split(',');
            FileWriter FW = new FileWriter();
            for (int i = 0; i < Languages.Length; i++)
            {
                FetchFromFolderFiles fetchFromFolder = new FetchFromFolderFiles("Trainingnlp");
                DataTable dataTable = fetchFromFolder.getTrainingDataFor(Languages[i]);
                

                DataParser DP = new DataParser();
                DataTable cleanTable = new DataTable();
                cleanTable = DP.getCleanTable(dataTable);

                NgramBuilder NB = new NgramBuilder();

                DataTable uniGram = new DataTable();
                uniGram = NB.GetGram(cleanTable, 1);
                double uniGramN = NB.getTotalFrequency();

                DataTable smoothedUniGram = new DataTable();
                smoothedUniGram = NB.applySmoothing(uniGram, 0.1);
                double uniGramSmoothedN = NB.getTotalFrequency();



                DataTable biGram = new DataTable();
                biGram = NB.GetGram(cleanTable, 2);
                double biGramN = NB.getTotalFrequency();


                DataTable smoothedBiGram = new DataTable();
                smoothedBiGram = NB.applySmoothing(biGram, 0.1);
                double BiGramSmoothedN = NB.getTotalFrequency();

                //FileWriter FW = new FileWriter();

                FW.writeUniGram(uniGram, Languages[i], "False", uniGramN);
                FW.writeUniGram(smoothedUniGram, Languages[i], "True", uniGramSmoothedN);

                FW.writeBiGram(biGram, Languages[i], "False", biGramN);
                FW.writeBiGram(smoothedBiGram, Languages[i], "True", BiGramSmoothedN);

                MessageBox.Show("Done " + Languages[i]);


            }
            FW.closeWriter();
        }

        private void btn_singleLineInput_Click(object sender, EventArgs e)
        {
            DataParser DP = new DataParser();
            String input = editBox_sinleInput.Text.ToString();
            String cleanString = DP.getCleanString(input);
        }

        private void btn_probabilityNgramfromFile_Click(object sender, EventArgs e)
        {
            
            
            FileWriter FW = new FileWriter();
            for (int i = 0; i < Languages.Length; i++)
            {

                gramDictionary.Add(Languages[i], new LanguageObject());
                FetchFromFolderFiles fetchFromFolder = new FetchFromFolderFiles("Trainingnlp");
                DataTable dataTable = fetchFromFolder.getTrainingDataFor(Languages[i]);


                DataParser DP = new DataParser();
                DataTable cleanTable = new DataTable();
                cleanTable = DP.getCleanTable(dataTable);

                NgramBuilder NB = new NgramBuilder();



                DataTable uniGram = new DataTable();
                uniGram = NB.GetGram(cleanTable, 1);
                double uniGramN = NB.getTotalFrequency();

                DataTable unSmoothedProbabilityUnigramDataTable = new DataTable();
                unSmoothedProbabilityUnigramDataTable = NB.ConvertTableToProbabilityTable(uniGram, uniGramN);
                Hashtable unSmoothedProbabilityUnigram = NB.ConvertProbTabletoHashTable(unSmoothedProbabilityUnigramDataTable);
                gramDictionary[Languages[i]].setProbabilityUnigram(unSmoothedProbabilityUnigram,uniGramN);

                DataTable smoothedUniGram = new DataTable();
                smoothedUniGram = NB.applySmoothing(uniGram, 0.1);
                double uniGramSmoothedN = NB.getTotalFrequency();

                DataTable SmoothedProbabilityUnigramDataTable = new DataTable();
                SmoothedProbabilityUnigramDataTable = NB.ConvertTableToProbabilityTable(smoothedUniGram, uniGramSmoothedN);
                Hashtable SmoothedProbabilityUnigram = NB.ConvertProbTabletoHashTable(SmoothedProbabilityUnigramDataTable);
                gramDictionary[Languages[i]].setSmoothedProbabilityUnigram(SmoothedProbabilityUnigram, uniGramSmoothedN);



                DataTable biGram = new DataTable();
                biGram = NB.GetGram(cleanTable, 2);
                double biGramN = NB.getTotalFrequency();

                DataTable UnSmoothedProbabilityBigramDataTable = new DataTable();
                UnSmoothedProbabilityBigramDataTable = NB.ConvertTableToProbabilityTable(biGram, biGramN);

                Hashtable UnSmoothedProbabilityBigram = NB.ConvertProbTabletoHashTable(UnSmoothedProbabilityBigramDataTable);
                gramDictionary[Languages[i]].setProbabilityBigram(UnSmoothedProbabilityBigram, biGramN);


                DataTable smoothedBiGram = new DataTable();
                smoothedBiGram = NB.applySmoothing(biGram, 0.1);
                double BiGramSmoothedN = NB.getTotalFrequency();

                DataTable SmoothedProbabilityBigramDataTable = new DataTable();
                SmoothedProbabilityBigramDataTable = NB.ConvertTableToProbabilityTable(smoothedBiGram, BiGramSmoothedN);

                Hashtable SmoothedProbabilityBigram = NB.ConvertProbTabletoHashTable(SmoothedProbabilityBigramDataTable);
                gramDictionary[Languages[i]].setSmoothedProbabilityBigram(SmoothedProbabilityBigram, BiGramSmoothedN);


                FW.writeUniGram(unSmoothedProbabilityUnigramDataTable, Languages[i], "False", uniGramN);
                FW.writeUniGram(SmoothedProbabilityUnigramDataTable, Languages[i], "True", uniGramSmoothedN);

                 

                FW.writeNGram(UnSmoothedProbabilityBigram,Languages[i],"False",biGramN,"BiGram");
                FW.writeNGram(SmoothedProbabilityBigram, Languages[i], "True", BiGramSmoothedN, "BiGram");
               // If you want matrix representation include this and remove the upper 2 lines
               // FW.writeBiGram(UnSmoothedProbabilityBigramDataTable, Languages[i], "False", biGramN);
               // FW.writeBiGram(SmoothedProbabilityBigramDataTable, Languages[i], "True", BiGramSmoothedN);

                


            }
            FW.closeWriter();
          
            MessageBox.Show("Done ");
        }

        private void btn_testDatafromFiles_Click(object sender, EventArgs e)
        {
            
            
            int[] countOfTrainingTweetforLanguage = { 374, 1493, 456, 12855, 971, 2169 };
           
            FileWriter uniGramResultWriter = new FileWriter("results-unigram");
            FileWriter biGramResultWriter = new FileWriter("results-bigram");
            StringBuilder builderUniResult = new StringBuilder();
            StringBuilder builderBiResult = new StringBuilder();
            builderUniResult.Append("TweetID" + "                   " + "Likely Language").Append("\n");
            builderBiResult.Append("TweetID" + "                    " + "Likely Language").Append("\n");
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                {
                    labelingUniMatrixFrequency[i, j] = 0.0;
                    labelingBiMatrixFrequency[i, j] = 0.0;
                }

                    for (int i = 0; i < Languages.Length; i++)
                    {


                        FetchFromFolderFiles fetchFromFolder = new FetchFromFolderFiles("Testingnlp");
                        Hashtable languageTweetsClean = new Hashtable();
                        languageTweetsClean = fetchFromFolder.getTestingDataFor(Languages[i]);

                        NaiveBayesClassifier NBC = new NaiveBayesClassifier(countOfTrainingTweetforLanguage, totalTweet, gramDictionary);
                        foreach (DictionaryEntry entry in languageTweetsClean)
                        {
                            Double[] uniConfidence = NBC.ApplyBayesOnUnigram(entry.Value.ToString());
                            int IndexOfMaxUniConfidence = NBC.getMaxConfidence(uniConfidence);
                            labelingUniMatrixFrequency[i, IndexOfMaxUniConfidence] = labelingUniMatrixFrequency[i, IndexOfMaxUniConfidence] + 1;
                            builderUniResult.Append(entry.Key.ToString() + "     " + Languages[IndexOfMaxUniConfidence]);
                            builderUniResult.Append("\n");

                            Double[] biConfidence = NBC.ApplyBayesOnBigram(entry.Value.ToString());
                            int IndexOfMaxBiiConfidence = NBC.getMaxConfidence(biConfidence);
                            labelingBiMatrixFrequency[i, IndexOfMaxBiiConfidence] = labelingBiMatrixFrequency[i, IndexOfMaxBiiConfidence] + 1;
                            builderBiResult.Append(entry.Key.ToString() + "     " + Languages[IndexOfMaxBiiConfidence]);
                            builderBiResult.Append("\n");

                        }
                        
                    }

                    uniGramResultWriter.resultsWriter(builderUniResult.ToString());
                    biGramResultWriter.resultsWriter(builderBiResult.ToString());
                    uniGramResultWriter.closeAnalysisWriter();
                    biGramResultWriter.closeAnalysisWriter();
                    MessageBox.Show("Done");
        }

        private void btn_generateAccuracyData_Click(object sender, EventArgs e)
        {
            FileWriter uniGramResultWriter = new FileWriter("analysis-unigram");
            FileWriter biGramResultWriter = new FileWriter("analysis-bigram");
            StringBuilder builderUniAnalysis = new StringBuilder();
            StringBuilder builderBiAnalysis = new StringBuilder();
            //int totalTweet = 18318;
            //labelingUniMatrixFrequency[i, j] = 0.0;
            //labelingBiMatrixFrequency[i, j] = 0.0;

            builderUniAnalysis.Append("Overall Accuracy of Unigram = " + Math.Round(((labelingUniMatrixFrequency[0, 0] + labelingUniMatrixFrequency[1, 1] + labelingUniMatrixFrequency[2, 2] + labelingUniMatrixFrequency[3, 3] + labelingUniMatrixFrequency[4,4]+labelingUniMatrixFrequency[5,5])*100),2)/totalTweet+"%");
            builderBiAnalysis.Append("Overall Accuracy of Bigram = " +  Math.Round(((labelingBiMatrixFrequency[0, 0] + labelingBiMatrixFrequency[1, 1] + labelingBiMatrixFrequency[2, 2] + labelingBiMatrixFrequency[3, 3] + labelingBiMatrixFrequency[4, 4] + labelingBiMatrixFrequency[5, 5])*100),2)/totalTweet+"%");
            builderBiAnalysis.Append("\n").Append("\n").Append("\n").Append("\n");
            builderUniAnalysis.Append("\n").Append("\n").Append("\n").Append("\n");

            builderUniAnalysis.Append("Accuracy of Language = " + LanguagesFull[0] + "   " +  Math.Round((labelingUniMatrixFrequency[0, 0]*100 )/  (labelingUniMatrixFrequency[0, 0]+labelingUniMatrixFrequency[0, 1]+labelingUniMatrixFrequency[0, 2]+labelingUniMatrixFrequency[0, 3]+labelingUniMatrixFrequency[0, 4]+labelingUniMatrixFrequency[0, 5]),2)+"%").Append("\n");
            builderUniAnalysis.Append("Accuracy of Language = " + LanguagesFull[1] + "   " +  Math.Round((labelingUniMatrixFrequency[1, 1]*100 ) / (labelingUniMatrixFrequency[1, 0]+labelingUniMatrixFrequency[1, 1]+labelingUniMatrixFrequency[1, 2]+labelingUniMatrixFrequency[1, 3]+labelingUniMatrixFrequency[1, 4]+labelingUniMatrixFrequency[1, 5]),2)+"%").Append("\n");
            builderUniAnalysis.Append("Accuracy of Language = " + LanguagesFull[2] + "   " +  Math.Round((labelingUniMatrixFrequency[2, 2]*100 ) / (labelingUniMatrixFrequency[2, 0]+labelingUniMatrixFrequency[2, 1]+labelingUniMatrixFrequency[2, 2]+labelingUniMatrixFrequency[2, 3]+labelingUniMatrixFrequency[2, 4]+labelingUniMatrixFrequency[2, 5]),2)+"%").Append("\n");
            builderUniAnalysis.Append("Accuracy of Language = " + LanguagesFull[3] + "   " +  Math.Round((labelingUniMatrixFrequency[3, 3]*100 ) / (labelingUniMatrixFrequency[3, 0]+labelingUniMatrixFrequency[3, 1]+labelingUniMatrixFrequency[3, 2]+labelingUniMatrixFrequency[3, 3]+labelingUniMatrixFrequency[3, 4]+labelingUniMatrixFrequency[3, 5]),2)+"%").Append("\n");
            builderUniAnalysis.Append("Accuracy of Language = " + LanguagesFull[4] + "   " +  Math.Round((labelingUniMatrixFrequency[4, 4]*100 ) / (labelingUniMatrixFrequency[4, 0]+labelingUniMatrixFrequency[4, 1]+labelingUniMatrixFrequency[4, 2]+labelingUniMatrixFrequency[4, 3]+labelingUniMatrixFrequency[4, 4]+labelingUniMatrixFrequency[4, 5]),2)+"%").Append("\n");
            builderUniAnalysis.Append("Accuracy of Language = " + LanguagesFull[5] + "   " +  Math.Round((labelingUniMatrixFrequency[5, 5]*100) /  (labelingUniMatrixFrequency[5, 0]+labelingUniMatrixFrequency[5, 1]+labelingUniMatrixFrequency[5, 2]+labelingUniMatrixFrequency[5, 3]+labelingUniMatrixFrequency[5, 4]+labelingUniMatrixFrequency[5, 5]),2)+"%").Append("\n").Append("\n").Append("\n");
            builderUniAnalysis.Append("Confusion Matrix for Unigram:").Append("\n");
            String row="                 ";
            Double[] uniRows = {(labelingUniMatrixFrequency[0, 0]+labelingUniMatrixFrequency[0, 1]+labelingUniMatrixFrequency[0, 2]+labelingUniMatrixFrequency[0, 3]+labelingUniMatrixFrequency[0, 4]+labelingUniMatrixFrequency[0, 5]),
                                (labelingUniMatrixFrequency[1, 0]+labelingUniMatrixFrequency[1, 1]+labelingUniMatrixFrequency[1, 2]+labelingUniMatrixFrequency[1, 3]+labelingUniMatrixFrequency[1, 4]+labelingUniMatrixFrequency[1, 5]),
                                (labelingUniMatrixFrequency[2, 0]+labelingUniMatrixFrequency[2, 1]+labelingUniMatrixFrequency[2, 2]+labelingUniMatrixFrequency[2, 3]+labelingUniMatrixFrequency[2, 4]+labelingUniMatrixFrequency[2, 5]),
                                (labelingUniMatrixFrequency[3, 0]+labelingUniMatrixFrequency[3, 1]+labelingUniMatrixFrequency[3, 2]+labelingUniMatrixFrequency[3, 3]+labelingUniMatrixFrequency[3, 4]+labelingUniMatrixFrequency[3, 5]),
                                (labelingUniMatrixFrequency[4, 0]+labelingUniMatrixFrequency[4, 1]+labelingUniMatrixFrequency[4, 2]+labelingUniMatrixFrequency[4, 3]+labelingUniMatrixFrequency[4, 4]+labelingUniMatrixFrequency[4, 5]),
                                (labelingUniMatrixFrequency[5, 0]+labelingUniMatrixFrequency[5, 1]+labelingUniMatrixFrequency[5, 2]+labelingUniMatrixFrequency[5, 3]+labelingUniMatrixFrequency[5, 4]+labelingUniMatrixFrequency[5, 5])};

                               
            for (int i = 0; i < 6; i++)
                row = row + LanguagesFull[i] + "           ";
            row = row + "\n";
            for (int i = 0; i < 6; i++)
            {
                row= row + LanguagesFull[i]+"       ";
                for (int j = 0; j < 6; j++)
                    row = row + Math.Round((labelingUniMatrixFrequency[i, j] * 100) / uniRows[i], 2)+"%" + "             ";
                row= row+"\n\n\n\n";
            }
            builderUniAnalysis.Append(row);
            uniGramResultWriter.resultsWriter(builderUniAnalysis.ToString());
            uniGramResultWriter.closeAnalysisWriter();

            builderBiAnalysis.Append("Accuracy of Language = " + LanguagesFull[0] + "   " +  Math.Round((labelingBiMatrixFrequency[0, 0] * 100) / (labelingBiMatrixFrequency[0, 0] + labelingBiMatrixFrequency[0, 1] + labelingBiMatrixFrequency[0, 2] + labelingBiMatrixFrequency[0, 3] + labelingBiMatrixFrequency[0, 4] + labelingBiMatrixFrequency[0, 5]),2) + "%").Append("\n");
            builderBiAnalysis.Append("Accuracy of Language = " + LanguagesFull[1] + "   " +  Math.Round((labelingBiMatrixFrequency[1, 1] * 100) / (labelingBiMatrixFrequency[1, 0] + labelingBiMatrixFrequency[1, 1] + labelingBiMatrixFrequency[1, 2] + labelingBiMatrixFrequency[1, 3] + labelingBiMatrixFrequency[1, 4] + labelingBiMatrixFrequency[1, 5]),2) + "%").Append("\n");
            builderBiAnalysis.Append("Accuracy of Language = " + LanguagesFull[2] + "   " +  Math.Round((labelingBiMatrixFrequency[2, 2] * 100) / (labelingBiMatrixFrequency[2, 0] + labelingBiMatrixFrequency[2, 1] + labelingBiMatrixFrequency[2, 2] + labelingBiMatrixFrequency[2, 3] + labelingBiMatrixFrequency[2, 4] + labelingBiMatrixFrequency[2, 5]),2) + "%").Append("\n");
            builderBiAnalysis.Append("Accuracy of Language = " + LanguagesFull[3] + "   " +  Math.Round((labelingBiMatrixFrequency[3, 3] * 100) / (labelingBiMatrixFrequency[3, 0] + labelingBiMatrixFrequency[3, 1] + labelingBiMatrixFrequency[3, 2] + labelingBiMatrixFrequency[3, 3] + labelingBiMatrixFrequency[3, 4] + labelingBiMatrixFrequency[3, 5]),2) + "%").Append("\n");
            builderBiAnalysis.Append("Accuracy of Language = " + LanguagesFull[4] + "   " +  Math.Round((labelingBiMatrixFrequency[4, 4] * 100) / (labelingBiMatrixFrequency[4, 0] + labelingBiMatrixFrequency[4, 1] + labelingBiMatrixFrequency[4, 2] + labelingBiMatrixFrequency[4, 3] + labelingBiMatrixFrequency[4, 4] + labelingBiMatrixFrequency[4, 5]),2) + "%").Append("\n");
            builderBiAnalysis.Append("Accuracy of Language = " + LanguagesFull[5] + "   " +  Math.Round((labelingBiMatrixFrequency[5, 5] * 100) / (labelingBiMatrixFrequency[5, 0] + labelingBiMatrixFrequency[5, 1] + labelingBiMatrixFrequency[5, 2] + labelingBiMatrixFrequency[5, 3] + labelingBiMatrixFrequency[5, 4] + labelingBiMatrixFrequency[5, 5]), 2) + "%").Append("\n").Append("\n").Append("\n");
            builderBiAnalysis.Append("Confusion Matrix for Bigram:").Append("\n");

            String row2 = "      ";
            Double[] BiRows = {(labelingBiMatrixFrequency[0, 0]+labelingBiMatrixFrequency[0, 1]+labelingBiMatrixFrequency[0, 2]+labelingBiMatrixFrequency[0, 3]+labelingBiMatrixFrequency[0, 4]+labelingBiMatrixFrequency[0, 5]),
                                (labelingBiMatrixFrequency[1, 0]+labelingBiMatrixFrequency[1, 1]+labelingBiMatrixFrequency[1, 2]+labelingBiMatrixFrequency[1, 3]+labelingBiMatrixFrequency[1, 4]+labelingBiMatrixFrequency[1, 5]),
                                (labelingBiMatrixFrequency[2, 0]+labelingBiMatrixFrequency[2, 1]+labelingBiMatrixFrequency[2, 2]+labelingBiMatrixFrequency[2, 3]+labelingBiMatrixFrequency[2, 4]+labelingBiMatrixFrequency[2, 5]),
                                (labelingBiMatrixFrequency[3, 0]+labelingBiMatrixFrequency[3, 1]+labelingBiMatrixFrequency[3, 2]+labelingBiMatrixFrequency[3, 3]+labelingBiMatrixFrequency[3, 4]+labelingBiMatrixFrequency[3, 5]),
                                (labelingBiMatrixFrequency[4, 0]+labelingBiMatrixFrequency[4, 1]+labelingBiMatrixFrequency[4, 2]+labelingBiMatrixFrequency[4, 3]+labelingBiMatrixFrequency[4, 4]+labelingBiMatrixFrequency[4, 5]),
                                (labelingBiMatrixFrequency[5, 0]+labelingBiMatrixFrequency[5, 1]+labelingBiMatrixFrequency[5, 2]+labelingBiMatrixFrequency[5, 3]+labelingBiMatrixFrequency[5, 4]+labelingBiMatrixFrequency[5, 5])};


            for (int i = 0; i < 6; i++)
                row2 = row2 + LanguagesFull[i] + "              ";
            row2 = row2 + "\n";
            for (int i = 0; i < 6; i++)
            {
                row2 = row2 + LanguagesFull[i] + "       ";
                for (int j = 0; j < 6; j++)
                    row2 = row2 + Math.Round((labelingBiMatrixFrequency[i, j] * 100) / BiRows[i], 2) + "%" + "             ";
                row2 = row2 + "\n\n\n\n";
            }
            builderBiAnalysis.Append(row2);
            biGramResultWriter.resultsWriter(builderBiAnalysis.ToString());
            biGramResultWriter.closeAnalysisWriter();
            MessageBox.Show("Done");

        }
    }
}
