﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.Objects
{
    public class Ball : GameObject
    {
        public Ball(GameForm form, int x, int y, int width, int height) : base(form, x, y, width, height, null)
        {

        }

    }
}
