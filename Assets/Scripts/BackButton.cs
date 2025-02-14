using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;

    private MainGameManager _gameManager;
    private FusumaFadeManager _fadeManager;
    private bool _isPressed=false;
    // Start is called before the first frame update
    private void Start()
    {
        _fadeManager = GameObject.Find("SingletonCanvas").GetComponent<FusumaFadeManager>();
        _gameManager = GameObject.Find("SingletonCanvas").GetComponent<MainGameManager>();
        _buttons[0].onClick.AddListener(ReStart);
        _buttons[1].onClick.AddListener(BackToMenu);
        _buttons[2].onClick.AddListener(BackToTitle);
        _isPressed = false;
    }

    private void BackToTitle()
    {
        if (_isPressed)return;
        _isPressed = true;
        _ = _fadeManager.Fade("Title");
    }

    private void BackToMenu()
    {
        if (_isPressed)return;
        _isPressed = true;
        _ = _fadeManager.Fade("ModeSerect");
    }

    private void ReStart()
    {
        if (_isPressed)return;
        _isPressed = true;
        var lv=_gameManager.NowDiffculty ;
        if (lv==4)_gameManager.HP = 1;
        else _gameManager.HP = 3;
        _gameManager.BlockCount = 0;
        _ = _fadeManager.Fade("Main");
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
    }
}
