using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField]private Image _brackOut;
    private FusumaFadeManager _fadeManager;
    private SoundPlayer _soundPlayer;
    private MainGameVariables _variables;
    private EnemySpawn _spawn;

    private static String[] _countDown = new[] { "参", "弐", "壱", "始め!" };
    private void Start()
    {
        _fadeManager = GameObject.Find("SingletonCanvas").GetComponent<FusumaFadeManager>();
        _soundPlayer = GameObject.Find("SoundSingleton").GetComponent<SoundPlayer>();
        _variables = GameObject.Find("SingletonCanvas").GetComponent<MainGameVariables>();
        _spawn = this.GetComponent<EnemySpawn>();

        if (_variables.NowDiffculty==4)_variables.HP = 1;
        else _variables.HP = 3;
        _variables.BlockCount = 0;
        _variables.Missed = false;
        _brackOut.color = new Color(0f, 0f, 0f, 0f);

        StartCount();
    }

    private async void StartCount()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        for (int i = 0; i < _countDown.Length; i++)
        {
            _text.text = _countDown[i];
            if (i == 3) _soundPlayer.PlaySound(SoundEnum.Wadaiko2);
            else _soundPlayer.PlaySound(SoundEnum.Wadaiko1);
            await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: this.GetCancellationTokenOnDestroy());
        }
        _text.gameObject.transform.parent.gameObject.SetActive(false);
        _soundPlayer.NewBGM(SoundEnum.GameBGM);
        await _spawn.Spawn(this.GetCancellationTokenOnDestroy());
        if(_variables.Missed)return;
        await UniTask.Delay(TimeSpan.FromSeconds(5), cancellationToken: this.GetCancellationTokenOnDestroy());
        _ = Gameend();
    }

    public void GameOver()
    {
        _variables.Missed = true;
        if (_variables.NowDiffculty == 4)_brackOut.color = new Color(1f, 0f, 0f, 0f);
        _ = BrackOut();
        _ = Gameend();
    }

    private async UniTaskVoid BrackOut()
    {
        var t = 0f;
        while (t<1f)
        {
            _brackOut.color = new Color(_brackOut.color.r,_brackOut.color.g,_brackOut.color.b,t);
            t += Time.deltaTime;
            await UniTask.Yield();
        }
    }

    private async UniTaskVoid Gameend()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        _ = _soundPlayer.ChangeBGM();
        _ = _fadeManager.Fade("Result");
    }
}
