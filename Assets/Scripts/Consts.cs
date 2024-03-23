/// <summary>
/// Purpose of this class is to have a single place to keep our constants.
/// This makes configuring various aspects of the game really easy.
/// The inner classes form categories so everything is organized
/// </summary>
public static class Consts {
    /// <summary>
    /// Constants that correspond to custom tags in Unity
    /// </summary>
    public static class Tags {
        public const string BALL_START = "BallStart";
        public const string BALL_END = "BallEnd";
        public const string SCORE_CIRCLE = "ScoreCircle";
        public const string FLIPPER = "Flipper";
        public const string RAMP_START = "RampStart";
        public const string RAMP_HOLE = "RampHole";
    }

    /// <summary>
    /// Used for setting and getting PlayerPrefs values.
    /// Put any PlayerPrefs dictionary keys here
    /// </summary>
    public static class PlayerPrefs {
        public const string HIGHSCORE = "highscore";
    }

    /// <summary>
    /// Keeps all the points awarded to the player for 
    /// various actions and collisions
    /// </summary>
    public static class Points {
        public const int HIT_BUMPER = 100;
        public const int HIT_FLIPPER = 10;
        public const int HIT_SCORE_CIRCLE_NORMAL = 150;
        public const int HIT_SCORE_CIRCLE_ACTIVE = 500;
    }
}
