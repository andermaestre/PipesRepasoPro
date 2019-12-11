using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Servidor
{

    class Program
    {
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string mensaje);
        [DllImport("user32")]
        public static extern int PostMessage(IntPtr dest, int IdMensaje, IntPtr wparam, IntPtr lparam);
        static void Main(string[] args)
        {
            int idmensajeacceso = RegisterWindowMessage("WM_ACCESO");


            NamedPipeServerStream pipeForm = new NamedPipeServerStream("pipeForm", PipeDirection.In);
            StreamReader sr = new StreamReader(pipeForm);

            NamedPipeClientStream pipeCli = new NamedPipeClientStream(".", "pipeCli", PipeDirection.InOut);
            StreamReader srCli = new StreamReader(pipeCli);
            StreamWriter swCli = new StreamWriter(pipeCli);

            pipeForm.WaitForConnection();
            string file = sr.ReadLine();

            File.Create("..\\..\\..\\" + file);
        }
    }
}
