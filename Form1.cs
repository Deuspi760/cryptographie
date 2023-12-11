using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoGraphie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            CryptageNet monCryptage = new CryptageNet();
            this.textBox2.Text = monCryptage.Crypter(textBox1.Text);
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {

            CryptageNet monCryptage = new CryptageNet();
            this.textBox3.Text = monCryptage.Decrypter(textBox2.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MonCryptageInverser monCryptage = new MonCryptageInverser();
            this.textBox2.Text = monCryptage.Crypter(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MonCryptageInverser monCryptage = new MonCryptageInverser();
            this.textBox3.Text = monCryptage.Decrypter(textBox2.Text);
        }
    }
}
