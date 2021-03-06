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
    [PointBlankCommand("Airdrop", 0)]
    internal class CommandAirdrop : PointBlankCommand
    {
        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "Airdrop"
        };

        public override string Help => Translation.Airdrop_Help;

        public override string Usage => Commands[0];

        public override string DefaultPermission => "unturned.commands.admin.airdrop";
        #endregion

        public override void Execute(UnturnedPlayer executor, string[] args)
        {
            if (LevelManager.hasAirdrop)
                return;

            LevelManager.airdropFrequency = 0u;
            UnturnedChat.SendMessage(executor, Translation.Airdrop_Success, ConsoleColor.Green);
        }
    }
}
