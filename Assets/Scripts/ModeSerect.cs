using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModeSerect : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private List<GameObject> _difficulties;

    private MainGameVariables _variables;
    private FusumaFadeManager _fadeManager;
    private SoundPlayer _soundPlayer;
    private bool _isPressed=false;
    private GameObject nowUI = null;

    private void Start()
    {
        _fadeManager = GameObject.Find("SingletonCanvas").GetComponent<FusumaFadeManager>();
        _variables = GameObject.Find("SingletonCanvas").GetComponent<MainGameVariables>();
        _soundPlayer = GameObject.Find("SoundSingleton").GetComponent<SoundPlayer>();
        _buttons[0].onClick.AddListener(()=>ButtonGeneric(0));
        _buttons[1].onClick.AddListener(()=>ButtonGeneric(1));
        _buttons[2].onClick.AddListener(()=>ButtonGeneric(2));
        _buttons[3].onClick.AddListener(()=>ButtonGeneric(3));
        _buttons[4].onClick.AddListener(()=>ButtonGeneric(4));
        _isPressed = false;
    }
    private async void ButtonGeneric(int lv)
    {
        if (_isPressed)return;
        _isPressed = true;
        _soundPlayer.PlaySound(SoundEnum.ClickShort);
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }
        await UniTask.Delay(TimeSpan.FromSeconds(1));

        _variables.NowDiffculty = lv;

        _ = _soundPlayer.ChangeBGM();
        _ = _fadeManager.Fade("Main");
    }

    private void ChengeUI(string buttonName ="")
    {
        if(nowUI != null)nowUI.gameObject.SetActive(false);
        switch (buttonName)
        {
            case "Easy":
                nowUI = _difficulties[0];
                break;
            case "Normal":
                nowUI = _difficulties[1];
                break;
            case "Hard":
                nowUI = _difficulties[2];
                break;
            case "Nightmare":
                nowUI = _difficulties[3];
                break;
            case "Inferno":
                nowUI = _difficulties[4];
                break;
            default:
                nowUI = null;
                break;
        }
        if (nowUI != null) nowUI.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChengeUI(eventData.pointerEnter.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ChengeUI();
    }
}
