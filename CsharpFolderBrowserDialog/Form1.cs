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


namespace CsharpFolderBrowserDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //https://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "+++Select Folder+++";
            fbd.ShowNewFolderButton = false;

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath + "\\";
                //string rootPath = @"C: \Users\mikeryzhov\Desktop\頭張";
                string rootPath = fbd.SelectedPath;

                var files = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
                //string[] dirs = Directory.GetDirectories(rootPath,"*",SearchOption.AllDirectories);

                int iA = 0;

                foreach (string file in files)
                {
                    iA++;
                    bool flagA = true;
                    string a = file;
                    string b = string.Empty;
                    string c = string.Empty;
                    long val;

                    for (int i = 0; i < a.Length; i++)
                    {
                        if (Char.IsDigit(a[i]) && b.Length == 8 && flagA == true)
                        {
                            c += a[i];

                            if (!Char.IsDigit(a[i + 1]) && b.Length == 8)
                            {
                                if (a[i + 1] == '折')
                                {
                                    c += a[i + 1];
                                }
                                    flagA = false;
                            }
                        }
                        

                        if (Char.IsDigit(a[i]) && b.Length < 8)
                        { b += a[i];  }
                    }
                                        
                    if (b.Length > 0)
                        val = long.Parse(b);

                    string reverseStr = Reverse(file);

                    reverseStr.IndexOf('\\');


                    string theFileName = System.IO.Path.GetFileName(file);

                    int index = reverseStr.IndexOf(@"\");

                    string trimmedWithoutDot = Reverse(reverseStr.Substring(0, index));



                    if (b == "") 
                    {
                        b += "第" +  iA.ToString() + "檔案名稱   " + trimmedWithoutDot;
                    }

                    if (c == "")
                    {
                        c += "第" + iA.ToString() + "檔案名稱   " + trimmedWithoutDot;
                    }

                    textBox2.Text = textBox2.Text + b + "\r\n";

                    textBox3.Text = textBox3.Text + c + "\r\n";
                }
            }
        }
    }
}
