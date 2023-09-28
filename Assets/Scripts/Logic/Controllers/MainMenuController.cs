using System.Runtime.InteropServices;
using UnityEngine;

public class MainMenuController : Singleton<MainMenuController>
{
    [SerializeField] private GameObject _mainMenuCanvas;

    [DllImport("__Internal")]
    public static extern bool InitPlayer();

    private static bool isStarted;
    public static bool isOnline;

    private void Start()
    {
        if (isStarted)
        {
            if (isOnline)
            {
                StartOnlineSession();
            }
            else
            {
                StartGuestSession();
            }
            _mainMenuCanvas.SetActive(false);
        }
    }

    public void StartOnlineSession()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
        
        if (InitPlayer()){
            GameInformation.LoadExtern();
            
            GameInformation.OnInformationChange += GameInformation.Instance.Save;
            isStarted = true;
            isOnline = true;
            _mainMenuCanvas.SetActive(false);
        }
        
        #endif
    }

    public void StartGuestSession()
    {
        if (!PlayerPrefs.HasKey("information"))
        {
            GameInformation.Instance.SetInformationFromJSON(JsonUtility.ToJson(new Information()));
            GameInformation.Instance.Save();
        }
        
        GameInformation.Instance.SetInformationFromJSON(PlayerPrefs.GetString("information"));
        GameInformation.OnInformationChange += GameInformation.Instance.Save;
        isStarted = true;
        _mainMenuCanvas.SetActive(false);
    }
}
