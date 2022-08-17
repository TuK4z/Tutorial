global using AltV.Net;
global using AltV.Net.Resources.Chat.Api;
global using AltV.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    internal class Resursas : Resource
    {
        public override void OnStart()
        {
            Console.WriteLine("Started");
        }

        public override void OnStop()
        {
            Console.WriteLine("Stopped");
        }
    }
}
