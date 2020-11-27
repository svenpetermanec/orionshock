using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Orion.Core;
using Orion.Core.Npcs;
using Orion.Core.Packets.DataStructures;
using Orion.Core.Packets.Npcs;
using Orion.Core.Packets.World;
using Orion.Core.Players;
using Orion.Core.Utils;
using OrionShock.Commands;
using OrionShock.Commands.Attributed;

namespace OrionShock {
    internal sealed class OrionShockCommands {
        private static readonly IDictionary<string, INpc> NpcCache = new Dictionary<string, INpc>();

        private readonly IServer _server;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OrionShockCommands"/> class.
        /// </summary>
        /// <param name="server">The server instance.</param>
        public OrionShockCommands([NotNull] IServer server) {
            _server = server ?? throw new ArgumentNullException(nameof(server));
        }

        [Command("butcher", "Butchers active NPCs.")]
        [UsedImplicitly]
        private void Butcher(ICommandSender sender) {
            var npcCount = 0;
            var npcService = _server.Npcs;
            var playerService = _server.Players;
            var npcInfoPacket = new NpcInfo();

            foreach (var npc in npcService.Where(n => n != null && n.IsActive && n.Health > 0 && !Terraria.Main.npc[n.Index].friendly && !Terraria.Main.npc[n.Index].townNPC)) {
                npc.IsActive = false;
                npcInfoPacket.NpcIndex = (short)npc.Index;
                playerService.BroadcastPacket(npcInfoPacket);
                ++npcCount;
            }

            sender.SendMessage($"Butchered {npcCount} NPC(s).");
        }

        [Command("time", "Sets the world time.")]
        [UsedImplicitly]
        private void SetTime(int hours, int minutes) {
            var time = hours % 24 + minutes / 60.0m - 4.50m;
            if (time < 0.00m) {
                time += 24.00m;
            }

            var playerService = _server.Players;
            var worldInfo = new WorldInfo();
            if (time >= 15.00m) {
                worldInfo.IsDayTime = false;
                worldInfo.Time = (int)((time - 15.00m) * 3600.0m);
            }
            else {
                worldInfo.IsDayTime = true;
                worldInfo.Time = (int)(time * 3600.0m);
            }

            Terraria.Main.dayTime = worldInfo.IsDayTime;
            Terraria.Main.time = worldInfo.Time;
            playerService.BroadcastPacket(worldInfo);
            playerService.BroadcastMessage(
                new NetworkText(
                    NetworkTextMode.Literal, $"Time has been set to {hours % 24 + minutes / 60:D2}:{minutes % 60:D2}"), new Color3(255, 255, 0));
        }
    }
}