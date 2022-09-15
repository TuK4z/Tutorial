using System;
using AltV.Net.Client;
using Client;

namespace ExampleProject
{
    internal class ExampleResource : Resource
    {
        public override void OnStart()
        {
            Console.WriteLine("Client Started");

            Alt.OnServer("Web:Create", Web.CreateWebView);
        }

        public override void OnStop()
        {
            Console.WriteLine("Client Stopped");
        }
    }
}