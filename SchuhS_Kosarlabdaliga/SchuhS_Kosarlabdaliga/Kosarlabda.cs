using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_Kosarlabdaliga
{
    class Kosarlabda
    {
        // hazai;idegen;hazai_pont;idegen_pont;helyszín;időpont
        public string Hazai;
        public string Idegen;
        public int HazaiPont;
        public int IdegenPont;
        public string Helyszin;
        public string Idopont;
        
        public Kosarlabda(string sor)
        {
            var dbok = sor.Split(';');
            this.Hazai = dbok[0];
            this.Idegen = dbok[1];
            this.HazaiPont = int.Parse(dbok[2]);
            this.IdegenPont = int.Parse(dbok[3]);
            this.Helyszin = dbok[4];
            this.Idopont = dbok[5];

        }
    }
}
