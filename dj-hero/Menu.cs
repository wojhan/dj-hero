﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public static class Menu
    {


        private static int selectedOption = 0;
        private static ConsoleKeyInfo pressedKey;

        public static void Init()
        {
            MenuView menuView = new MenuView();
            menuView.Render();


            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            Task.Factory.StartNew(() =>
            {
                do
                {
                    pressedKey = Console.ReadKey(true);
                    //if(pressedKey.Key == ConsoleKey.D1)
                    //{
                    //    break;
                    //}
                    Thread.Sleep(10);


                } while (!ct.IsCancellationRequested);
                //while (true)
                //{

                //    if (ct.IsCancellationRequested)
                //    {
                //        // another thread decided to cancel
                //        break;
                //    }
                //    pressedKey = Console.ReadKey(true);
                //}
            }, ct);

            do
            {
                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        ts.Cancel();
                        //pressedKey = new ConsoleKeyInfo();
                        Menu.Play();
                        break;
                    case ConsoleKey.D2:
                        Menu.Options();
                        break;
                    case ConsoleKey.D3:
                        Menu.Rank();
                        break;
                    case ConsoleKey.D4:
                        Menu.Exit();
                        break;

                }
            } while (!ct.IsCancellationRequested);
            //while (true)
            //{
            //    switch (pressedKey.Key)
            //    {
            //        case ConsoleKey.D1:
            //            ts.Cancel();
            //            Menu.Play();
            //            pressedKey = new ConsoleKeyInfo();
            //            break;
            //        case ConsoleKey.D2:
            //            Menu.Options();
            //            break;
            //        case ConsoleKey.D3:
            //            Menu.Rank();
            //            break;
            //        case ConsoleKey.D4:
            //            Menu.Exit();
            //            break;
                    
            //    }

            //}
        }


        // switch to window difficult chose
        public static void Play()
        {
            //GameView gameView = new GameView();
            //gameView.Render();
            Game game = Game.Instance;
            game.play();
        }

        public static void Options()
        {

        }

        public static void Rank()
        {

        }

        public static void Exit()
        {
            System.Environment.Exit(1);
        }

    }
}
