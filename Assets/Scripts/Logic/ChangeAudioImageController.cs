using UnityEngine;
using UnityEngine.UI;

public class ChangeAudioImageController : MonoBehaviour
{
    [SerializeField] private Sprite _onAudioSprite;
    [SerializeField] private Sprite _offAudioSprite;

    private bool _isOnAudio;

    private void Start()
    {
        _isOnAudio = true;
    }

    public void UpdateSprite(Image image)
    {
        _isOnAudio = !_isOnAudio;
        image.sprite = (_isOnAudio) ? _onAudioSprite : _offAudioSprite;
    }
}
