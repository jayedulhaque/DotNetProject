using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Filesplittr
{
    public partial class Form1 : Form
    {
        private OpenFileDialog ass;
        private DialogResult dlgresult;
        public Form1()
        {
            InitializeComponent();
            ass = new OpenFileDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(ass.FileName, FileMode.Open, FileAccess.Read);
                int SizeofEachFile = (int)Math.Ceiling((double)fs.Length /5);

                for (int i = 0; i < 5; i++)
                {
                    string baseFileName = Path.GetFileNameWithoutExtension(ass.FileName);
                    string Extension = Path.GetExtension(ass.FileName);

                    FileStream outputFile = new FileStream(Path.GetDirectoryName(ass.FileName) + "\\" + baseFileName + "." +
                        i.ToString().PadLeft(5, Convert.ToChar("0")) + Extension + ".split", FileMode.Create, FileAccess.Write);

                    int bytesRead = 0;
                    byte[] buffer = new byte[SizeofEachFile];

                    if ((bytesRead = fs.Read(buffer, 0, SizeofEachFile)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytesRead);

                    }

                    outputFile.Close();

                }
                fs.Close();
                MessageBox.Show("File is splited in"+ Path.GetDirectoryName(ass.FileName));
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dlgresult = ass.ShowDialog();
            textBox1.Text = ass.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string baseloc = "";
            try
            {
                FolderBrowserDialog fd = new FolderBrowserDialog();
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    baseloc = fd.SelectedPath;
                }
                string baseFileName = Path.GetFileNameWithoutExtension(ass.FileName);
                string Extension = Path.GetExtension(ass.FileName);
                FileStream gg = new FileStream(Path.GetDirectoryName(ass.FileName) + "\\" + baseFileName + "1" + Extension, FileMode.Create, FileAccess.Write);
                string[] filenames = Directory.GetFiles(baseloc, "*.split");
                FileInfo ff =new FileInfo(ass.FileName);
                byte[] buffer = new byte[ff.Length];
                foreach (string filename in filenames)
                {
                    FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    int ddd=(int)fs.Length;
                    int bytre=fs.Read(buffer, 0, ddd);
                    gg.Write(buffer, 0, bytre);
                    fs.Close();

                }
                gg.Close();
                MessageBox.Show("File is merged in "+Path.GetDirectoryName(ass.FileName)+" as "+baseFileName+"1"+Extension);
            }
            catch (IOException er)
            {
                MessageBox.Show(" "+ er);
            }
        }
    }
}
