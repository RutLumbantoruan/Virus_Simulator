using System;

namespace BFS_VirusSimulation.src.GrafClass
{
    class Jalur
    {
        private const double GAMMA = 0.25;

        public static int getJumlahMasyarakatTerinfeksi(GrafElemen grafElemen, int waktu)
        {
            if (grafElemen.waktuInfeksi == GrafElemen.WAKTUTIDAKINFEKSI)
            {
                return 0;
            }
            else
            {
                double populasiGraph = grafElemen.populasi;
                double denominator = 1 + ((populasiGraph - 1) * Math.Pow(Math.E, -(GAMMA * (waktu))));
                return (int)(populasiGraph / denominator);
            }
        }

        public static bool cekVirusMenyebar(int masyarakatTerinfeksi, double peluangPerjalanan)
        {
            return (masyarakatTerinfeksi * peluangPerjalanan >= 1);
        }
    }
}
