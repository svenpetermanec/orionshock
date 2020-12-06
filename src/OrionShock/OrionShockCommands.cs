using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
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
using OrionShock.Extensions;

namespace OrionShock {
    /// <summary>
    /// Defines methods that represent commands handlers.
    /// </summary>
    internal sealed class OrionShockCommands {
        private readonly IDictionary<string, NpcId> _npcLookup = new ConcurrentDictionary<string, NpcId>();
        private readonly IServer _server;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OrionShockCommands"/> class.
        /// </summary>
        /// <param name="server">The server instance.</param>
        public OrionShockCommands([NotNull] IServer server) {
            _server = server ?? throw new ArgumentNullException(nameof(server));

            InitializeLookups();
            Parsers.Instance.AddParser(typeof(NpcId), ParseNpcId);
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
            var worldTime = default(WorldTime);
            if (time >= 15.00m) {
                worldTime.IsDayTime = false;
                worldTime.Time = (int)((time - 15.00m) * 3600.0m);
            }
            else {
                worldTime.IsDayTime = true;
                worldTime.Time = (int)(time * 3600.0m);
            }

            Terraria.Main.dayTime = worldTime.IsDayTime;
            Terraria.Main.time = worldTime.Time;
            playerService.BroadcastPacket(worldTime);
            playerService.BroadcastMessage(
                new NetworkText(
                    NetworkTextMode.Literal, $"Time has been set to {hours % 24 + minutes / 60:D2}:{minutes % 60:D2}"), new Color3(255, 255, 0));
        }

        [Command("spawnnpc", "Spawns an NPC with the given ID or name.")]
        private void SpawnNpc(ICommandSender sender, NpcId npcId, [Option("x")] int x, [Option("y")] int y, [Option("amount")] int amount) {
            if ((x <= 0 || y <= 0) && sender is ConsoleCommandSender) {
                sender.SendMessage("You must provide coordinates when spawning mobs via console: spawnmob <npc ID or name> -x <tile x> -y <tile y>");
                return;
            }

            if (npcId == NpcId.None) {
                sender.SendMessage("Invalid NPC.");
                return;
            }

            var playerSender = sender as PlayerCommandSender;
            x = x <= 0 ? (int)playerSender.Player.Position.X / 16 : x;
            y = y <= 0 ? (int)playerSender.Player.Position.Y / 16 : y;
            amount = Math.Max(1, amount);

            for (var i = 0; i < amount; ++i) {
                _server.Npcs.Spawn(npcId, new Vector2f(x * 16, y * 16));
            }

            sender.SendMessage($"You have spawned {amount} '{npcId.ToString().SplitPascalCase()}' NPC(s).");
        }

        private void InitializeLookups() {
            Terraria.NPC npc = new Terraria.NPC();
            for (var i = -17; i < Terraria.Main.maxNPCTypes; ++i) {
                npc.SetDefaults(i);
                _npcLookup[Terraria.Lang.GetNPCNameValue(i)] = (NpcId)i;
            }
        }

        private object ParseNpcId(string input) {
            if (string.IsNullOrWhiteSpace(input)) {
                throw new ArgumentException(nameof(input));
            }

            if (int.TryParse(input, out var npcId) && npcId > 0 && npcId < Terraria.Main.maxNPCTypes) {
                return (NpcId)npcId;
            }

            var matches = new List<NpcId>();
            foreach (var (name, id) in _npcLookup) {
                if (name.Equals(input, StringComparison.CurrentCulture)) {
                    return id;
                }

                if (name.StartsWith(input, StringComparison.CurrentCulture)) {
                    matches.Add(id);
                }
            }

            return matches.Count == 1 ? matches[0] : NpcId.None;
        }
    }
}