﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetsieTrailGame
{
    interface ITextInputReader
    {
        void waitForKeyPress();
        String getLine();
    }
}
