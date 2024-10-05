using UnityEngine;

public class LANG_ES : MonoBehaviour, ILangSelect
{
    private static string _START = "Empezar Juego";
    private static string _NORMAL = "modo normal";
    private static string _RUSH = "modo rush";
    private static string _CREDITS = "Créditos";
    private static string _PRESS_START = "Presiona Start";
    private static string _JOIN = "Unirse";
    private static string _COLOR_SELECT = "Elige un Color";
    private static string[] _SHIPCOLORS = {"Morado", "Naranja", "Verde", "Azul", "Rosa", "Amarillo", "Negro"};
    private static string _SHOOT = "Disparar";
    private static string _MOVE = "Moverse";
    private static string _SHOOT_ROCKET = "Lanzacohetes";
    private static string _SELECT_MODE = "Seleccionar modo";
    private static string _SELECT_COLOR = "Seleccionar color";
    private static string _CONFIRM = "Confirmar";
    private static string _GAME_BY = "Hecho por";
    private static string _MUSIC_BY = "Musica";
    private static string _PUBLISHER = "Editora";
    private static string _P1 = "J1";
    private static string _P2 = "J2";


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