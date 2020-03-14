﻿using GAFBot.MessageSystem;
using System;

namespace GAFBot.Commands
{
    public class CompileCommand : ICommand
    {
        public char Activator { get => '!'; }
        public char ActivatorSpecial { get => default(char); }
        public string CMD { get => "compile"; }
        public AccessLevel AccessLevel => AccessLevel.Admin;

        public string Description => "Compiles and runs c# code at runtime";

        public string DescriptionUsage => "!compile c# code";

        public static void Init()
        {
            Program.CommandHandler.Register(new CompileCommand() as ICommand);
            Coding.Methods.Log(typeof(CompileCommand).Name + " Registered");
        }

        public void Activate(CommandEventArg e)
        {
            Coding.Compiler.Compile(e.AfterCMD, "", e.GuildID ?? 0, e.ChannelID, true);
        }
    }
}
