﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1);
            game.Play();
        }
    }
}
