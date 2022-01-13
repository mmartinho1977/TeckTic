using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Audits
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            List<string> files;
            DialogResult result;

            files = new List<string>();
            using (var fbd = new FolderBrowserDialog())
            {

                result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    files = DirSearch(fbd.SelectedPath);
                }
            }


            foreach  (string file in files)
            {
                //result = ReadFile(file);
            }




        }

        private List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }

        private void BuildUser(string file)
        {

        }


        private Device BuildDevice(string file)
        {

            Device device;
            string[] lines;
            string[] aux;
            int counter = 0;

            device = new Device();
            //aux = new string[20];
            lines = System.IO.File.ReadAllLines(file);

            // Display the file contents by using a foreach loop.
            Debug.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Debug.WriteLine("\t" + line);

                if (counter == 10)
                {
                    aux = line.Split('/');
                    //Device.Users.Add(user = new User { Code = })
                }

                counter++;
            }

            return device;
        }






        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
