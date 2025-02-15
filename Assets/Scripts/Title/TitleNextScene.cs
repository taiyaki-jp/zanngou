using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TitleNextScene : MonoBehaviour
{
    [SerializeField]private Button _nextButton;
    private FusumaFadeManager _fadeManager;
    private SoundPlayer _audioSource;
    private bool _isPressed = false;
    void Start()
    {
        _fadeManager = GameObject.Find("SingletonCanvas").GetComponent<FusumaFadeManager>();
        _isPressed = false;
        _nextButton.onClick.AddListener(NextScene);
        _audioSource = GameObject.Find("SoundSingleton").GetComponent<SoundPlayer>();
    }

    private async void NextScene()
    {
        if (_isPressed)return;
        _isPressed = true;
        _audioSource.PlaySound(SoundEnum.ClickLong,true);
        await UniTask.Delay(TimeSpan.FromSeconds(1.5));
        _ = _fadeManager.Fade("ModeSerect");
    }
}
