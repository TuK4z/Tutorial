using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace Tutorial
{
    internal class Main : IScript
    {
        [ScriptEvent(ScriptEventType.PlayerConnect)]
        public void OnPlayerConnect(IPlayer player, string reason)
        {
            Console.WriteLine($"[{player.Id}] Žaidėjas jungiasi: {player.Name}");
            // We loop through every player on our server and notify them
            foreach (IPlayer players in Alt.GetAllPlayers())
            {
                // We notify everyone that our Client has joined the Server
                players.SendChatMessage(player.Name + " has joined the Server.");
            }
            // We spawn the newly connected player
            player.Spawn(new Position(-19.92f, 14.294506f, 71.79f));

            //-19,925274 Y: 14,294506 Z: 71,79199

            // We set his skin to the standard gta online freemode skin
            //player.Model = Alt.Hash("FreemodeMale01");

            player.Model = (uint)PedModel.FreemodeMale01;
        }
    }
}