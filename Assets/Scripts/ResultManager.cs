using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreTextInt;
    [SerializeField] TextMeshProUGUI _ScoreTextStr;
    [SerializeField] private GameObject _buttons;
    private static String[] _sihanVoice= new string[]
    {
        "まだまだ精進が必要だ",
        "コツを掴んできたようだな",
        "あとは回数を重ねるのみ",
        "合格だ"
    };

    private MainGameVariables _variables;
    private SoundPlayer _soundPlayer;

    private void Start()
    {
        _variables = GameObject.Find("SingletonCanvas").GetComponent<MainGameVariables>();
        _soundPlayer = GameObject.Find("SoundSingleton").GetComponent<SoundPlayer>();

        Result();
        _soundPlayer.NewBGM(SoundEnum.MainBGM);
    }

    private async void Result()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        _soundPlayer.PlaySound(SoundEnum.Wadaiko1);
        _scoreTextInt.text = $"{_variables.BlockCount} 回";
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        var sihanVoice = 0;
        switch (_variables.BlockCount)
        {
            case <50:
               sihanVoice = 0;
               break;
            case < 75:
                sihanVoice = 1;
                break;
            case < 85:
                sihanVoice = 2;
                break;
            case 100:
                sihanVoice = 3;
                break;
        }
        _ScoreTextStr.text = _sihanVoice[sihanVoice];
        _buttons.SetActive(true);
    }
}
