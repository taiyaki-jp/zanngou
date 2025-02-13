
using UnityEngine;
using UnityEngine.UI;

public class ModeSerect : MonoBehaviour
{
    [SerializeField] private Button _lv1;
    [SerializeField] private Button _lv2;
    [SerializeField] private Button _lv3;
    [SerializeField] private Button _lv4;
    [SerializeField] private Button _lv5;

    private MainGameManager _gameManager;
    private FusumaFadeManager _fadeManager;

    private void Start()
    {
        _fadeManager = GameObject.Find("SingletonCanvas").GetComponent<FusumaFadeManager>();
        _gameManager = GameObject.Find("SingletonCanvas").GetComponent<MainGameManager>();
        _lv1.onClick.AddListener(GameStartLv1);
        _lv2.onClick.AddListener(GameStartLv2);
        _lv3.onClick.AddListener(GameStartLv3);
        _lv4.onClick.AddListener(GameStartLv4);
        _lv5.onClick.AddListener(GameStartLv5);
    }

    private void GameStartLv1()
    {
        _gameManager.NowDiffculty = 0;
        _gameManager.HP = 3;
        _ = _fadeManager.Fade("Main");
    }
    private void GameStartLv2()
    {
        _gameManager.NowDiffculty = 1;
        _gameManager.HP = 3;
        _ = _fadeManager.Fade("Main");
    }
    private void GameStartLv3()
    {
        _gameManager.NowDiffculty = 2;
        _gameManager.HP = 3;
        _ = _fadeManager.Fade("Main");
    }
    private void GameStartLv4()
    {
        _gameManager.NowDiffculty = 3;
        _gameManager.HP = 3;
        _ = _fadeManager.Fade("Main");
    }
    private void GameStartLv5()
    {
        _gameManager.NowDiffculty = 4;
        _gameManager.HP = 1;
        _ = _fadeManager.Fade("Main");
    }
}
