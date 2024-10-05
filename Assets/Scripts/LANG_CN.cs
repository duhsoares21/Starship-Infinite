using UnityEngine;

public class LANG_CN : MonoBehaviour, ILangSelect
{
    private static string _START = "开始游戏";
    private static string _NORMAL = "正常模式";
    private static string _RUSH = "疯狂模式";
    private static string _CREDITS = "学分";
    private static string _PRESS_START = "按开始";
    private static string _JOIN = "加入";
    private static string _COLOR_SELECT = "颜色选择";
    private static string[] _SHIPCOLORS = {"紫色", "橙色", "绿色", "蓝色", "粉红色", "黄色", "黑色"};
    private static string _SHOOT = "射擊";
    private static string _MOVE = "移動";
    private static string _SHOOT_ROCKET = "火箭發射器";
    private static string _SELECT_MODE = "選擇模式";
    private static string _SELECT_COLOR = "選擇顏色";
    private static string _CONFIRM = "確認";
    private static string _GAME_BY = "由製成";
    private static string _MUSIC_BY = "音樂人";
    private static string _PUBLISHER = "發行人";
    private static string _P1 = "P1";
    private static string _P2 = "P2";


    public string START { get => _START; }
    public string NORMAL { get => _NORMAL; }
    public string RUSH { get => _RUSH; }
    public string CREDITS { get => _CREDITS; }
    public string PRESS_START { get => _PRESS_START; }
    public string COLOR_SELECT { get => _COLOR_SELECT; }
    public string JOIN { get => _JOIN; }
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