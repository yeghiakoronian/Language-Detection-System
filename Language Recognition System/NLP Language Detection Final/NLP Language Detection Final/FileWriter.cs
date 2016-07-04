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
    class FileWriter
    {
        String Desktop;
        String[] lettersUniGram = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',');
        String[] lettersBiGram = "AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AP,AQ,AR,AS,AT,AU,AV,AW,AX,AY,AZ,BA,BB,BC,BD,BE,BF,BG,BH,BI,BJ,BK,BL,BM,BN,BO,BP,BQ,BR,BS,BT,BU,BV,BW,BX,BY,BZ,CA,CB,CC,CD,CE,CF,CG,CH,CI,CJ,CK,CL,CM,CN,CO,CP,CQ,CR,CS,CT,CU,CV,CW,CX,CY,CZ,DA,DB,DC,DD,DE,DF,DG,DH,DI,DJ,DK,DL,DM,DN,DO,DP,DQ,DR,DS,DT,DU,DV,DW,DX,DY,DZ,EA,EB,EC,ED,EE,EF,EG,EH,EI,EJ,EK,EL,EM,EN,EO,EP,EQ,ER,ES,ET,EU,EV,EW,EX,EY,EZ,FA,FB,FC,FD,FE,FF,FG,FH,FI,FJ,FK,FL,FM,FN,FO,FP,FQ,FR,FS,FT,FU,FV,FW,FX,FY,FZ,GA,GB,GC,GD,GE,GF,GG,GH,GI,GJ,GK,GL,GM,GN,GO,GP,GQ,GR,GS,GT,GU,GV,GW,GX,GY,GZ,HA,HB,HC,HD,HE,HF,HG,HH,HI,HJ,HK,HL,HM,HN,HO,HP,HQ,HR,HS,HT,HU,HV,HW,HX,HY,HZ,IA,IB,IC,ID,IE,IF,IG,IH,II,IJ,IK,IL,IM,IN,IO,IP,IQ,IR,IS,IT,IU,IV,IW,IX,IY,IZ,JA,JB,JC,JD,JE,JF,JG,JH,JI,JJ,JK,JL,JM,JN,JO,JP,JQ,JR,JS,JT,JU,JV,JW,JX,JY,JZ,KA,KB,KC,KD,KE,KF,KG,KH,KI,KJ,KK,KL,KM,KN,KO,KP,KQ,KR,KS,KT,KU,KV,KW,KX,KY,KZ,LA,LB,LC,LD,LE,LF,LG,LH,LI,LJ,LK,LL,LM,LN,LO,LP,LQ,LR,LS,LT,LU,LV,LW,LX,LY,LZ,MA,MB,MC,MD,ME,MF,MG,MH,MI,MJ,MK,ML,MM,MN,MO,MP,MQ,MR,MS,MT,MU,MV,MW,MX,MY,MZ,NA,NB,NC,ND,NE,NF,NG,NH,NI,NJ,NK,NL,NM,NN,NO,NP,NQ,NR,NS,NT,NU,NV,NW,NX,NY,NZ,OA,OB,OC,OD,OE,OF,OG,OH,OI,OJ,OK,OL,OM,ON,OO,OP,OQ,OR,OS,OT,OU,OV,OW,OX,OY,OZ,PA,PB,PC,PD,PE,PF,PG,PH,PI,PJ,PK,PL,PM,PN,PO,PP,PQ,PR,PS,PT,PU,PV,PW,PX,PY,PZ,QA,QB,QC,QD,QE,QF,QG,QH,QI,QJ,QK,QL,QM,QN,QO,QP,QQ,QR,QS,QT,QU,QV,QW,QX,QY,QZ,RA,RB,RC,RD,RE,RF,RG,RH,RI,RJ,RK,RL,RM,RN,RO,RP,RQ,RR,RS,RT,RU,RV,RW,RX,RY,RZ,SA,SB,SC,SD,SE,SF,SG,SH,SI,SJ,SK,SL,SM,SN,SO,SP,SQ,SR,SS,ST,SU,SV,SW,SX,SY,SZ,TA,TB,TC,TD,TE,TF,TG,TH,TI,TJ,TK,TL,TM,TN,TO,TP,TQ,TR,TS,TT,TU,TV,TW,TX,TY,TZ,UA,UB,UC,UD,UE,UF,UG,UH,UI,UJ,UK,UL,UM,UN,UO,UP,UQ,UR,US,UT,UU,UV,UW,UX,UY,UZ,VA,VB,VC,VD,VE,VF,VG,VH,VI,VJ,VK,VL,VM,VN,VO,VP,VQ,VR,VS,VT,VU,VV,VW,VX,VY,VZ,WA,WB,WC,WD,WE,WF,WG,WH,WI,WJ,WK,WL,WM,WN,WO,WP,WQ,WR,WS,WT,WU,WV,WW,WX,WY,WZ,XA,XB,XC,XD,XE,XF,XG,XH,XI,XJ,XK,XL,XM,XN,XO,XP,XQ,XR,XS,XT,XU,XV,XW,XX,XY,XZ,YA,YB,YC,YD,YE,YF,YG,YH,YI,YJ,YK,YL,YM,YN,YO,YP,YQ,YR,YS,YT,YU,YV,YW,YX,YY,YZ,ZA,ZB,ZC,ZD,ZE,ZF,ZG,ZH,ZI,ZJ,ZK,ZL,ZM,ZN,ZO,ZP,ZQ,ZR,ZS,ZT,ZU,ZV,ZW,ZX,ZY,ZZ".Split(',');
        StreamWriter uniWriter, biWriter,Writer;

        Hashtable keyValue = new Hashtable();
        Hashtable keyValue2 = new Hashtable();


        public FileWriter()
        {
            Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            uniWriter = new StreamWriter(Desktop + "\\" + "unigramLM.txt");
            biWriter = new StreamWriter(Desktop + "\\" + "bigramLM.txt");
            keyValue.Add("'eu';", "Basque"); keyValue.Add("'ca';", "Catalan"); keyValue.Add("'gl';", "Galician"); keyValue.Add("'es';", "Spanish");
            keyValue.Add("'en';", "English"); keyValue.Add("'pt';", "Portuguese");

            keyValue2.Add("eu", "Basque"); keyValue2.Add("ca", "Catalan"); keyValue2.Add("gl", "Galician"); keyValue2.Add("es", "Spanish");
            keyValue2.Add("en", "English"); keyValue2.Add("pt", "Portuguese");
        }


        public FileWriter(String fileName)
        {
            Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Writer = new StreamWriter(Desktop + "\\" +fileName +".txt");
             keyValue.Add("'eu';", "Basque"); keyValue.Add("'ca';", "Catalan"); keyValue.Add("'gl';", "Galician"); keyValue.Add("'es';", "Spanish");
            keyValue.Add("'en';", "English"); keyValue.Add("'pt';", "Portuguese");

            keyValue2.Add("eu", "Basque"); keyValue2.Add("ca", "Catalan"); keyValue2.Add("gl", "Galician"); keyValue2.Add("es", "Spanish");
            keyValue2.Add("en", "English"); keyValue2.Add("pt", "Portuguese");
        }



        public void resultsWriter(String Data)
        {
            Writer.Write(Data);
            Data = null;
            Writer.WriteLine();
            Writer.WriteLine();
            Writer.Flush();
        }


        public void writeBiGram(DataTable Table, String Language, String Smoothed, Double FrequencySum)
        {
            Hashtable languageTable = Language.Contains(";") ? keyValue : keyValue2;
            int counter = 0;
            int j = 0;
            StringBuilder stringTOWriteFile = new StringBuilder();
            stringTOWriteFile.Append("BiGram For Language = " + languageTable[Language] + "     Smoothed = " + Smoothed + "     N = " + FrequencySum).Append("\n");
            string formatString = "{0,10}";
            for (int i = 0; i < lettersUniGram.Length; i++)
                stringTOWriteFile.Append(string.Format(formatString, lettersUniGram[i]));
            //Console.Write(formatString, lettersUniGram[i]);
            // Console.WriteLine();
            stringTOWriteFile.Append("\n");
            for (int i = 0; i < lettersUniGram.Length; i++)
            {
                stringTOWriteFile.Append(lettersUniGram[i]);
                //Console.Write(lettersUniGram[i]);

                while (j < (lettersUniGram.Length + counter))
                {
                    stringTOWriteFile.Append(string.Format("{0,10}", Table.Rows[j]["FREQUENCY"].ToString()));
                    //Console.Write("{0,5}", Table.Rows[j]["FREQUENCY"].ToString());
                    j++;
                }
                counter += 26;
                stringTOWriteFile.Append("\n");
                Console.WriteLine();
            }
            // Console.WriteLine(stringTOWriteFile);
            biWriter.Write(stringTOWriteFile);
            stringTOWriteFile = null;
            biWriter.WriteLine();
            biWriter.WriteLine();
            biWriter.Flush();
        }


        public void writeUniGram(DataTable Table, String Language, String Smoothed, Double FrequencySum)
        {
            Hashtable languageTable = Language.Contains(";") ? keyValue : keyValue2;
            StringBuilder stringTOWriteFile = new StringBuilder();
            stringTOWriteFile.Append("UniGram For Language = " + languageTable[Language] + "     Smoothed = " + Smoothed + "     N = " + FrequencySum).Append("\n");
            for (int i = 0; i < lettersUniGram.Length; i++)
                stringTOWriteFile.Append(string.Format("{0,-10}", lettersUniGram[i])).Append(string.Format("{0,-10}", Table.Rows[i]["FREQUENCY"].ToString())).Append("\n");
            //Console.WriteLine(stringTOWriteFile);
            uniWriter.Write(stringTOWriteFile);
            stringTOWriteFile = null;
            uniWriter.WriteLine();
            uniWriter.WriteLine();
            uniWriter.Flush();
        }


        public void writeNGram(Hashtable Table, String Language, String Smoothed, Double FrequencySum,String Gram)
        {
            Hashtable languageTable = Language.Contains(";") ? keyValue : keyValue2;
            StringBuilder stringTOWriteFile = new StringBuilder();
            stringTOWriteFile.Append(Gram+" for Language = " + languageTable[Language] + "     Smoothed = " + Smoothed + "     N = " + FrequencySum).Append("\n");
            Dictionary<String, Double> dict = new Dictionary<String, Double>();
            foreach (DictionaryEntry kvp in Table)
                dict.Add((String)kvp.Key, (Double)kvp.Value);
            var items = from pair in dict
                        orderby pair.Value descending
                        select pair;
            int counter=0;
            foreach (KeyValuePair<String, Double> pair in items)
            {
                if (counter==50)
                   break;
                stringTOWriteFile.Append(String.Format("{0}          {1}", pair.Key, pair.Value)).Append("\n");
                counter++;
            }
            
            //Console.WriteLine(stringTOWriteFile);
            biWriter.Write(stringTOWriteFile);
            stringTOWriteFile = null;
            biWriter.WriteLine();
            biWriter.WriteLine();
            biWriter.Flush();
        }


        public void closeAnalysisWriter()
        {
            Writer.Close();
        }



        public void closeWriter()
        {
           
            uniWriter.Close();
            biWriter.Close();
        }
    }
}
