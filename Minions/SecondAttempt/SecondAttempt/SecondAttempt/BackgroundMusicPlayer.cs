namespace SecondAttempt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;

    public static class BackgroundMusicPlayer
    {
        public static float Volume { get; set; }

        public static void Initialize()
        {
            Volume = 0.5f;
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
