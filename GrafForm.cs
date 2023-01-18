using System;
using System.Linq;
using System.Windows.Forms;
using BFS_VirusSimulation.src.FileClass;
using BFS_VirusSimulation.src.GrafClass;

namespace BFS_VirusSimulation
{
    public partial class GrafForm : Form
    {
        private Graf peluangPopulasi;
        private Microsoft.Msagl.Drawing.Graph graph;
        private Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        public GrafForm(string populasiFile, string graphFile, int days)
        {
            if (days < 0)
            {
                throw new IndexOutOfRangeException("Hari harus sama dengan atau lebih besar dari 0 hari.");
            }
            InitializeComponent();
            peluangPopulasi = new Graf(populasiFile, graphFile);
            peluangPopulasi.hasilBFS(days);
            viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            // Membuat objek graf
            graph = new Microsoft.Msagl.Drawing.Graph("graf");
            foreach (var (simpul, grafEl) in peluangPopulasi.getSimpul().Select(T => (T.Key, T.Value)))
            {

                graph.AddNode(Char.ToString(simpul));
                Microsoft.Msagl.Drawing.Node temp = graph.FindNode(Char.ToString(simpul));
                temp.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
                if (grafEl.waktuInfeksi != GrafElemen.WAKTUTIDAKINFEKSI)
                {
                    temp.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Blue;
                }
                foreach (JalurElemen jalurElemen in grafEl.jalur)
                {
                    if (grafEl.cekPenyebaranKe(jalurElemen.jalur) > 1)
                    {
                        graph.AddEdge(Char.ToString(simpul), Char.ToString(jalurElemen.jalur)).Attr.Color = Microsoft.Msagl.Drawing.Color.DarkBlue;
                    }
                    else
                    {
                        graph.AddEdge(Char.ToString(simpul), Char.ToString(jalurElemen.jalur)).Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
                    }
                }
            }

            // Tampilkan graf kepada pembaca
            viewer.Graph = graph;
            SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            Controls.Add(viewer);
            ResumeLayout();
        }
    }
}
