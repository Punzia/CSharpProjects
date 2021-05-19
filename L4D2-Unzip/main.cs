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
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.Win32;


namespace L4D2_Unzip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            string l4d2path = GetL4D2Dir().ToString();
            string outa = "Found Left 4 Dead 2 Folder: " + l4d2path;

            listBox1.Items.Add(outa);
            Debug.WriteLine(l4d2path + "\\addons");
            backgroundWorker1 = new BackgroundWorker();
            
            
        }
        private string GetL4D2Dir()
        {
            string steamPath = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", "");
            string pathsFile = Path.Combine(steamPath, "steamapps", "libraryfolders.vdf");

            if (!File.Exists(pathsFile))
                return null;

            List<string> libraries = new List<string>();
            libraries.Add(Path.Combine(steamPath));

            var pathVDF = File.ReadAllLines(pathsFile);



            Regex pathRegex = new Regex(@"\""(([^\""]*):\\([^\""]*))\""");
            foreach (var line in pathVDF)
            {
                if (pathRegex.IsMatch(line))
                {
                    string match = pathRegex.Matches(line)[0].Groups[1].Value;

                    libraries.Add(match.Replace("\\\\", "\\"));
                }
            }

            foreach (var library in libraries)
            {

                string l4d2Path = Path.Combine(library, "steamapps\\common\\Left 4 Dead 2\\left4dead2");
                if (Directory.Exists(l4d2Path))
                {
                    return l4d2Path;
                }
            }

            return null;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
                textBox1.Text = files[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                textBox1.Text = filePath;


            }
        }
    }
}
