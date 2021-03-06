﻿namespace SecondAttempt
{
    using System;
    using System.Xml.Serialization;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// Holds runtime constants.
    /// </summary>
    public class Constants
    {        
        /// <summary>
        /// Random number generator.
        /// </summary>
        public static Random Random = new Random();        

        // Battle screen constants.
        /// <summary>
        /// Used to set enemy image sprite positions        
        /// </summary>
        public static readonly Vector2[] EnemyPositions = new Vector2[] { new Vector2(120f, 120f), new Vector2(160f, 220f), new Vector2(120f, 320f) };        
        /// <summary>
        /// Used to set player image sprite positions.
        /// </summary>
        public static readonly Vector2 PlayerPosition1 = new Vector2(480f, 220f);        
        /// <summary>
        /// The maximum time interval (in seconds) it can take until a character can act in battle.
        /// </summary>
        public const int maxActionTimer = 25;

        //Frame box related constants.
        /// <summary>
        /// Pixel width of the border of a FrameBox item.
        /// </summary>
        public const int BordeWidth = 5;

        /// <summary>
        /// Dimensions for the internal area of a CommandBox
        /// </summary>
        public static readonly Rectangle CommandBoxDimensions = new Rectangle(20, (int)ScreenManager.Instance.Dimensions.Y - 170, 120, 150);

        /// <summary>
        /// ListBox frame dimensions.
        /// </summary>
        public static readonly Rectangle ListBoxDimensions = new Rectangle(20, 100, 300, 340);
        public const int ListBoxLeft = 20;
        public const int ListBoxRight = 320;
        public const int ListBoxTop = 100;

        /// <summary>
        /// Ingame menu command box dimensions.
        /// </summary>
        public static readonly Rectangle IngameMenuDimensions = new Rectangle(20, 20, 200, 30);


        public static readonly Vector2 MiniongHealthOffset = new Vector2(-30, 15);
    }
}
