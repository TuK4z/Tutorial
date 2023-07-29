global using AltV.Net;
global using AltV.Net.Resources.Chat.Api;
global using AltV.Net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace Tutorial
{
    internal class Resursas : Resource
    {
        public override void OnStart()
        {
            Console.WriteLine("Started");
            /*IPlayer[] globalBlipArray = Array.Empty<IPlayer>();
            foreach (Position pp in testBlips)
            {
                IBlip crashingBlip = Alt.CreateBlip(true, BlipType.Destination, pp, globalBlipArray);
            }*/
        }

        public override void OnStop()
        {
            Console.WriteLine("Stopped");
        }
    }
}
