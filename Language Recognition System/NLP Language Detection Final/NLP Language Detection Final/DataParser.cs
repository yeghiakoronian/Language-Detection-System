using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NLP_Language_Detection_Final
{
    class DataParser
    {


        public String removeDiacritics(String str)
        {
            //Console.WriteLine(str.Length);
            if (str == null) return null;
            var chars =
                from c in str.Normalize(NormalizationForm.FormD).ToCharArray()
                let uc = CharUnicodeInfo.GetUnicodeCategory(c)
                where uc != UnicodeCategory.NonSpacingMark
                select c;

            var cleanStr = new String(chars.ToArray()).Normalize(NormalizationForm.FormC);
            //Console.WriteLine(cleanStr.Length);
            return cleanStr;
        }



        public String removeEmojiSpaceAndMakeUpperCase(String s)
        {
            // return Regex.Replace(s, @"[^A-Za-z0-9]+", "").ToUpper();
            return Regex.Replace(s, @"[^A-Za-z]+", "").ToUpper();
        }


        public DataTable getCleanTable(DataTable oldTable)
        {
            DataTable cleanTable = new DataTable();
            cleanTable.Columns.Add("TWEET", typeof(String));
            for (int row = 0; row < oldTable.Rows.Count; row++)
                cleanTable.Rows.Add(removeEmojiSpaceAndMakeUpperCase(removeDiacritics(oldTable.Rows[row]["TWEET"].ToString())));
            return cleanTable;
        }


        public String getCleanString(String Tweets)
        {
            return removeEmojiSpaceAndMakeUpperCase(removeDiacritics(Tweets));
        }






    }
}
