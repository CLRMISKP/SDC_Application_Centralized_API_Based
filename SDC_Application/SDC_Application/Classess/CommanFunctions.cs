using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDC_Application.Classess
{
    class CommanFunctions
    {


        public decimal RaqbaToSft(int Kanal, int Marla, decimal Sarsai)
        {
            
          decimal RaqbaToSft=((((Kanal*20)+Marla)*(decimal)272.25)+(Sarsai*(decimal)30.25));
          return RaqbaToSft;
        }
        public string SFTtoRqba(int Kanal, int Marla, decimal Sarsai)
        {
            string[] raqba = new string[3];
            int retKanal = 0;
            int retMarla = 0;
            decimal sft = 0;
            decimal retSarsai = 0;

            decimal PersonRaqba = ((Kanal * 20 + Marla) * (decimal)272.25) + (Sarsai * (decimal)30.25);
            if (PersonRaqba >= (decimal)272.25)
                {
                    sft = PersonRaqba % (decimal)272.25;
                    retMarla = Convert.ToInt32((PersonRaqba - sft) / (decimal)272.25);

                    if (retMarla >= 20)
                    {
                        retKanal = (retMarla - (retMarla % 20)) / 20;
                        retMarla = retMarla % 20;
                        }
                    else
                    {
                        retKanal = 0;
                    }

                }
                 else
                {
                    retMarla = 0;
                    retKanal = 0;
                  
                }
                if (sft > 0)
                {
                    if (sft >= 272)
                    {
                        retMarla = retMarla + 1;
                        sft = sft - 272;
                    }
                    retSarsai =Math.Round(sft / (decimal)30.25, 4);
                }
          return retKanal.ToString()+"-"+retMarla.ToString()+"-"+Math.Round(sft).ToString();
        }


        public float CalculatedHisaFromArea(float KulHissay, float FarokhtHissay, int Kulkanal, int KulMarla, float KulSarsai, float KulFeet, int FarokhKanal, int FarokhMarla, float FarokhSarsasi, float FarokhFeet)
        {
            float raqbainSft = (Kulkanal * 20 * (float)272.25) + (KulMarla * (float)272.25) + KulFeet; //+ ((ksarsai / 9) * 272)
            float bRaqbaInSft = (FarokhKanal * 20 * (float)272.25) + (FarokhMarla * (float)272.25) + FarokhFeet;
            float bHissay = 0;
            if (raqbainSft != 0 && bRaqbaInSft != 0)
            {
                bHissay = (KulHissay * bRaqbaInSft) / raqbainSft;
            }
            return bHissay;
        }

        public string[] CalculatedAreaFromHisa(float KulHissay, float FarokhtHissay, int Kulkanal, int KulMarla, float KulSarsai, float KulFeet)
        {
            float raqbainSft =float.Parse(((Kulkanal * 20 * (float)272.25) + (KulMarla * (float)272.25) + (KulSarsai * 30.25)).ToString());
         
           string[] raqba = new string[4];
            ////---Owners raqba


           float raqbainSft1 =float.Parse(((Kulkanal * 20 * (float)272.25) + (KulMarla * (float)272.25) + (KulSarsai * 30.25)).ToString()); // sarsai not included in raqba
            ////Owners sold raqba in sft
           float sraqbainsft = 0;
         if (KulHissay != 0 && FarokhtHissay != 0)
         {
             sraqbainsft = (raqbainSft1 / KulHissay) * FarokhtHissay;
         }

            ////owners sold raqba in kanal , marla etc.
         if (sraqbainsft != 0)
         {
             int remsft = 0;
             int skanal = 0;
             int smarla = 0;
             int remMarla = 0;
             float ssft = 0;
             float ssarsai = 0;
             if (sraqbainsft > (float)272.25)
             {
                 remsft = Convert.ToInt32(sraqbainsft % (float)272.25);
                 smarla = Convert.ToInt32((sraqbainsft - remsft) / (float)272.25);
             }
             else
             {
                 remsft = Convert.ToInt32(sraqbainsft);
             }

             if (smarla >= 20)
             {
                 remMarla = smarla % 20;
                 skanal = (smarla - remMarla) / 20;
             }
             else
             {
             remMarla = smarla;
             }
             raqba[0] = skanal.ToString();
             raqba[1] = remMarla.ToString();
             raqba[2] = Math.Round(remsft / (float)30.25, 7).ToString();//(remsft/30.25).ToString();
             raqba[3] = remsft.ToString();
             
         }
         return raqba;
        }

       
    }


    ////
        
    ////
}
