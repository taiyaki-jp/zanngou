using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
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
        _ = Gameend();
    }

    private async UniTaskVoid Gameend()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        _ = _soundPlayer.ChangeBGM();
        _ = _fadeManager.Fade("Result");
    }
}
