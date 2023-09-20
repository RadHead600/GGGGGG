using System.Collections.Generic;
using TMPro;
using UnityEngine;


[CreateAssetMenu(fileName = "Translates", menuName = "YagirLib/Translates", order = 1)]
public class LangListObjects : ScriptableObject
{
    public List<string> languages = new List<string>();
    public List<TMP_FontAsset> fonts = new List<TMP_FontAsset>();
    public List<WordKey> words = new List<WordKey>();
}
