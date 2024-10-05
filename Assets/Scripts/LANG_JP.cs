using UnityEngine;

public class LANG_JP : MonoBehaviour, ILangSelect
{
    private static string _START = "スタート";
    private static string _NORMAL = "通常モード";
    private static string _RUSH = "ラッシュモード";
    private static string _CREDITS = "クレジット";
    private static string _PRESS_START = "スタートを押す";
    private static string _JOIN = "参加";
    private static string _COLOR_SELECT = "色選択";
    private static string[] _SHIPCOLORS = {"パープル (紫)", "オレンジ (橙)", "グリーン (緑)", "ブル (青)", "ピンク", "イェロー (黄)", "ブラック (黒)"};
    private static string _SHOOT = "射撃";
    private static string _MOVE = "動き";
    private static string _SHOOT_ROCKET = "ロケットランチャー";
    private static string _SELECT_MODE = "モードを選択";
    private static string _SELECT_COLOR = "色を選択";
    private static string _CONFIRM = "確認";
    private static string _GAME_BY = "ゲーム";
    private static string _MUSIC_BY = "による音楽";
    private static string _PUBLISHER = "出版社";
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