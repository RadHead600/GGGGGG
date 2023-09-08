using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ChangeLanguageController : Singleton<ChangeLanguageController>
{
    [DllImport("__Internal")]
    private static extern string GetLang();

    public void SetLang()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        string lang = GetLang();
        if (lang == "ru")
        {
            LangsList.SetLanguage(0);
            return;
        }
        if (lang == "en")
        {
            LangsList.SetLanguage(1);
            return;
        }
        if (lang == "tr")
        {
            LangsList.SetLanguage(2);
            return;
        }
#elif UNITY_2020_1_OR_NEWER
        if (Application.systemLanguage == SystemLanguage.Russian)
            LangsList.SetLanguage(0);
        if (Application.systemLanguage == SystemLanguage.English)
            LangsList.SetLanguage(1);
        if (Application.systemLanguage == SystemLanguage.Turkish)
            LangsList.SetLanguage(2);
#endif
    }

    public void ChangeLang (TMP_Dropdown tmp)
    {
        LangsList.SetLanguage(tmp.value, true);
    }
}
