using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _3DESEncrypt
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string iParam);
        private const int EM_SETCUEBANNER = 0x1501;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SendMessage(textBox2.Handle, EM_SETCUEBANNER, 0, "Key");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.TextLength == 16)
                {
                    if (textBox1.TextLength != 0)
                    {
                        TripleDES tDES = new TripleDES(textBox2.Text);
                        tDES.EncryptFile(textBox1.Text);
                        GC.Collect();
                        MessageBox.Show("File Berhasil Di Encrypt", "Informasi",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Masukkan File Terlebih Dahulu", "File Input",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Key Harus Berjumlah 16", "Gagal",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.TextLength == 16)
                {
                    if (textBox1.TextLength != 0)
                    {
                        TripleDES tDES = new TripleDES(textBox2.Text);
                        tDES.DecryptFile(textBox1.Text);
                        GC.Collect();
                        MessageBox.Show("File Berhasil Di Decrypt", "Informasi",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Masukkan File Terlebih Dahulu", "File Input",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Key Harus Berjumlah 16", "Gagal",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
