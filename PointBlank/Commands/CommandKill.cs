﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PointBlank.API.Commands;
using PointBlank.API.Unturned.Player;
using PointBlank.API.Unturned.Chat;
using UnityEngine;
using SDG.Unturned;
using Steamworks;
using Translation = PointBlank.Framework.Translations.CommandTranslations;

namespace PointBlank.Commands
{
    [PointBlankCommand("Kill", 0)]
    internal class CommandKill : PointBlankCommand
    {
        #region Properties
        public override string[] DefaultCommands => new string[]
        {
            "Kill"
        };

        public override string Help => Translation.Kill_Help;

        public override string Usage => Commands[0] + Translation.Kill_Usage;

        public override string DefaultPermission => "unturned.commands.admin.kill";
        #endregion

        public override void Execute(UnturnedPlayer executor, string[] args)
        {
            if(args.Length < 1 || UnturnedPlayer.TryGetPlayer(args[0], out UnturnedPlayer ply))
            {
                if(executor == null)
                {
                    UnturnedChat.SendMessage(executor, Translation.Base_InvalidPlayer, ConsoleColor.Red);
                    return;
                }

                ply = executor;
            }

            ply.Player.life.askDamage(255, Vector3.up * 10f, EDeathCause.KILL, ELimb.SKULL, (executor == null ? CSteamID.Nil : executor.SteamID), out EPlayerKill kill);
            UnturnedChat.SendMessage(executor, string.Format(Translation.Kill_Killed, ply.PlayerName), ConsoleColor.Green);
        }
    }
}
