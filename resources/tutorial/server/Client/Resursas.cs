using System;
using AltV.Net.Client;

namespace ExampleProject
{
    internal class ExampleResource : Resource
    {
        public override void OnStart()
        {
            Console.WriteLine("Client Started");
        }

        public override void OnStop()
        {
            Console.WriteLine("Client Stopped");
        }
    }
}