using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_VirusSimulation.src.GrafClass
{
    public class GrafElemen
    {
        public const int WAKTUTIDAKINFEKSI = -1;

        public char simpul;
        public int populasi;
        public int waktuInfeksi;
        public int jumlahInfeksi;
        internal List<JalurElemen> jalur;
        public GrafElemen(char simpul, int populasi)
        {
            jalur = new List<JalurElemen>();
            this.populasi = populasi;
            this.simpul = simpul;
            this.waktuInfeksi = WAKTUTIDAKINFEKSI;
            jumlahInfeksi = 0;
        }
        public GrafElemen(char node) : this(node, 0) { }
        public double cekPenyebaranKe(char daerahLain)
        {
            int index = 0;
            for (int i = 0; i < jalur.Count; i++)
            {
                if (jalur[i].jalur == daerahLain)
                {
                    index = i;
                    break;
                }
            }
            return (jumlahInfeksi * jalur[index].peluang);
        }
        public void setDaerahAsal()
        {
            waktuInfeksi = 0;
        }
    }
}
