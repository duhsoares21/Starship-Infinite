using UnityEngine;

public class LANG_RU : MonoBehaviour, ILangSelect
{
    private static string _START = "Начало игры";
    private static string _NORMAL = "нормальный режим";
    private static string _RUSH = "режим спешки";
    private static string _CREDITS = "титры";
    private static string _PRESS_START = "нажмите старт";
    private static string _JOIN = "присоединиться к";
    private static string _COLOR_SELECT = "Выбор цвета";
    private static string[] _SHIPCOLORS = {"Фиолетовый", "оранжевый", "Зеленый", "синий", "розовый", "желтый", "чернить"};
    private static string _SHOOT = "стрелять";
    private static string _MOVE = "двигаться";
    private static string _SHOOT_ROCKET = "Ракетная пусковая установка";
    private static string _SELECT_MODE = "Выбрать режим";
    private static string _SELECT_COLOR = "Выбрать цвет";
    private static string _CONFIRM = "Подтверждать";
    private static string _GAME_BY = "Автор игры";
    private static string _MUSIC_BY = "Музыка от";
    private static string _PUBLISHER = "Издатель";
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