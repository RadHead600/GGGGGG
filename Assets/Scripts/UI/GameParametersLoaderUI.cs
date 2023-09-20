using UnityEngine;
using UnityEngine.UI;

public class GameParametersLoaderUI : Singleton<GameParametersLoaderUI>
{
    [SerializeField] private Image _loaderImage;
    
    private int _stackLoader;

    public void Loading(bool isLoad)
    {
        _loaderImage.gameObject.SetActive(isLoad);
    }

    public void AddStack()
    {
        _stackLoader += 1;
        Loading(true);
    }

    public void TakeStack()
    {
        if (_stackLoader > 0)
            _stackLoader -= 1;
        if (_stackLoader == 0)
            Loading(false);
    }
}
