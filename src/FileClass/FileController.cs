using System.IO;

namespace BFS_VirusSimulation.src.FileClass
{
    abstract class FileController
    {
        protected string[] barisFile;
        protected string jalur;

        public FileController(string jalur)
        {
            try
            {
                this.jalur = jalur;
                barisFile = File.ReadAllLines(jalur);
            } catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File dengan path \"" + jalur + "\" tidak ditemukan");
            }
        }

        public int getNumber()
        {
            int number = (int)char.GetNumericValue(barisFile[0][0]);
            return number;
        }
    }
}
