using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_BinSoubory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream datovytok = new FileStream("seznam.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //BinaryReader ctenar = new BinaryReader(datovytok);
            BinaryWriter zapisovac = new BinaryWriter(datovytok);
            zapisovac.Write("2;Antonín Štolfa;3,2/1,1!\n");
            int n = Convert.ToInt32(numericUpDown3.Value);
            zapisovac.Write(numericUpDown3.Value.ToString()+ ";" + textBox2.Text + ";");
            while(n != 0)
            {
                if(numericUpDown1.Value > 0 && numericUpDown2.Value > 0)
                {
                    if (n == 1)
                    {
                        zapisovac.Write(numericUpDown1.Value + "," + numericUpDown2.Value + "!\n");
                        
                    }
                    else
                    {
                        zapisovac.Write(numericUpDown1.Value + "," + numericUpDown2.Value + "/");
                       
                    }
                    n--;
                }
                else 
                {
                    MessageBox.Show("spatne, zadejte cele znovu!");
                    n = 0;
                }
            }
            MessageBox.Show("Všechny známky byly úspěšně zadány." , "Info");
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            button1.Enabled = false;
            textBox1.Enabled = true;
            numericUpDown3.Enabled = true;
            button3.Enabled = true;
            datovytok.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            textBox1.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            FileStream datovytok2 = new FileStream("seznam.dat", FileMode.Open, FileAccess.Read);
            BinaryReader ctenar = new BinaryReader(datovytok2);
            ctenar.BaseStream.Position = 0;
            string data;
            string[] text;
            //string[] zaznam;
            while (ctenar.BaseStream.Position < ctenar.BaseStream.Length)
            {
                data = ctenar.ReadString();
                text = data.Split('!');
                listBox3.Items.Add(text.ToString());
                //zaznam = data.Split(';');
            }
            datovytok2.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(numericUpDown3.Value > 0 && textBox2.Text.Length > 0)
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                button1.Enabled = true;
                textBox1.Enabled = false;
                numericUpDown3.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                MessageBox.Show("Zadejte kolik známek chcete zadat, a jméno.");
            }
        }
    }
}
