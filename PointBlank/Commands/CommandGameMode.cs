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
    [PointBlankCommand("GameMode", 1)]
    internal class CommandGameMode : PointBlankCommand
    {
        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "GameMode"
        };

        public override string Help => Translation.GameMode_Help;

        public override string Usage => Commands[0] + Translation.GameMode_Usage;

        public override string DefaultPermission => "unturned.commands.server.gamemode";

        public override EAllowedServerState AllowedServerState => EAllowedServerState.LOADING;
        #endregion

        public override void Execute(UnturnedPlayer executor, string[] args)
        {
            Provider.selectedGameModeName = args[0];
            UnturnedChat.SendMessage(executor, string.Format(Translation.GameMode_Set, args[0]), ConsoleColor.Green);
        }
    }
}
