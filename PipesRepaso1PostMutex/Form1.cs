using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipesRepaso1PostMutex
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string mensaje);
        [DllImport("user32")]
        public static extern int PostMessage(IntPtr dest, int IdMensaje, IntPtr wparam, IntPtr lparam);
        int idmensajeacceso;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            idmensajeacceso = RegisterWindowMessage("WM_ACCESO");
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName="..\\..\\..\\Servidor\\bin\\Debug\\Servidor.exe";
            psi.UseShellExecute = true;
            p.StartInfo = psi;
            p.Start();

            NamedPipeClientStream pipeForm = new NamedPipeClientStream(".","pipeForm", PipeDirection.Out);
            StreamWriter sw = new StreamWriter(pipeForm);

            Process p2 = new Process();
            ProcessStartInfo psi2 = new ProcessStartInfo();
            psi2.FileName = "..\\..\\..\\Cliente\\bin\\Debug\\Cliente.exe";
            psi2.UseShellExecute = true;
            p2.StartInfo = psi;
            p2.Start();



        }

        protected override void WndProc(ref Message m)
        {
            if(m.Msg== idmensajeacceso)
            {

            //}else if (m.Msg ==)
            //{

            }else
            base.WndProc(ref m);
        }
    }
}
