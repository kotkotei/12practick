using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace langoge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        InputLanguage defLang;
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int LoadKeyboardLayout(string pwszKLID, uint Flags);
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                dataGridView1.Rows.Add(lang.Culture.EnglishName);
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == dataGridView1[0, 0])
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new
               System.Globalization.CultureInfo("en-US"));
                MessageBox.Show("Установлен язык: " +
               dataGridView1.Rows[0].Cells[0].Value.ToString());
            }
            if (dataGridView1.CurrentCell == dataGridView1[0, 1])
            {
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new
               System.Globalization.CultureInfo("ru-RU"));
                MessageBox.Show("Установлен язык:"+dataGridView1.Rows[1].Cells[0].Value.ToString());
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = defLang;
        }
    }
}
