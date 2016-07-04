using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLP_Language_Detection_Final
{
    class NgramBuilder
    {
        String[] lettersUniGram = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',');
        int uniGramV, biGramV;
        String[] lettersBiGram = "AA,AB,AC,AD,AE,AF,AG,AH,AI,AJ,AK,AL,AM,AN,AO,AP,AQ,AR,AS,AT,AU,AV,AW,AX,AY,AZ,BA,BB,BC,BD,BE,BF,BG,BH,BI,BJ,BK,BL,BM,BN,BO,BP,BQ,BR,BS,BT,BU,BV,BW,BX,BY,BZ,CA,CB,CC,CD,CE,CF,CG,CH,CI,CJ,CK,CL,CM,CN,CO,CP,CQ,CR,CS,CT,CU,CV,CW,CX,CY,CZ,DA,DB,DC,DD,DE,DF,DG,DH,DI,DJ,DK,DL,DM,DN,DO,DP,DQ,DR,DS,DT,DU,DV,DW,DX,DY,DZ,EA,EB,EC,ED,EE,EF,EG,EH,EI,EJ,EK,EL,EM,EN,EO,EP,EQ,ER,ES,ET,EU,EV,EW,EX,EY,EZ,FA,FB,FC,FD,FE,FF,FG,FH,FI,FJ,FK,FL,FM,FN,FO,FP,FQ,FR,FS,FT,FU,FV,FW,FX,FY,FZ,GA,GB,GC,GD,GE,GF,GG,GH,GI,GJ,GK,GL,GM,GN,GO,GP,GQ,GR,GS,GT,GU,GV,GW,GX,GY,GZ,HA,HB,HC,HD,HE,HF,HG,HH,HI,HJ,HK,HL,HM,HN,HO,HP,HQ,HR,HS,HT,HU,HV,HW,HX,HY,HZ,IA,IB,IC,ID,IE,IF,IG,IH,II,IJ,IK,IL,IM,IN,IO,IP,IQ,IR,IS,IT,IU,IV,IW,IX,IY,IZ,JA,JB,JC,JD,JE,JF,JG,JH,JI,JJ,JK,JL,JM,JN,JO,JP,JQ,JR,JS,JT,JU,JV,JW,JX,JY,JZ,KA,KB,KC,KD,KE,KF,KG,KH,KI,KJ,KK,KL,KM,KN,KO,KP,KQ,KR,KS,KT,KU,KV,KW,KX,KY,KZ,LA,LB,LC,LD,LE,LF,LG,LH,LI,LJ,LK,LL,LM,LN,LO,LP,LQ,LR,LS,LT,LU,LV,LW,LX,LY,LZ,MA,MB,MC,MD,ME,MF,MG,MH,MI,MJ,MK,ML,MM,MN,MO,MP,MQ,MR,MS,MT,MU,MV,MW,MX,MY,MZ,NA,NB,NC,ND,NE,NF,NG,NH,NI,NJ,NK,NL,NM,NN,NO,NP,NQ,NR,NS,NT,NU,NV,NW,NX,NY,NZ,OA,OB,OC,OD,OE,OF,OG,OH,OI,OJ,OK,OL,OM,ON,OO,OP,OQ,OR,OS,OT,OU,OV,OW,OX,OY,OZ,PA,PB,PC,PD,PE,PF,PG,PH,PI,PJ,PK,PL,PM,PN,PO,PP,PQ,PR,PS,PT,PU,PV,PW,PX,PY,PZ,QA,QB,QC,QD,QE,QF,QG,QH,QI,QJ,QK,QL,QM,QN,QO,QP,QQ,QR,QS,QT,QU,QV,QW,QX,QY,QZ,RA,RB,RC,RD,RE,RF,RG,RH,RI,RJ,RK,RL,RM,RN,RO,RP,RQ,RR,RS,RT,RU,RV,RW,RX,RY,RZ,SA,SB,SC,SD,SE,SF,SG,SH,SI,SJ,SK,SL,SM,SN,SO,SP,SQ,SR,SS,ST,SU,SV,SW,SX,SY,SZ,TA,TB,TC,TD,TE,TF,TG,TH,TI,TJ,TK,TL,TM,TN,TO,TP,TQ,TR,TS,TT,TU,TV,TW,TX,TY,TZ,UA,UB,UC,UD,UE,UF,UG,UH,UI,UJ,UK,UL,UM,UN,UO,UP,UQ,UR,US,UT,UU,UV,UW,UX,UY,UZ,VA,VB,VC,VD,VE,VF,VG,VH,VI,VJ,VK,VL,VM,VN,VO,VP,VQ,VR,VS,VT,VU,VV,VW,VX,VY,VZ,WA,WB,WC,WD,WE,WF,WG,WH,WI,WJ,WK,WL,WM,WN,WO,WP,WQ,WR,WS,WT,WU,WV,WW,WX,WY,WZ,XA,XB,XC,XD,XE,XF,XG,XH,XI,XJ,XK,XL,XM,XN,XO,XP,XQ,XR,XS,XT,XU,XV,XW,XX,XY,XZ,YA,YB,YC,YD,YE,YF,YG,YH,YI,YJ,YK,YL,YM,YN,YO,YP,YQ,YR,YS,YT,YU,YV,YW,YX,YY,YZ,ZA,ZB,ZC,ZD,ZE,ZF,ZG,ZH,ZI,ZJ,ZK,ZL,ZM,ZN,ZO,ZP,ZQ,ZR,ZS,ZT,ZU,ZV,ZW,ZX,ZY,ZZ".Split(',');
        double totalFrequency;
        Hashtable HashTableUniGram, HashTableBiGram;


        public NgramBuilder()
        {
            HashTableUniGram = new Hashtable();
            HashTableBiGram = new Hashtable();
            uniGramV = lettersUniGram.Length;
            biGramV = lettersBiGram.Length;

            for (int i = 0; i < uniGramV; i++)
                HashTableUniGram.Add(lettersUniGram[i], 0);

            for (int i = 0; i < biGramV; i++)
                HashTableBiGram.Add(lettersBiGram[i], 0);
        }



        public Hashtable TableToHashGram(DataTable Table, int Gram)
        {
            Hashtable tableTOReturn = Gram == 1 ? HashTableUniGram : HashTableBiGram;
            if (Gram == 1)
            {
                for (int row = 0; row < Table.Rows.Count; row++)
                    for (int i = 0; i < Table.Rows[row]["TWEET"].ToString().Length; i++)
                    {
                        String cell = Table.Rows[row]["TWEET"].ToString()[i].ToString();
                        tableTOReturn[cell] = (int)tableTOReturn[cell] + 1;
                    }
            }
            else
            {
                for (int row = 0; row < Table.Rows.Count; row++)
                    for (int i = 0; i < Table.Rows[row]["TWEET"].ToString().Length - 1; i++)
                    {
                        String cell = Table.Rows[row]["TWEET"].ToString()[i] + "" + Table.Rows[row]["TWEET"].ToString()[i + 1];
                        tableTOReturn[cell] = (int)tableTOReturn[cell] + 1;
                    }
            }
            return tableTOReturn;
        }



        public Hashtable TableToHashGram(String Tweets, int Gram)
        {
            Hashtable tableTOReturn = Gram == 1 ? HashTableUniGram : HashTableBiGram;
            if (Gram == 1)
            {
                for (int i = 0; i < Tweets.Length; i++)
                {
                    String cell = Tweets[i].ToString();
                    tableTOReturn[cell] = (int)tableTOReturn[cell] + 1;
                }
            }
            else
            {
                for (int i = 0; i < Tweets.Length - 1; i++)
                {
                    String cell = Tweets[i].ToString() + "" + Tweets[i+1].ToString();
                    tableTOReturn[cell] = (int)tableTOReturn[cell] + 1;
                }
            }
            return tableTOReturn;
        }


        public DataTable HashToTable(Hashtable HashTable, int Gram)
        {
            totalFrequency = 0;
            DataTable Table = new DataTable();
            Table.Columns.Add("LETTER", typeof(String));
            Table.Columns.Add("FREQUENCY", typeof(int));
            Hashtable tableTOReturn = Gram == 1 ? HashTableUniGram : HashTableBiGram;
            String[] letterGram = Gram == 1 ? lettersUniGram : lettersBiGram;
            for (int i = 0; i < letterGram.Length; i++)
            {
                Table.Rows.Add(letterGram[i], HashTable[letterGram[i]]);
                totalFrequency = totalFrequency + Convert.ToInt64(HashTable[letterGram[i]]);
            }
            totalFrequency = Math.Round(totalFrequency, 3);
            return Table;
        }



        public DataTable GetGram(DataTable Table, int Gram)
        {
            return HashToTable(TableToHashGram(Table, Gram), Gram);
        }





        public DataTable GetGram(String Tweets, int Gram)
        {
            return HashToTable(TableToHashGram(Tweets, Gram), Gram);
        }


        public double getTotalFrequency()
        {
            return totalFrequency;
        }


        public DataTable applySmoothing(DataTable Table, double SmoothingFactor)
        {
            totalFrequency = 0;
            DataTable smoothedTable = new DataTable();
            smoothedTable.Columns.Add("LETTER", typeof(String));
            smoothedTable.Columns.Add("FREQUENCY", typeof(Double));


            for (int row = 0; row < Table.Rows.Count; row++)
            {
                totalFrequency = totalFrequency + Convert.ToDouble(Table.Rows[row]["FREQUENCY"]) + SmoothingFactor;
                smoothedTable.Rows.Add(Table.Rows[row]["LETTER"].ToString(), Convert.ToDouble(Table.Rows[row]["FREQUENCY"]) + SmoothingFactor);
            }

            totalFrequency = Math.Round(totalFrequency, 3);
            return smoothedTable;
        }


        public Hashtable getHashUnigram()
        {
            return HashTableUniGram;
        }


        public Hashtable getHashBigram()
        {
            return HashTableBiGram;
        }




        public DataTable ConvertTableToProbabilityTable(DataTable NGram, double NGramN)
        {
            DataTable ProbabilityTable = new DataTable();
            ProbabilityTable.Columns.Add("LETTER", typeof(String));
            ProbabilityTable.Columns.Add("FREQUENCY", typeof(Double));

            for (int row = 0; row < NGram.Rows.Count; row++)
                ProbabilityTable.Rows.Add(NGram.Rows[row]["LETTER"].ToString(),Math.Round(  Convert.ToDouble(Convert.ToDouble(NGram.Rows[row]["FREQUENCY"]) / NGramN),7));
           
           
            return ProbabilityTable;
        }



        public Hashtable ConvertProbTabletoHashTable(DataTable NGram)
        {
            Hashtable Hash = new Hashtable();
            for (int row = 0; row < NGram.Rows.Count; row++)
                Hash.Add(NGram.Rows[row]["LETTER"].ToString(),Convert.ToDouble(NGram.Rows[row]["FREQUENCY"]));
            return Hash;
        }
    }
}
