using UnityEngine;

public class LANG_PL : MonoBehaviour, ILangSelect
{
    private static string _START = "Uruchomić grę";
    private static string _NORMAL = "Tryb normalny";
    private static string _RUSH = "Tryb pośpiechu";
    private static string _CREDITS = "Napisy końcowe";
    private static string _PRESS_START = "Naciśnij Start";
    private static string _JOIN = "Dołączyć";
    private static string _COLOR_SELECT = "Wybierz kolor";
    private static string[] _SHIPCOLORS = {"Fioletowy", "Pomarańczowy", "Zielony", "Niebieski", "Różowy", "Żółty", "Czarny"};
    private static string _SHOOT = "Strzelać";
    private static string _MOVE = "Ruszaj się";
    private static string _SHOOT_ROCKET = "Wyrzutnia rakiet";
    private static string _SELECT_MODE = "Wybierz tryb";
    private static string _SELECT_COLOR = "Wybierz kolor";
    private static string _CONFIRM = "Potwierdzać";
    private static string _GAME_BY = "Gra według";
    private static string _MUSIC_BY = "Muzyka stworzona przez";
    private static string _PUBLISHER = "Wydawca";
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