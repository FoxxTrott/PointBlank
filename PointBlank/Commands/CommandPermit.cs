﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PointBlank.API.Commands;
using PointBlank.API.Unturned.Player;
using PointBlank.API.Unturned.Chat;
using SDG.Unturned;
using Steamworks;
using Translation = PointBlank.Framework.Translations.CommandTranslations;

namespace PointBlank.Commands
{
    [PointBlankCommand("Permit", 2)]
    internal class CommandPermit : PointBlankCommand
    {
        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "Permit"
        };

        public override string Help => Translation.Permit_Help;

        public override string Usage => Commands[0] + Translation.Permit_Usage;

        public override string DefaultPermission => "unturned.commands.admin.permit";
        #endregion

        public override void Execute(UnturnedPlayer executor, string[] args)
        {
            if(!PlayerTool.tryGetSteamID(args[0], out CSteamID id))
            {
                UnturnedChat.SendMessage(executor, Translation.Base_InvalidPlayer, ConsoleColor.Red);
                return;
            }

            SteamWhitelist.whitelist(id, args[1], (executor == null ? CSteamID.Nil : executor.SteamID));
            UnturnedChat.SendMessage(executor, string.Format(Translation.Permit_Added, id), ConsoleColor.Green);
        }
    }
}
