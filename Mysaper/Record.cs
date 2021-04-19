using System;
using System.Windows.Forms;
using System.IO;

namespace Mysaper
{
    public partial class Record : Form
    {
        public Record()
        {
            InitializeComponent();
        }

        // Считывание рекордов из файла
        private void Record_Load(object sender, EventArgs e)
        {
            string[] records = File.ReadAllLines("Records.txt");

            foreach (string el in records)
            {
                listView1.Items.Add(el);
            }
            
        }

        // Сброс рекордов
        private void Reset_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены?", "Сброс", MessageBoxButtons.YesNo);
            if(res == DialogResult.Yes)
            {
                File.WriteAllText("Records.txt", "");
                listView1.Items.Clear();
            }
        }
    }
}
