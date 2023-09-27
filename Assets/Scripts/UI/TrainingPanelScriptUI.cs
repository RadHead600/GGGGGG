using UnityEngine;

public class TrainingPanelScriptUI : MonoBehaviour
{
    [SerializeField] private TextTranslator _textKey;

    private void Start()
    {
        if (StartGameController.Instance != null)
        {
           StartGameController.Instance.OnStartGame += ClosePanel;
           if (PlayerPrefs.HasKey(_textKey.key))
           {
            gameObject.SetActive(false);
           }
        }
    }

    public void SaveIsClosedPanel()
    {
        private int savedValue = 1;
    
        PlayerPrefs.SetInt(_textKey.key, savedValue);
    }

    private void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
       if (StartGameController.Instance != null)
       {
          StartGameController.Instance.OnStartGame -= ClosePanel;
       }
    }
}
