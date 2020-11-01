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
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool  f_save;
        string line;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
            

             
                
                f_save = false;

                
                richTextBox1.Clear();

               
                using (FileStream fs = File.OpenRead(openFileDialog1.FileName))
                {

                    byte[] fileData = new byte[fs.Length];
                    fs.Read(fileData, 0, (int)fs.Length);

                   

                    line = System.Text.Encoding.Default.GetString(fileData); 
                    richTextBox1.AppendText(line);
                }
            }
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                line = richTextBox1.Text;
                MD5 md5 = new MD5CryptoServiceProvider();
                
                byte[] checkSum = md5.ComputeHash(Encoding.UTF8.GetBytes(line));
                string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                textBox1.Text = result;
                f_save = true;
            }
            catch
            {
                textBox1.Text = "Что то пошло не так!";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (f_save == true)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                string filename = saveFileDialog1.FileName;

                System.IO.File.WriteAllText(filename, textBox1.Text);
                MessageBox.Show("Файл сохранен");
            }else MessageBox.Show("Хэш функция не создана");
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            f_save = false;
            richTextBox1.Text = "";
            textBox1.Text = "";
        }
    }
}
