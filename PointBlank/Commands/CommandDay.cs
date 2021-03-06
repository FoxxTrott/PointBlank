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
    [PointBlankCommand("Day", 0)]
    internal class CommandDay : PointBlankCommand
    {
        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "Day"
        };

        public override string Help => Translation.Day_Help;

        public override string Usage => Commands[0];

        public override string DefaultPermission => "unturned.commands.admin.day";

        public override EAllowedServerState AllowedServerState => EAllowedServerState.RUNNING;
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

            LightingManager.time = (uint)(LightingManager.cycle * LevelLighting.transition);
            UnturnedChat.SendMessage(executor, Translation.Day_Set, ConsoleColor.Green);
        }
    }
}
