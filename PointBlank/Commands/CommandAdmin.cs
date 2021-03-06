﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PointBlank.API.Commands;
using PointBlank.API.Unturned.Player;
using PointBlank.API.Unturned.Chat;
using UnityEngine;
using Steamworks;
using SDG.Unturned;
using Translation = PointBlank.Framework.Translations.CommandTranslations;

namespace PointBlank.Commands
{
    [PointBlankCommand("Admin", 1)]
    internal class CommandAdmin : PointBlankCommand
    {
        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "Admin"
        };

        public override string Help => Translation.Admin_Help;

        public override string Usage => Commands[0] + Translation.Admin_Usage;

        public override string DefaultPermission => "unturned.commands.admin.admin";

        public override EAllowedServerState AllowedServerState => EAllowedServerState.RUNNING;
        #endregion

        public override void Execute(UnturnedPlayer executor, string[] args)
        {
            if (!PlayerTool.tryGetSteamID(args[0], out CSteamID player))
            {
                UnturnedChat.SendMessage(executor, Translation.Base_InvalidPlayer, ConsoleColor.Red);
                return;
            }

            if (executor == null)
            {
                SteamAdminlist.admin(player, CSteamID.Nil);
                CommandWindow.Log(string.Format(Translation.Admin_Set, player), ConsoleColor.Green);

            }
            else
            {
                SteamAdminlist.admin(player, executor.SteamID);
                executor.SendMessage(string.Format(Translation.Admin_Set, player), Color.green);
            }
        }
    }
}
