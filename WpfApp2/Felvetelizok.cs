using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Felvetelizok : IFelvetelizo
    {
        public long Om_azonosito { get; set; }
        public string Név { get; set; }
        public string Ertesitesi_cim { get; set; }
        public DateOnly Szuletesi_datum { get; set; }
        public string Elerhetoseg_email { get; set; }
        public int Matekpont { get; set; }
        public int Irodalompont { get; set; }


        public Felvetelizok(string sor)
        {
            string[] darabok = sor.Split(';');
            this.Om_azonosito = long.Parse(darabok[0]);
            this.Név = darabok[1];
            this.Ertesitesi_cim = darabok[2];
            this.Szuletesi_datum = DateOnly.Parse(darabok[3]);
            this.Elerhetoseg_email = darabok[4];
            this.Matekpont = Convert.ToInt32(darabok[5]);
            this.Irodalompont = Convert.ToInt32(darabok[6]);
        }

        public Felvetelizok()
        {
        }

        public string CSVSortAdVissza()
        {
            throw new NotImplementedException();
        }

        public void ModositCSVSorral(string csvString)
        {
            throw new NotImplementedException();
        }
    }
}
