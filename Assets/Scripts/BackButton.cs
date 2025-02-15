using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;

    private MainGameVariables _gameVariables;
    private FusumaFadeManager _fadeManager;
    private SoundPlayer _soundPlayer;
    private bool _isPressed=false;
    // Start is called before the first frame update
    private void Start()
    {
        _fadeManager = GameObject.Find("SingletonCanvas").GetComponent<FusumaFadeManager>();
        _gameVariables = GameObject.Find("SingletonCanvas").GetComponent<MainGameVariables>();
        _soundPlayer = GameObject.Find("SoundSingleton").GetComponent<SoundPlayer>();
        _buttons[0].onClick.AddListener(()=>ButtonGeneric("Main"));
        _buttons[1].onClick.AddListener(()=>ButtonGeneric("ModeSerect"));
        _buttons[2].onClick.AddListener(()=>ButtonGeneric("Title"));
        _isPressed = false;
    }

    private async void ButtonGeneric(string scene)
    {
        if (_isPressed)return;
        _isPressed = true;
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
        _soundPlayer.PlaySound(SoundEnum.ClickShort);
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        _ = _fadeManager.Fade(scene);
    }
}
