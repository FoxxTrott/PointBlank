﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PointBlank.API.Commands;
using PointBlank.API.Unturned.Player;
using PointBlank.API.Unturned.Chat;
using SDG.Unturned;
using Translation = PointBlank.Framework.Translations.CommandTranslations;

namespace PointBlank.Commands
{
    [PointBlankCommand("Night", 0)]
    internal class CommandNight : PointBlankCommand
    {
        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "Night"
        };

        public override string Help => Translation.Night_Help;

        public override string Usage => Commands[0];

        public override string DefaultPermission => "unturned.commands.admin.night";
        #endregion

        public override void Execute(UnturnedPlayer executor, string[] args)
        {
            if (Provider.isServer && Level.info.type == ELevelType.ARENA)
            {
                UnturnedChat.SendMessage(executor, Translation.Base_NoArenaTime, ConsoleColor.Red);
                return;
            }
            if (Provider.isServer && Level.info.type == ELevelType.HORDE)
            {
                UnturnedChat.SendMessage(executor, Translation.Base_NoHordeTime, ConsoleColor.Red);
                return;
            }

            LightingManager.time = (uint)(LightingManager.cycle * (LevelLighting.bias + LevelLighting.transition));
            UnturnedChat.SendMessage(executor, Translation.Night_Set, ConsoleColor.Green);
        }
    }
}
