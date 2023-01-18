using System;
using System.Collections.Generic;
using System.Linq;
using BFS_VirusSimulation.src.FileClass;

namespace BFS_VirusSimulation.src.GrafClass
{
    public partial class Graf
    {
        private Dictionary<char, GrafElemen> simpul;
        private char daerahAsal;
        public Graf()
        {
            simpul = new Dictionary<char, GrafElemen>();
        }
        internal Graf(PopulasiController populasiController, GrafController grafController):this()
        {
            foreach (var (daerah, populasi) in populasiController.populasiDaerah.Select(X => (X.Key, X.Value)))
            {
                simpul.Add(daerah, new GrafElemen(daerah, populasi));
            }
            simpul[populasiController.getDaerahAsal()].setDaerahAsal();
            daerahAsal = populasiController.getDaerahAsal();
            int iterator = 0;
            foreach (var (daerahGraf, jalur) in grafController.koneksiPeluang.Select(X => (X.Key, X.Value)))
            {
                foreach (JalurElemen jl in jalur)
                {
                    simpul[daerahGraf].jalur.Add(new JalurElemen(jl.jalur, jl.peluang));
                }
                iterator++;
            }
        }
        public Graf(string populationPath, string graphPath) : this(new PopulasiController(populationPath), new GrafController(graphPath)) { }

        public Dictionary<char, GrafElemen> getSimpul()
        {
            return simpul;
        }
        public void addJalur(char simpulIndeks, char jalurElemen, double peluang)
        {
            JalurElemen temp = new JalurElemen(jalurElemen, peluang);
            simpul[simpulIndeks].jalur.Add(temp);
        }
        public void setDaerahInfeksi(char daerah, int waktuInfeksi)
        {
            simpul[daerah].waktuInfeksi = waktuInfeksi;
        }
        public GrafElemen getElemen(char indeks)
        {
            return simpul[indeks];
        }
        public int getJumlahSimpul()
        {
            return simpul.Count;
        }

        public void cetakInformasi()
        {
            foreach (var (key, val) in simpul.Select(X => (X.Key, X.Value)))
            {
                Console.Write("Daerah {0} dengan populasi {1}: ", val.simpul, val.populasi);
                foreach (JalurElemen jalurElemen in val.jalur)
                {
                    Console.Write("{0}, {1}  ", jalurElemen.jalur, jalurElemen.peluang);
                }
                Console.WriteLine();
            }
        }
        public List<string> InformasiGraf()
        {
            List<string> result = new List<string>();
            foreach (var (key, val) in simpul.Select(X => (X.Key, X.Value)))
            {
                string deskripsiDaerah = "Daerah " + key + " dengan populasi " + val.populasi + ": ";
                foreach (JalurElemen jalurElemen in val.jalur)
                {
                    deskripsiDaerah += (jalurElemen.jalur + ", " + jalurElemen.peluang + " ");
                }
                deskripsiDaerah += "\n dengan waktu terinfeksi " + val.waktuInfeksi + " dan jumlah yg terinfeksi" + val.jumlahInfeksi;
                result.Add(deskripsiDaerah);
            }
            return result;
        }

        public void hasilBFS(int waktu)
        {
            Queue<char> q = new Queue<char>();
            q.Enqueue(daerahAsal);
            while (!(q.Count == 0))
            {
                char daerahKunjungan = q.Dequeue();
                int rentangInfeksi = waktu - simpul[daerahKunjungan].waktuInfeksi;
                int jumlahInfeksi = Jalur.getJumlahMasyarakatTerinfeksi(simpul[daerahKunjungan], rentangInfeksi);
                int populasi = simpul[daerahKunjungan].populasi;
                simpul[daerahKunjungan].jumlahInfeksi = jumlahInfeksi;
                foreach (JalurElemen jalurEl in simpul[daerahKunjungan].jalur)
                {
                    if (simpul[daerahKunjungan].cekPenyebaranKe(jalurEl.jalur) > 1)
                    {
                        int hariTersebar = (int)(4 * Math.Log((populasi - 1) / (populasi * jalurEl.peluang))) + 1;
                        Console.WriteLine("Hari tersebar " + daerahKunjungan + " ke " + jalurEl.jalur + " adalah " + hariTersebar);
                        if ((hariTersebar < simpul[jalurEl.jalur].waktuInfeksi) || (simpul[jalurEl.jalur].waktuInfeksi == GrafElemen.WAKTUTIDAKINFEKSI))
                        {
                            simpul[jalurEl.jalur].waktuInfeksi = hariTersebar;
                            q.Enqueue(jalurEl.jalur);
                        }
                    }
                }
            }
        }
    }

}

