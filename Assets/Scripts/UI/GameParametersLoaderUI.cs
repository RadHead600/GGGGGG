using UnityEngine;
using UnityEngine.UI;

public class GameParametersLoaderUI : Singleton<GameParametersLoaderUI>
{
    private const int LoaderActiveState = 1;
    private const int LoaderInactiveState = 0;
    
    [SerializeField] private Image _loaderImage;
    
    private int _stackLoader;

    public void Loading(bool isLoad)
    {
        _loaderImage.gameObject.SetActive(isLoad);
    }

    public void AddStack()
    {
        _stackLoader += LoaderActiveState;
        Loading(true);
    }

    public void TakeStack()
    {
        if (_stackLoader > LoaderInactiveState)
            _stackLoader -= LoaderActiveState;
        if (_stackLoader == LoaderInactiveState)
            Loading(false);
    }
}
