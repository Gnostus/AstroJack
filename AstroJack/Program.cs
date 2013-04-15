using System;

namespace AstroJack
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (AstroJack game = new AstroJack())
            {
                game.Run();
            }
        }
    }
#endif
}

