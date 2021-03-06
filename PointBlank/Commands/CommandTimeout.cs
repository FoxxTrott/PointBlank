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
    [PointBlankCommand("Timeout", 1)]
    internal class CommandTimeout : PointBlankCommand
    {
        #region Info
        private static readonly ushort MIN_NUMBER = 50;
        private static readonly ushort MAX_NUMBER = 10000;
        #endregion

        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "Timeout"
        };

        public override string Help => Translation.Timeout_Help;

        public override string Usage => Commands[0] + Translation.Timeout_Usage;

        public override string DefaultPermission => "unturned.commands.server.timeout";
        #endregion

        public override void Execute(UnturnedPlayer executor, string[] args)
        {
            if(!uint.TryParse(args[0], out uint timeout))
            {
                UnturnedChat.SendMessage(executor, Translation.Timeout_Invalid, ConsoleColor.Red);
                return;
            }
            if(timeout > MAX_NUMBER)
            {
                UnturnedChat.SendMessage(executor, string.Format(Translation.Timeout_TooHigh, MAX_NUMBER), ConsoleColor.Red);
                return;
            }
            else if(timeout < MIN_NUMBER)
            {
                UnturnedChat.SendMessage(executor, string.Format(Translation.Timeout_TooLow, MIN_NUMBER), ConsoleColor.Red);
                return;
            }

            if (Provider.configData != null)
                Provider.configData.Server.Max_Ping_Milliseconds = timeout;
            UnturnedChat.SendMessage(executor, string.Format(Translation.Timeout_Set, timeout), ConsoleColor.Green);
        }
    }
}
