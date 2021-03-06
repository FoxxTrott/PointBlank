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
    [PointBlankCommand("Owner", 1)]
    internal class CommandOwner : PointBlankCommand
    {
        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "Owner"
        };

        public override string Help => Translation.Owner_Help;

        public override string Usage => Commands[0] + Translation.Owner_Usage;

        public override string DefaultPermission => "unturned.commands.server.owner";

        public override EAllowedServerState AllowedServerState => EAllowedServerState.LOADING;
        #endregion

        public override void Execute(UnturnedPlayer executor, string[] args)
        {
            if(!PlayerTool.tryGetSteamID(args[0], out CSteamID id))
            {
                UnturnedChat.SendMessage(executor, Translation.Base_InvalidPlayer, ConsoleColor.Red);
                return;
            }

            SteamAdminlist.ownerID = id;
            UnturnedChat.SendMessage(executor, string.Format(Translation.Owner_Set, id), ConsoleColor.Green);
        }
    }
}
