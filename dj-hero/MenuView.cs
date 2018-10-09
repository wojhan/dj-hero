﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dj_hero
{
    public class MenuView : View
    {
        

        public override void Render()
        {
            string logo = "LOGO";
            Elements.Add(new ViewElement((Console.WindowWidth - 40) / 2, 0, 80, 6, 
                new List<object>()
                {
                    @"______  ___   _   _  ___________ _____",
                    @"|  _  \|_  | | | | ||  ___| ___ \  _  |",
                    @"| | | |  | | | |_| || |__ | |_/ / | | |",
                    @"| | | |  | | |  _  ||  __||    /| | | |",
                    @"| |/ /\__/ / | | | || |___| |\ \\ \_/ /",
                    @"|___/\____/  \_| |_/\____/\_| \_|\___/"
                }
                ));
            Elements.Add(new ViewElement(20, 10, 7, 1, new List<object>() { "1. Play" }));
            Elements.Add(new ViewElement(20, 12, 10, 1, new List<object>() { "2. Options" }));
            Elements.Add(new ViewElement(20, 14, 7, 1, new List<object>() { "3. Rank" }));
            Elements.Add(new ViewElement(20, 16, 8, 1, new List<object>() { "4. Exit" }));
            base.Render();
            //Console.WriteLine("LOGO");
            //Console.WriteLine("1.Play");
            //Console.WriteLine("2.Options");
            //Console.WriteLine("3.rank");
            //Console.WriteLine("4.Exit");

            

        }
        
    }
}
