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
    [PointBlankCommand("Mode", 1)]
    internal class CommandMode : PointBlankCommand
    {
        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "Mode"
        };

        public override string Help => Translation.Mode_Help;

        public override string Usage => Commands[0] + Translation.Mode_Usage;

        public override string DefaultPermission => "unturned.commands.server.mode";

        public override EAllowedServerState AllowedServerState => EAllowedServerState.LOADING;
        #endregion

        public override void Execute(UnturnedPlayer executor, string[] args)
        {
            switch(args[0].ToUpperInvariant())
            {
                case "EASY":
                    Provider.mode = EGameMode.EASY;
                    break;
                case "NORMAL":
                    Provider.mode = EGameMode.NORMAL;
                    break;
                case "HARD":
                    Provider.mode = EGameMode.HARD;
                    break;
                default:
                    UnturnedChat.SendMessage(executor, Translation.Mode_Invalid, ConsoleColor.Red);
                    return;
                    break;
            }

            UnturnedChat.SendMessage(executor, string.Format(Translation.Mode_Set, Provider.mode), ConsoleColor.Green);
        }
    }
}
