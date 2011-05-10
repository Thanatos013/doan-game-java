using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using ClassLibrary;
namespace presentation
{
    
    public partial class FormKetNoi : Form
    {
        public SocketServer socketS = new SocketServer();
        public FormKetNoi()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SocketServer socketS = new SocketServer();
            try
            {
                socketS.taoKetNoiDenServer(txtIP.Text, int.Parse(txtPort.Text));
               // if (kq != "khong ket noi duoc")
                //{

                  //  MessageBox.Show(kq);
                    Close();
                    FormDangNhap fDangNhap = new FormDangNhap(socketS);
                    fDangNhap.Show();
                //}
                ///else
                   // Close();
            }
            catch (System.Net.Sockets.SocketException se)
            {
                MessageBox.Show(se.Message);
            }
            
             
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <='9') || e.KeyChar == '.'||e.KeyChar==8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
            if (e.KeyChar == 8)
                e.Handled = false;
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}