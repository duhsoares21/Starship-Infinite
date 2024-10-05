using UnityEngine;

public class LANG_AR : MonoBehaviour, ILangSelect
{
    private static string _START = "بداية اللعبة";
    private static string _NORMAL = "لوضع الافتراضي";
    private static string _RUSH = "وضع مجنون";
    private static string _CREDITS = "الإئتمانات";
    private static string _PRESS_START = "اضغط على زر البداية";
    private static string _JOIN = "انضم";
    private static string _COLOR_SELECT = "تحديد اللون";
    private static string[] _SHIPCOLORS = 
    {
        "أرجواني", 
        "لون برتقالي", 
        "لون أخضر", 
        "أزرق", 
        "زهري", 
        "أصفر", 
        "أسود"
    };

    private static string _SHOOT = "أطلق النار";
    private static string _MOVE = "يتحرك";
    private static string _SHOOT_ROCKET = "قاذفة الصواريخ";
    private static string _SELECT_MODE = "حدد الوضع";
    private static string _SELECT_COLOR = "إختر لون";
    private static string _CONFIRM = "يتأكد";
    private static string _GAME_BY = "مصنوع بواسطة";
    private static string _MUSIC_BY = "موسيقى";
    private static string _PUBLISHER = "الناشر";
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