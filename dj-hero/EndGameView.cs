﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_hero
{
    public class EndGameView : View
    {
        private int points;
        private ConsoleKeyInfo pressedKey;
        private bool exit;
        private Song song;
        MatchOption matchOptions;
        private int counter = 0;


        string[] list = { "playAgain", "backToMenu", "exit" };
        private ViewElement selectedElement;



        public EndGameView(int _points, Song _song, MatchOption _matchOptions)
        {
            points = _points;
            song = _song;
            matchOptions = _matchOptions;


            Elements.Add("title", new ViewElement(20, 4, 10, 1, new List<string>() { "KONIEC GRY" }));
            Elements.Add("playAgain", new ViewElement(20, 10, 15, 1, new List<string>() { "Zagraj ponownie" }));
            Elements.Add("backToMenu", new ViewElement(20, 12, 14, 1, new List<string>() { "Powrót do menu" }));
            Elements.Add("exit", new ViewElement(20, 14, 11, 1, new List<string>() { "Wyjdź z gry" }));

            Elements.Add("points", new ViewElement(20, 20, 6, 2, new List<string>()
                {
                    @"WYNIK:",
                    @""+points.ToString()
                }
                ));
            selectedElement = Elements[list[0]];

            init();
        }

        private void init()
        {
            Render();
            Audio.StartServiceTrack("gameover");
            selectedElement.UpdateReverseColours();


            exit = false;
            do
            {
                pressedKey = Console.ReadKey(true);

                switch (pressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        ExitAction();
                        pressedKey = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.R:
                        exit = true;
                        PlayAgain();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveSelectedDown();
                        pressedKey = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.UpArrow:
                        MoveSelectedUp();
                        pressedKey = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.Enter:
                        exit = true;
                        EnterAction();
                        break;

                }
            } while (!exit);


        }


        private void EnterAction()
        {
            if (counter % list.Length == 0)
            {
                PlayAgain();
            }
            else if (counter % list.Length == 1)
            {
                ExitAction();
                pressedKey = new ConsoleKeyInfo();
            }
            else { System.Environment.Exit(1); }
        }

        internal void MoveSelectedUp()
        {
            selectedElement.Update();

            counter += list.Length - 1;
            int index = counter % list.Length;
            selectedElement = Elements[list[index]];
            selectedElement.UpdateReverseColours();
        }

        public void MoveSelectedDown()
        {
            selectedElement.Update();
            selectedElement = Elements[list[++counter % list.Length]];
            selectedElement.UpdateReverseColours();
        }



        private void PlayAgain()
        {
            Game game = new Game(matchOptions, song);
            game.play();
        }

        private void ExitAction()
        {
            exit = true;
            MenuView menuView = new MenuView();
            menuView.Init();
        }

    }
}
