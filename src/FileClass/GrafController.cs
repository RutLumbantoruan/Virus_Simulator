using System;
using System.Collections.Generic;
using BFS_VirusSimulation.src.GrafClass;

namespace BFS_VirusSimulation.src.FileClass
{
    class GrafController : FileController
    {
        public Dictionary<char, List<JalurElemen>> koneksiPeluang;
        public GrafController(string path) : base(path)
        {
            koneksiPeluang = new Dictionary<char, List<JalurElemen>>();
            try
            {
                for (int i = 1; i < barisFile.Length; i++)
                {
                    char simpul = barisFile[i][0];
                    char jalur = barisFile[i][2];
                    double probability = double.Parse(barisFile[i].Substring(4));
                    JalurElemen temp = new JalurElemen(jalur, probability);
                    if (koneksiPeluang.ContainsKey(simpul))
                    {
                        koneksiPeluang[simpul].Add(temp);
                    }
                    else
                    {
                        List<JalurElemen> tempList = new List<JalurElemen>();
                        tempList.Add(temp);
                        koneksiPeluang.Add(simpul, tempList);
                    }
                }
            }
            catch (FormatException)
            {
                throw new FormatException("File yang dimasukan adalah salah.");
            }
        }
    }
}
