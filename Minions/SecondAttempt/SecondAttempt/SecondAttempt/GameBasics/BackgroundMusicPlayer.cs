namespace SecondAttempt
{     
    using Microsoft.Xna.Framework.Media;

    /// <summary>
    /// Plays some music
    /// </summary>
    public static class BackgroundMusicPlayer
    {
        public static float Volume;

        public static void Initialize()
        {
            Volume = 0.1f;
            MediaPlayer.Volume = Volume;
            MediaPlayer.IsRepeating = true;
        }

        public static void Play(Song backroundMusic)
        {
            MediaPlayer.Play(backroundMusic);
        }

        public static void Stop()
        {
            MediaPlayer.Stop();
        }
    }
}
