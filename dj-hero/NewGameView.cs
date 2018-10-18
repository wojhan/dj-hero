﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public class NewGameView : View
    {

        private string nick;
        private ViewElement header;
        private ViewElement nickname;
        private Thread t;
        private Boolean exit;
        private ConsoleKeyInfo pressedKey;

        public NewGameView()
        {
            pressedKey = new ConsoleKeyInfo();
            nick = "";
            header = new ViewElement((Console.WindowWidth - 5) / 2, 3, 10, 1, new List<string>() { "Podaj nick" });
            nickname = new ViewElement(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 2, 40, 5, new List<string>()
            {
                @"╔══════════════════════════════════════╗",
                @"║                                      ║",
                @"║                                      ║",
                @"║                                      ║",
                @"╚══════════════════════════════════════╝"
            }
            );

            Elements.Add("alert", new ViewElement(Console.WindowWidth / 2 - 18, Console.WindowHeight / 2 + 6, 40, 1, new List<string>()
                {"Invalid nickname" }));

            Elements.Add("Header", header);
            Elements.Add("Nickname", nickname);
        }


        public void Init()
        {
            Render();
            Elements["alert"].Clear();


            Console.SetCursorPosition(nickname.PosX + 2, nickname.PosY + 2);
            Console.CursorVisible = true;

            exit = false;
            do
            {
                pressedKey = Console.ReadKey(false);

                switch (pressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        ExitAction();
                        pressedKey = new ConsoleKeyInfo();
                        break;
                    case ConsoleKey.Enter:
                        EnterAction();
                        break;
                    default:
                        if (char.IsLetterOrDigit(pressedKey.KeyChar))
                        {
                            nick += pressedKey.KeyChar;
                        }
                        break;
                }
            } while (!exit);

        }

        private void ExitAction()
        {
            exit = true;
            Console.CursorVisible = false;
            MenuView menuView = new MenuView();
            menuView.Init();
        }


        private bool validationNickname()
        {




            return true;
        }

        private void EnterAction()
        {
            if(nick.Trim().Length <= 0)
            {
                //cw invalid name
                Elements["alert"].Update();



                Console.SetCursorPosition(nickname.PosX + 2, nickname.PosY + 2);
                return;
            }

            exit = true;
            Console.CursorVisible = false;
            SongSlectionView songSlectionView = new SongSlectionView(nick.Trim());
            songSlectionView.Init();
        }

        public string GetNick()
        {
            return nick;
        }
    }
}