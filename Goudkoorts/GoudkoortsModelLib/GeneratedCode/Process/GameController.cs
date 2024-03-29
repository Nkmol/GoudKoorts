﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GoudkoortsModelLib.GeneratedCode.Presentation;
using Model;
using Presentation;

namespace Process
{
    public class GameController
    {
        public static List<char> SwitchButtons = new List<char>
        {
            'A',
            'S',
            'D',
            'X',
            'C'
        };

        public GameController()
        {
            // create models
            Game = new Game();
            Game.Timer.Elapsed += (source, e) => DrawTick();
            Game.GameOverAction = OnGameOver;

            // create Views
            LevelView = new LevelView();
            LobbyView = new LobbyView();
        }

        public virtual LobbyView LobbyView { get; set; }

        public virtual LevelView LevelView { get; set; }

        public virtual Game Game { get; set; }

        public virtual void Stop()
        {
            throw new NotImplementedException();
        }

        public virtual void Start()
        {
            LobbyView.ShowWelcome();

            Run();
        }

        public virtual void Run()
        {
            Game.Run();
            LevelView.Print(Game.Board);

            while (true) // TODO cleaner way of not shutting down application
            {
                var key = char.ToUpper(InputController.AskUserInput());

                //SwitchTile sw = game.Board.Field[5][7] as SwitchTile;
                //Console.WriteLine("\n"+sw.Direction.y);

                var index = GetKeyIndex(key);

                // Validation necessary
                if(index != -1)
                Board.Switches[index].Switch();

                //Console.WriteLine(sw.Direction.y);
            } 
        }

        public virtual void DrawTick()
        {
            LevelView.Print(Game.Board);
        }

        public int GetKeyIndex(char key)
        {
            return SwitchButtons.FindIndex(x => x == key);
        }

        public void OnGameOver()
        {
            //TODO
            new GameOverView().Print(Game.Board);
        }
    }
}