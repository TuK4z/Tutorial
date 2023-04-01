using System;
using System.Numerics;
using AltV.Net.Client;
using AltV.Net.Client.Elements.Data;
using Client;

namespace ExampleProject
{
    internal class ExampleResource : Resource
    {
        public override void OnStart()
        {
            Console.WriteLine("Client Started");

            Alt.OnServer("Web:Create", Web.CreateWebView);

            Alt.OnKeyUp += (key) =>
            {
                KeyUpEvent(key);
            };

            Alt.OnPlayerWeaponChange += (oldweapon, newweapon) =>
            {
                Alt.Log(oldweapon.ToString());
                Alt.Log(newweapon.ToString());
                Alt.Log(Alt.LocalPlayer.CurrentWeapon.ToString());
                var wdata = Alt.LocalPlayer.GetWeaponData();
                wdata.Damage = 1.5f;
            };
        }

        public override void OnStop()
        {
            Console.WriteLine("Client Stopped");
        }

        public static void KeyUpEvent(Key key)
        {
            // Key events
        }
    }
}