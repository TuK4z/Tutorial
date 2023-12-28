using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Data;
using System.Numerics;

namespace Tutorial
{
    internal class Commands : IScript
    {
        [Command("tpsala")]
        public static void tpsala(IPlayer player)
        {
            player.Position = new Vector3(4890.61f, -5736.18f, 25.80f);
        }
        [Command("testblip")]
        public static void testcrash(IPlayer player)
        {
            IBlip blips = Alt.CreateBlip(true, BlipType.Destination, player.Position, Array.Empty<IPlayer>());
            blips.Sprite = 490;
            blips.Color = 0;
        }

        [Command("oras")]
        public static void SetOras(IPlayer player, int oras)
        {
            player.SetWeather((uint)oras);
            player.SendChatMessage("Oras pakeistas");
        }

        [Command("veh")]
        public static void CreateVeh(IPlayer player, string vehName)
        {
            Task.Factory.StartNew(() => {
                IVehicle vehicle = Alt.CreateVehicle(vehName.ToLower(), player.Position, player.Rotation);
                Task.Delay(200).Wait();
                player.SetIntoVehicle(vehicle, 1);
            });
        }

        [Command("pos")]
        public static void findPos(IPlayer player)
        {
            float x = player.Position.X;
            float y = player.Position.Y;
            float z = player.Position.Z;

            player.SendChatMessage($"X: {x} Y: {y} Z: {z}");
            Alt.Log($"X: {x} Y: {y} Z: {z}");
        }

        [Command("ginklas")]
        public static void giveWeapon(IPlayer player)
        {
            player.GiveWeapon(0x7F7497E5, 10, false);
        }
        [Command("objektas")]
        public static void Object(IPlayer player, string pav)
        {
            Alt.EmitAllClients("Event:Objektas", pav);
        }

        [Command("web")]
        public static void web(IPlayer player)
        {
            player.Emit("Web:Create");
        }
        [Command("gw")]
        public void gw(IPlayer player)
        {
            player.GiveWeapon(0x13532244, 100, true);
        }
        [Command("rw")]
        public void rw(IPlayer player)
        {
            player.RemoveAllWeapons(true);
        }

        [Command("setmod")]
        public static void setmod(IPlayer player)
        {
            Alt.Log("Mod has been set");
            player.Vehicle.SetMod(0, 1);
            player.Vehicle.SetMod(1, 1);
            player.Vehicle.SetMod(2, 1);
        }
    }
}
