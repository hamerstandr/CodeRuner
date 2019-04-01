using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeRuner
{
    internal class tabdil_noe
    {
        public string[] anva = { "bool", "real", "string", "void" };

        public int martabe_noe(string noe)
        {
            for (int i = 0; i < 4; i++)
            {
                if (anva[i] == noe) return i;
            }

            return -1;
        }
        public string karan_bala(string noe1, string noe2)
        {
            if (noe1 == "no_type" | noe2 == "no_type") return "no_type";
            if (martabe_noe(noe1) > martabe_noe(noe2)) return noe1;
            return noe2;
        }

        public bool tabdil_pazir(string noe1, string noe2)
        {

            return !((martabe_noe(noe1) <= martabe_noe(noe2)) | noe1 == "no_type" | noe2 == "no_type");

        }
        public bool bareCnoe(string noe1, string noe2)//جلو گیری از انتشار خطا
        {

            return !((noe1 == noe2) | noe1 == "no_type" | noe2 == "no_type");

        }


    }
}
