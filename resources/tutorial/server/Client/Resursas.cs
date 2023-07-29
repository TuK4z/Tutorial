using AltV.Net.Client;
using AltV.Net.Client.Elements.Data;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using Client;
using System.Numerics;

namespace ExampleProject
{
    internal class ExampleResource : Resource
    {
        private static IRmlDocument? rmlDocument;
        private static IRmlElement? rmlElement;
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

            rmlDocument = Alt.CreateRmlDocument("/client/RmlWeb/index.rml");
            rmlElement = rmlDocument.QuerySelector("#container");
            rmlElement.On("click", Click);
            rmlDocument.On("click", Click);
        }

        public override void OnStop()
        {
            Console.WriteLine("Client Stopped");
        }

        public static void KeyUpEvent(Key key)
        {
            switch ((int)key)
            {
                case 118: // F7
                    Vector2 screen = Alt.WorldToScreen(Alt.LocalPlayer.Position.X, Alt.LocalPlayer.Position.Y, Alt.LocalPlayer.Position.Z + 1);

                    if (rmlDocument == null) return;
                    rmlElement = rmlDocument.CreateElement("button");

                    rmlElement.AddClass("containerclass");
                    rmlElement.SetProperty("left", $"{screen.X}px");
                    rmlElement.SetProperty("top", $"{screen.Y}px");

                    rmlElement.InnerRml = "Informacija";
                    rmlDocument.AppendChild(rmlElement);
                    break;
            }
        }

        public static void Click()
        {
            Alt.Log("Click");
        }
    }
}