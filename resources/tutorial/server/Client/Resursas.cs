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

        public static Vector3 IslandCenter = new Vector3(4840.571f, -5174.425f, 2.0f);
        public static bool NearIsland = false;
        private static uint _ilandTick = 0;
        public static uint IlandTick
        {
            get { return _ilandTick; }
            set { _ilandTick = value; }
        }
        public static void StartIsland()
        {
            IlandTick = Alt.EveryTick(IlandTickFunc);
        }

        public override void OnStart()
        {
            Console.WriteLine("Client Started");
            Alt.OnServer("Web:Create", Web.CreateWebView);

            IlandTick = Alt.EveryTick(IlandTickFunc);

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
            //rmlElement.On("click", Click);
            //rmlDocument.On("click", Click);
        }

        public override void OnStop()
        {
            Console.WriteLine("Client Stopped");
        }

        public static void IlandTickFunc()
        {
            var distance = Alt.LocalPlayer.Position.Distance(IslandCenter);

            if (NearIsland)
            {
                Alt.Natives.SetRadarAsExteriorThisFrame();
                Alt.Natives.SetRadarAsInteriorThisFrame(Alt.Hash("h4_fake_islandx"), 4700.0f, -5145.0f, 0, 0);

                if (distance >= 3000)
                {
                    NearIsland = false;
                    Alt.Natives.SetIslandEnabled("HeistIsland", false);
                    Alt.Natives.SetScenarioGroupEnabled("Heist_Island_Peds", false);
                    Alt.Natives.SetAudioFlag("PlayerOnDLCHeist4Island", false);
                    Alt.Natives.SetAmbientZoneListStatePersistent("AZL_DLC_Hei4_Island_Zones", false, false);
                    Alt.Natives.SetAmbientZoneListStatePersistent("AZL_DLC_Hei4_Island_Disabled_Zones", false, false);
                }
            }
            else if (distance < 2000 && !NearIsland)
            {
                NearIsland = true;
                Alt.Natives.SetIslandEnabled("HeistIsland", true);
                Alt.Natives.SetScenarioGroupEnabled("Heist_Island_Peds", true);
                Alt.Natives.SetAudioFlag("PlayerOnDLCHeist4Island", true);
                Alt.Natives.SetAmbientZoneListStatePersistent("AZL_DLC_Hei4_Island_Zones", true, true);
                Alt.Natives.SetAmbientZoneListStatePersistent("AZL_DLC_Hei4_Island_Disabled_Zones", false, true);
            }
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