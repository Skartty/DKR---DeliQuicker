using ProjetoDKR.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoDKR
{
    public partial class IntroAnimada : Form
    {
        private Timer timer;
        private bool transicaoRealizada = false;
        public IntroAnimada()
        {
            InitializeComponent();
        }

        public TelaLogin TelaLogin
        {
            get => default;
            set
            {
            }
        }

        private void IntroAnimada_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.Click += IntroAnimada_Click;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            IniciarTransicao();
        }
        private void IntroAnimada_Click(object sender, EventArgs e)
        {
            IniciarTransicao();
        }
        private void IniciarTransicao()
        {
            if (!transicaoRealizada)
            {
                transicaoRealizada = true;
                timer.Stop();
                this.Hide();

                TelaLogin tela = new TelaLogin();
                tela.Show();
            }
        }
    }
}
