using UnityEngine;

public class LANG_KR : MonoBehaviour, ILangSelect
{
    private static string _START = "게임 시작";
    private static string _NORMAL = "일반 모드";
    private static string _RUSH = "러시 모드";
    private static string _CREDITS = "크레딧";
    private static string _PRESS_START = "보도 시작";
    private static string _JOIN = "가입";
    private static string _COLOR_SELECT = "색상 선택";
    private static string[] _SHIPCOLORS = {"보라색", "오렌지", "녹색", "블루", "핑크", "노란색", "블랙"};
    private static string _SHOOT = "사격";
    private static string _MOVE = "움직임";
    private static string _SHOOT_ROCKET = "로켓 발사기";
    private static string _SELECT_MODE = "모드 선택";
    private static string _SELECT_COLOR = "색상 선택";
    private static string _CONFIRM = "확인";
    private static string _GAME_BY = "게임";
    private static string _MUSIC_BY = "음악";
    private static string _PUBLISHER = "발행자";
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