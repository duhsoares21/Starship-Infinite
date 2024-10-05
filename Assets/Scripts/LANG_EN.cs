using UnityEngine;

public class LANG_EN : MonoBehaviour, ILangSelect
    {
    private static string _START = "Start Game";
    private static string _NORMAL = "normal mode";
    private static string _RUSH = "rush mode";
    private static string _CREDITS = "Credits";
    private static string _PRESS_START = "Press Start";
    private static string _JOIN = "Join";
    private static string _COLOR_SELECT = "Color Select";
    private static string[] _SHIPCOLORS = {"Purple", "Orange", "Green", "Blue", "Pink", "Yellow", "Black"};
    private static string _SHOOT = "Fire";
    private static string _MOVE = "Move";
    private static string _SHOOT_ROCKET = "Rocket Launcher";
    private static string _SELECT_MODE = "Select mode";
    private static string _SELECT_COLOR = "Select color";
    private static string _CONFIRM = "Confirm";
    private static string _GAME_BY = "Game by";
    private static string _MUSIC_BY = "Music by";
    private static string _PUBLISHER = "Publisher";
    private static string _P1 = "P1";
    private static string _P2 = "P2";


    public string START { get => _START; }
    public string NORMAL { get => _NORMAL; }
    public string RUSH { get => _RUSH; }
    public string CREDITS { get => _CREDITS; }
    public string PRESS_START { get => _PRESS_START; }
    public string JOIN { get => _JOIN; }
    public string COLOR_SELECT { get => _COLOR_SELECT; }
    public string[] SHIPCOLORS { get => _SHIPCOLORS; }
    public string SHOOT { get => _SHOOT; }
    public string MOVE { get => _MOVE; }
    public string SHOOT_ROCKET { get => _SHOOT_ROCKET; }
    public string SELECT_MODE { get => _SELECT_MODE; }
    public string SELECT_COLOR { get => _SELECT_COLOR; }
    public string CONFIRM { get => _CONFIRM; }
    public string GAME_BY { get => _GAME_BY; }
    public string MUSIC_BY { get => _MUSIC_BY; }
    public string PUBLISHER { get => _PUBLISHER; }
    public string P1 { get => _P1; }
    public string P2 { get => _P2; }

}
