using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            NamedPipeServerStream pipeCli = new NamedPipeServerStream("pipeCli", PipeDirection.InOut);
            StreamReader srCli = new StreamReader(pipeCli);
            StreamWriter swCli = new StreamWriter(pipeCli);

        }
    }
}
