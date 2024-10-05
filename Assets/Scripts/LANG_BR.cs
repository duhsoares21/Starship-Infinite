using UnityEngine;

public class LANG_BR : MonoBehaviour, ILangSelect
{
    private static string _START = "Iniciar Jogo";
    private static string _NORMAL = "modo normal";
    private static string _RUSH = "modo rush";
    private static string _CREDITS = "Créditos";
    private static string _PRESS_START = "Aperte Start";
    private static string _JOIN = "Entrar";
    private static string _COLOR_SELECT = "Escolha uma cor";
    private static string[] _SHIPCOLORS = {"Roxo", "Laranja", "Verde", "Azul", "Rosa", "Amarelo", "Preto"};
    private static string _SHOOT = "Atirar";
    private static string _MOVE = "Mover";
    private static string _SHOOT_ROCKET = "Lança-foguetes";
    private static string _SELECT_MODE = "Escolher modo";
    private static string _SELECT_COLOR = "Escolher cor";
    private static string _CONFIRM = "Confirmar";
    private static string _GAME_BY = "Feito por";
    private static string _MUSIC_BY = "Música";
    private static string _PUBLISHER = "Publicadora";
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