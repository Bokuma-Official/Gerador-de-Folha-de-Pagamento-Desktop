﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerador_de_Folha_de_Pagamento_Desktop.Apresentacao
{
    public partial class frm_Redefinir_Senha : Form
    {
        Thread Abrir_Tela;

        public frm_Redefinir_Senha()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
            Abrir_Tela = new Thread(Abrir_frm_Login);
            Abrir_Tela.SetApartmentState(ApartmentState.STA);
            Abrir_Tela.Start();
        }

        private void Abrir_frm_Login()
        {
            Application.Run(new frm_Login());
        }
    }
}
