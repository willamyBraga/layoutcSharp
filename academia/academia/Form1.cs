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
namespace academia
{
    public partial class FrmAcademia : Form
    {
        public FrmAcademia()
        {
            InitializeComponent(); 
            
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            abrirConteudo(new frmCliente());
        }

      
        private void btnFuncionario_Click(object sender, EventArgs e)
        {
           
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            
        }
        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }
        private Form ativo = null;
        private void abrirConteudo(Form panelC)
        {
            if(ativo != null)
             ativo.Close();
                ativo = panelC;
                panelC.TopLevel = false;
                panelC.FormBorderStyle = FormBorderStyle.None;
                panelC.Dock = DockStyle.Fill;
                panelConteudo.Controls.Add(panelC);
                panelConteudo.Tag = panelC;
                panelC.BringToFront();
                panelC.Show();
            
        } 
        private void FrmAcademia_Load(object sender, EventArgs e)
        {

        }

        private void btnOcultarMenu_Click(object sender, EventArgs e)
        {
            if (panelMenuLateral.Width == 250)
            {
                panelMenuLateral.Width = 70;
            }
            else
            {
                panelMenuLateral.Width = 250;
            }
        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false;
         }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
           
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelBarra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

      

        private void btnSair_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //abrirConteudo(ne());

        }
        
    }
}
