namespace SecondAttempt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (GameExtension game = new GameExtension())
            {
                game.Run();
            }
        }
    }
}

