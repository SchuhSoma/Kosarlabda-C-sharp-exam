using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchuhS_Kosarlabdaliga
{
    class Program
    {
        static List<Kosarlabda> KosarlabdaList;
        static List<string> HelyszinekList;
        static Dictionary<string, int> HelyszinSatisztika;
        static List<int> PontokList;
        static Dictionary<string, int> RendezettStatisztika;
        static void Main(string[] args)
        {
            Console.WriteLine("\n----------------------------\n");
            Feladat2Beolvasas(); Console.WriteLine("\n----------------------------\n");
            Feladat3(); Console.WriteLine("\n----------------------------\n");
            Feladat4(); Console.WriteLine("\n----------------------------\n");
            Feladat5(); Console.WriteLine("\n----------------------------\n");
            Feladat6(); Console.WriteLine("\n----------------------------\n");
            Feladat7();
            Console.ReadKey();
        }

        private static void Feladat7()
        {
            Console.WriteLine("7.Feladat: határozza meg melyek azok a stadionok amelyek 20-nál több alkalommal volt kosárlabdamérkőzések helyszíne");
            HelyszinekList = new List<string>();
            foreach (var k in KosarlabdaList)
            {
                if(!HelyszinekList.Contains(k.Helyszin))
                {
                    HelyszinekList.Add(k.Helyszin);
                }
            }
            foreach (var h in HelyszinekList)
            {
               // Console.WriteLine("{0}",h);
            }
            HelyszinSatisztika = new Dictionary<string, int>();
            PontokList = new List<int>();
            foreach (var h in HelyszinekList)
            {
                int db = 0;
                foreach (var k in KosarlabdaList)
                {
                   
                    if (h==k.Helyszin)
                    {
                        db++;
                    }
                    if(!PontokList.Contains(db))
                    {
                        PontokList.Add(db);
                    }
                   
                }
                if (!HelyszinSatisztika.ContainsKey(h))
                {
                    HelyszinSatisztika.Add(h, db);
                }
            }
            PontokList.Sort();
            PontokList.Reverse();
            RendezettStatisztika = new Dictionary<string, int>();
            for (int i = 0; i < PontokList.Count; i++)
             {
                 foreach (var h in HelyszinSatisztika)
                 {
                     if (PontokList[i] == h.Value)
                     {
                         if(!RendezettStatisztika.ContainsKey(h.Key))
                         {
                             RendezettStatisztika.Add(h.Key, h.Value);
                         }
                     }
                 }               
            }
            /*for (int i = 0; i < RendezettStatisztika.Count; i++)
              {
                  Console.WriteLine("{0,-40} : {1}", );
              }*/
            for (int i = 0; i < PontokList.Count; i++) 
            {
                foreach (var r in HelyszinSatisztika)
                {
                    if (PontokList[i] == r.Value)
                    {
                        Console.WriteLine("\t{0,-40} : {1}",r.Key,r.Value);
                    }
                }               
            }
            
        }

        private static void Feladat6()
        {
            Console.WriteLine("6.Feladat: határozza meg 2004. november 21-én mely csapatok játszottak mérközést");
            foreach (var k in KosarlabdaList)
            {
                if(k.Idopont== "2004-11-21")
                {
                    Console.WriteLine("\t{0,-25} : {1,-25} -> ({2} : {3})",k.Hazai, k.Idegen, k.HazaiPont,k.IdegenPont);
                }
            }
        }

        private static void Feladat5()
        {
            Console.WriteLine("5.Feladat: Barcelona csapat teljes neve");
            string CsapatNeve = "cica";
            foreach (var k in KosarlabdaList)
            {
                if(k.Hazai.Contains("Barcelona"))
                {
                    CsapatNeve = k.Hazai;
                }
            }
            Console.WriteLine("\tA Barcelona csapat teljes neve: {0}", CsapatNeve);
        }

        private static void Feladat4()
        {
            Console.WriteLine("4.Feladat: volt-e döntetlen");
            int Dontetlendb = 0;
            foreach (var k in KosarlabdaList)
            {
                if(k.HazaiPont==k.IdegenPont)
                {
                    Dontetlendb++;
                }
            }
            if(Dontetlendb>0)
            {
                Console.WriteLine("\tVolt döntetlen mérközés");
            }
            else
            {
                Console.WriteLine("\tNem volt döntetlen mérközés");
            }
        }

        private static void Feladat3()
        {
            Console.WriteLine("3.Feladat: Határozza meg, hány idegen és hány hazai mecsett játszott a Real Madrid");
            int HazaiMeccsekszama = 0;
            int IdegenMeccsekszama = 0;
            foreach (var k in KosarlabdaList)
            {
                if (k.Hazai== "Real Madrid")
                {
                    HazaiMeccsekszama++;
                }
                if (k.Idegen == "Real Madrid")
                {
                    IdegenMeccsekszama++;
                }
            }           
            Console.WriteLine("\tA Real Madrid hazai meccseinek száma: {0} \n\tA Real Madrid idegen meccseinek száma: {1}", HazaiMeccsekszama, IdegenMeccsekszama);
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("2.Feladat: Adatok beolvasása");
            KosarlabdaList = new List<Kosarlabda>();
            var sr = new StreamReader(@"eredmenyek.csv", Encoding.UTF8);
            int db = 0;
            while(!sr.EndOfStream)
            {
                db++;
                KosarlabdaList.Add(new Kosarlabda(sr.ReadLine()));
            }
            if(db>0)
            {
                Console.WriteLine("\tSikeres beolvasás: beolvasott sorok száma: {0}", db);
            }
            else
            {
                Console.WriteLine("\tSikertelen beolvasás próbálja újra");
            }
        }
    }
}
