using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    private FusumaFadeManager _fadeManager;
    private SoundPlayer _audioSource;
    [SerializeField]private List<GameObject> _moveUI = new();
    [SerializeField]private float _moveDistance;
    [SerializeField]private List<GameObject> _portUI = new();
    [SerializeField]private List<Button> _buttons = new();
    private GameObject _nowPortUI = null;
    private bool _isPressed = false;
    void Start()
    {
        _fadeManager = GameObject.Find("SingletonCanvas").GetComponent<FusumaFadeManager>();
        _isPressed = false;
        _audioSource = GameObject.Find("SoundSingleton").GetComponent<SoundPlayer>();

        foreach (var ui in _portUI)
        {
            ui.SetActive(false);
        }
        _buttons[0].onClick.AddListener(NextScene);
        _buttons[1].onClick.AddListener(ToPort);
        _buttons[2].onClick.AddListener(()=>PortForioChenge(0));
        _buttons[3].onClick.AddListener(()=>PortForioChenge(1));
        _buttons[4].onClick.AddListener(()=>PortForioChenge(2));
        _buttons[5].onClick.AddListener(ToGame);
    }

    private async void NextScene()
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
    private void PortForioChenge(int num)
    {
        if(_nowPortUI != null)_nowPortUI.SetActive(false);
        _nowPortUI = _portUI[num];
        _nowPortUI.SetActive(true);
    }

    private async void ToGame()
    {
        if (_nowPortUI != null)
        {
            _nowPortUI.SetActive(false);
            _nowPortUI = null;
        }
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }

        await UIMove(+1);

        _buttons[0].interactable = true;
        _buttons[1].interactable = true;
    }

    private async void ToPort()
    {
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }

        await UIMove(-1);

        for (int i = 2; i <= 5; i++)
        {
            _buttons[i].interactable = true;
        }
    }

    private async UniTask UIMove(int mul)
    {
        List<Vector3> moveUIStartPos = new List<Vector3>();
        foreach (var ui in _moveUI)
        {
            moveUIStartPos.Add(ui.transform.position);
        }
        var t = 0f;
        while (t<1)
        {
            for (int i = 0; i < _moveUI.Count; i++)
            {
                _moveUI[i].transform.position = Vector3.Lerp(moveUIStartPos[i], new Vector3(moveUIStartPos[i].x,moveUIStartPos[i].y+(_moveDistance*mul),moveUIStartPos[i].z), t);
            }
            t+=Time.deltaTime;
            await UniTask.Yield();
        }
        for (int i = 0; i < _moveUI.Count; i++)
        {
            _moveUI[i].transform.position = new Vector3(moveUIStartPos[i].x,moveUIStartPos[i].y+(_moveDistance*mul),moveUIStartPos[i].z);
        }
        moveUIStartPos.Clear();
    }
}
