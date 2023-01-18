using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS_VirusSimulation.src.FileClass
{
    class PopulasiController : FileController
    {
        public Dictionary<char, int> populasiDaerah;
        public PopulasiController(string path) : base(path)
        {
            populasiDaerah = new Dictionary<char, int>();
            int populasi;
            char daerah;
            if (barisFile.Length > 0)
            {
                try
                {
                    for (int i = 1; i < barisFile.Length; i++)
                    {
                        Console.WriteLine(barisFile[i]);
                        daerah = barisFile[i][0];
                        populasi = int.Parse(barisFile[i].Substring(2));
                        populasiDaerah.Add(daerah, populasi);
                    }
                }
                catch (FormatException)
                {
                    throw new FormatException("File yang dimasukan adalah salah.");
                }
            }
        }
        public int getJumlahDaerah()
        {
            return (int)char.GetNumericValue(barisFile[0][0]);
        }
        public char getDaerahAsal()
        {
            return barisFile[0][2];
        }
        public void cetakPopulasi()
        {
            foreach (var (daerah, populasi) in populasiDaerah.Select(X => (X.Key, X.Value)))
            {
                Console.WriteLine("Populasi pada Daerah {0} : {1}", daerah, populasi);
            }
        }
    }
}
