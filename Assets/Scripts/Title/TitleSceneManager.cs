using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    private FusumaFadeManager _fadeManager;
    private SoundPlayer _audioSource;
    [SerializeField]private float _moveDistance;
    [SerializeField]private List<Button> _buttons = new();
    private bool _isPressed = false;
    void Start()
    {
        _fadeManager = GameObject.Find("SingletonCanvas").GetComponent<FusumaFadeManager>();
        _isPressed = false;
        _audioSource = GameObject.Find("SoundSingleton").GetComponent<SoundPlayer>();

        _buttons[0].onClick.AddListener(() => _ = NextScene());
        _buttons[1].onClick.AddListener(() => _ = GameEnd());
    }

    private async UniTask NextScene()
    {
        if (_isPressed)return;
        _isPressed = true;
        _audioSource.PlaySound(SoundEnum.ClickLong,true);
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
        await UniTask.Delay(TimeSpan.FromSeconds(1.5));
        _ = _fadeManager.Fade("ModeSerect");
    }

    private async UniTask GameEnd()
    {
        _audioSource.PlaySound(SoundEnum.ClickShort,true);
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
        await UniTask.Delay(TimeSpan.FromSeconds(1.5));
        _ = _fadeManager.GameEnd();
    }
}
