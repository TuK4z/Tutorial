using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltV.Net.Elements.Entities;
using AltV.Net.Data;

namespace Tutorial
{
    internal class Commands : IScript
    {
        [Command("oras")]
        public static void setOras(IPlayer player, int oras)
        {
            player.SetWeather((uint)oras);
            player.SendChatMessage("Oras pakeistas");
        }

        [Command("veh")]
        public static void creatVeh(IPlayer player, string vehName)
        {
            IVehicle vehicle = Alt.CreateVehicle(vehName, new Position(0, 0, 0), new Rotation(0, 0, 0));
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
    }
}
