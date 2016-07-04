using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP_Language_Detection_Final
{
    class NaiveBayesClassifier
    {
        String Tweet;
        //String Language;
        int totalTweets;
        int[] countOfTweetsinTraining;
        Dictionary<String, LanguageObject> gramDictionary;

        public NaiveBayesClassifier(int[] countOfTweetsinTraining, int totalTweets, Dictionary<String, LanguageObject> gramDictionary)
        {
            //this.Tweet = Tweet;
            //this.Language = Language;
            this.countOfTweetsinTraining = countOfTweetsinTraining;
            this.totalTweets = totalTweets;
            this.gramDictionary = gramDictionary;
        }


        public Double[] ApplyBayesOnUnigram(String Tweet)
        {
            String[] Languages = "eu,ca,gl,es,en,pt".Split(',');
            Double[] UniConfidence = new Double[gramDictionary.Count];
            for (int i = 0; i < gramDictionary.Count; i++)
            {
                UniConfidence[i] = Math.Log10((double)countOfTweetsinTraining[i] / totalTweets);
                for (int j = 0; j < Tweet.Length; j++)
                {
                    Hashtable sh = gramDictionary[Languages[i]].getProbabilitySmoothedUnigram();
                    String letter = Tweet[j].ToString();
                    double probabilityOfLetter = Convert.ToDouble(sh[letter]);
                    double logProbabilityOfLetter = Math.Log10(probabilityOfLetter);
                   // double probability = Convert.ToDouble(gramDictionary[Languages[i]].getProbabilitySmoothedUnigram()[Tweet[i].ToString()]);
                    UniConfidence[i] = UniConfidence[i] + logProbabilityOfLetter;
                }
                
            }
            return UniConfidence;

        }


        public int getMaxConfidence(Double[] arrayOfConfidence)
        {
            double maxValue = arrayOfConfidence.Max();
            int maxIndex = arrayOfConfidence.ToList().IndexOf(maxValue);
            return maxIndex;
        }


        public double[] ApplyBayesOnBigram(string Tweet)
        {
            String[] Languages = "eu,ca,gl,es,en,pt".Split(',');
            Double[] BiConfidence = new Double[gramDictionary.Count];
            for (int i = 0; i < gramDictionary.Count; i++)
            {
                BiConfidence[i] = Math.Log10((double)countOfTweetsinTraining[i] / totalTweets);
                for (int j = 0; j < Tweet.Length-1; j++)
                {
                    Hashtable sh = gramDictionary[Languages[i]].getProbabilitySmoothedBigram();
                    String letter = Tweet[j].ToString() + "" + Tweet[j+1].ToString();
                    double probabilityOf2Letters = Convert.ToDouble(sh[letter]);
                    double logProbabilityOfLetter = Math.Log10(probabilityOf2Letters);
                    // double probability = Convert.ToDouble(gramDictionary[Languages[i]].getProbabilitySmoothedUnigram()[Tweet[i].ToString()]);
                    BiConfidence[i] = BiConfidence[i] + logProbabilityOfLetter;
                }

            }
            return BiConfidence;
        }
    }
}
