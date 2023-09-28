using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ChangeLanguageController : Singleton<ChangeLanguageController>
{
    private const int RussianLanguageIndex = 0;
    private const int EnglishLanguageIndex = 1;
    private const int TurkishLanguageIndex = 2;
    
    [DllImport("__Internal")]
    private static extern string GetLang();

    public void SetLanguage()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
        
        string lang = GetLang();
        
        if (lang == "ru")
        {
            LangsList.SetLanguage(RussianLanguageIndex, true);
            return;
        }
        if (lang == "en")
        {
            LangsList.SetLanguage(EnglishLanguageIndex, true);
            return;
        }
        if (lang == "tr")
        {
            LangsList.SetLanguage(TurkishLanguageIndex, true);
            return;
        }
        
        #elif UNITY_2020_1_OR_NEWER
        
        if (Application.systemLanguage == SystemLanguage.Russian)
            LangsList.SetLanguage(RussianLanguageIndex, true);
        if (Application.systemLanguage == SystemLanguage.English)
            LangsList.SetLanguage(EnglishLanguageIndex, true);
        if (Application.systemLanguage == SystemLanguage.Turkish)
            LangsList.SetLanguage(TurkishLanguageIndex, true);
            
        #endif
    }

    public void ChangeLang (TMP_Dropdown tmp)
    {
        LangsList.SetLanguage(tmp.value, true);
    }
}
