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
    [PointBlankCommand("Sync", 0)]
    internal class CommandSync : PointBlankCommand
    {
        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "Sync"
        };

        public override string Help => Translation.Sync_Help;

        public override string Usage => Commands[0];

        public override string DefaultPermission => "unturned.commands.server.sync";

        public override EAllowedServerState AllowedServerState => EAllowedServerState.LOADING;
        #endregion

        public override void Execute(UnturnedPlayer executor, string[] args)
        {
            PlayerSavedata.hasSync = true;
            UnturnedChat.SendMessage(executor, Translation.Sync_Sync, ConsoleColor.Green);
        }
    }
}
