using UnityEngine;

public class UserServiceManager : MonoBehaviour
{
    [SerializeField]
    private bool Local;
    [SerializeField]
    private bool Live;
    [SerializeField]
    private bool PSN;
    [SerializeField]
    private bool Steam;
    [SerializeField]
    private bool GooglePlay;

    public IUserManager currentService;
    public IRewardService currentReward;

    [SerializeField]
    private LocalUserManager localUserManager;
    [SerializeField]
    private LiveUserManager liveUserManager;
    [SerializeField]
    private PSNUserManager psnUserManager;
    [SerializeField]
    private SteamUserManager steamUserManager;
    [SerializeField]
    private GooglePlayUserManager googleplayUserManager;
    [SerializeField]
    private BoxHouseMissions boxHouseMissions;
    [SerializeField]
    private XboxAchievments xboxAchievments;
    [SerializeField]
    private PSNTrophies psnTrophies;
    [SerializeField]
    private SteamAchievments steamAchievments;
    [SerializeField]
    private GooglePlayAchievments googlePlayAchievments;

    void Awake()
    {
        localUserManager = GetComponent<LocalUserManager>();
        liveUserManager = GetComponent<LiveUserManager>();
        psnUserManager = GetComponent<PSNUserManager>();
        steamUserManager = GetComponent<SteamUserManager>();
        googleplayUserManager = GetComponent<GooglePlayUserManager>();

        boxHouseMissions = GetComponent<BoxHouseMissions>();
        xboxAchievments = GetComponent<XboxAchievments>();
        psnTrophies = GetComponent<PSNTrophies>();
        steamAchievments = GetComponent<SteamAchievments>();
        googlePlayAchievments = GetComponent<GooglePlayAchievments>();

        GetUserService();
        //GetRewardService();
    }

    public IUserManager GetUserService()
    {
        if(Local)
        {
            currentService = localUserManager;
        }
        else if(Live)
        {
            currentService = liveUserManager;
        }
        else if(PSN)
        {
            currentService = psnUserManager;
        }
        else if(Steam)
        {
            currentService = steamUserManager;
        }
        else if(GooglePlay)
        {
            currentService = googleplayUserManager;
        }
        else
        {
            currentService = localUserManager;
        }

        return currentService;
    }

    public IRewardService GetRewardService()
    {
        if(Local)
        {
            currentReward = boxHouseMissions;
        }
        else if(Live)
        {
            currentReward = xboxAchievments;
        }
        else if(PSN)
        {
            currentReward = psnTrophies;
        }
        else if(Steam)
        {
            currentReward = steamAchievments;
        }
        else if(GooglePlay)
        {
            currentReward = googlePlayAchievments;
        }
        else
        {
            currentReward = boxHouseMissions;
        }

        return currentReward;
    }
}
