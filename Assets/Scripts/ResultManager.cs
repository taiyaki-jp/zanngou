using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ResultManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreTextInt;
    [FormerlySerializedAs("_ScoreTextStr")] [SerializeField] TextMeshProUGUI _scoreTextStr;
    [SerializeField] private GameObject _buttons;
    private static String[] _sihanVoice= new string[]
    {
        "まだまだ精進が必要だ",
        "コツを掴んできたようだな",
        "あとは回数を重ねるのみ",
        "合格だ",
        "命があるだけ奇跡と思え"
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

        if (_variables.NowDiffculty == 4)
            if(_variables.BlockCount != 0) _scoreTextStr.text=$"{_variables.BlockCount}人抜き　見事";
            else
            {
                sihanVoice = 4;
                _scoreTextStr.text = _sihanVoice[sihanVoice];
            }
        else
        {
            switch (_variables.BlockCount)
            { case < 50:
                    sihanVoice = 0;
                    break;
                case < 75:
                    sihanVoice = 1;
                    break;
                case < 90:
                    sihanVoice = 2;
                    break;
                case < 100:
                    sihanVoice = 3;
                    break;
            }
            _scoreTextStr.text = _sihanVoice[sihanVoice];
        }

        _buttons.SetActive(true);
    }
}
