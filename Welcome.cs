using System;
using System.IO;
using System.Windows.Forms;
using BFS_VirusSimulation.src.GrafClass;

namespace BFS_VirusSimulation
{
    public partial class Welcome : Form
    {
        private Graf peluangPopulasi;
        private string populationText;
        private string graphText;
        private int days;
        Microsoft.Msagl.Drawing.Graph graf;
        Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        public Welcome()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            graphTextBox.Text = "Masukkan File";
            populationTextBox.Text = "Masukkan File";
        }

        private void WelcomeLoad(object sender, EventArgs e)
        {
            howToTitle.Hide();
            howToStep.Hide();
            backToMenuButton.Hide();
            selectGraph.Hide();
            selectPopulation.Hide();
            populationOpen.Hide();
            graphOpen.Hide();
            populationTextBox.Hide();
            graphTextBox.Hide();
            simulate.Hide();
            tempBackgroundGlow1.Hide();
            tempBackgroundGlow2.Hide();
            tempBackground.Hide();
            daysSelect.Hide();
            daysSpread.Hide();
        }
        private void KlikTombolSimulasi(object sender, EventArgs e)
        {
            tempBackgroundGlow1.Show();
            tempBackgroundGlow2.Show();
            tempBackground.Show();
            selectGraph.Show();
            selectPopulation.Show();
            populationOpen.Show();
            graphOpen.Show();
            populationTextBox.Show();
            graphTextBox.Show();
            simulate.Show();
            backToMenuButton.Show();
            daysSelect.Show();
            daysSpread.Show();
            title.Hide();
            subtitle.Hide();
            simulateButton.Hide();
            howToButton.Hide();
            exitButton.Hide();
            howToTitle.Hide();
            howToStep.Hide();
        }
        private void KlikTombolMenu(object sender, EventArgs e)
        {
            howToTitle.Hide();
            howToStep.Hide();
            backToMenuButton.Hide();
            selectGraph.Hide();
            selectPopulation.Hide();
            populationOpen.Hide();
            graphOpen.Hide();
            populationTextBox.Hide();
            graphTextBox.Hide();
            simulate.Hide();
            tempBackgroundGlow1.Hide();
            tempBackgroundGlow2.Hide();
            tempBackground.Hide();
            daysSelect.Hide();
            daysSpread.Hide();
            title.Show();
            subtitle.Show();
            simulateButton.Show();
            howToButton.Show();
            exitButton.Show();
        }
        private void KlikTombolKeluar(object sender, EventArgs e)
        {
            this.Close();
        }
        private void graphOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openGraph = new OpenFileDialog();
            openGraph.Title = "Tambahkan File Graf";
            openGraph.Filter = "Tipe File (*.txt) | *.txt";
            DialogResult dr = openGraph.ShowDialog();
            if (dr == DialogResult.OK)
            {
                graphText = openGraph.FileName;
                graphTextBox.Text = graphText;
            }
        }
        private void KlikFilePopulasi(object sender, EventArgs e)
        {
            OpenFileDialog openPopulation = new OpenFileDialog();
            openPopulation.Title = "Tambahkan File Populasi";
            openPopulation.Filter = "Tipe File (*.txt) | *.txt";
            DialogResult dr = openPopulation.ShowDialog();
            if (dr == DialogResult.OK)
            {
                populationText = openPopulation.FileName;
                populationTextBox.Text = populationText;
            }
        }
        private void KlikSimulasi(object sender, EventArgs e)
        {
            graphText = graphTextBox.Text;
            populationText = populationTextBox.Text;
            try
            {
                peluangPopulasi = new Graf(populationText, graphText);
                days = Convert.ToInt32(daysSpread.Text);
                GrafForm grafView = new GrafForm(populationText, graphText, days);
                grafView.ShowDialog();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("File yang anda masukan mungkin berformat salah");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("File yang anda masukan mungkin berformat salah");
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                MessageBox.Show(fileNotFoundException.Message);
            }
            catch (IndexOutOfRangeException indexOutOfRangeException)
            {
                MessageBox.Show(indexOutOfRangeException.Message);
            }
            catch (FormatException formatException)
            {
                MessageBox.Show(formatException.Message);
            }
        }
    }
}
