﻿using System;

namespace A20_Ex04_Daniel_203105572_Dor_206318537
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GameDradleSpin())
                game.Run();
        }
    }
#endif
}
