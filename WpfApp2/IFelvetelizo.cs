using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal interface IFelvetelizo
    {
        long Om_azonosito { get; set; }
        string Név { get; set; }
        string Ertesitesi_cim { get; set; }
        DateOnly Szuletesi_datum { get; set; }
        string Elerhetoseg_email { get; set; }
        int Matekpont { get; set; }
        int Irodalompont { get; set; }

        String CSVSortAdVissza();

        void ModositCSVSorral(String csvString);
    }
}
