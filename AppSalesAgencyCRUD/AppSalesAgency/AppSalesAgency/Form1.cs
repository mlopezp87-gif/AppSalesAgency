using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppSalesAgency.CapaDatos;

namespace AppSalesAgency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            if(user.login(txtUsuario.Text, txtPassword.Text) ==true)
            {
                MessageBox.Show("Login exitoso");
                FrmMenuPrincipal menu= new FrmMenuPrincipal();
                menu.ShowDialog(this);
                this.Hide();

            }
            else
            {
                MessageBox.Show("Error, Nombre  de usuario o contraseña incorrectos");
            }

        }
    }
}
