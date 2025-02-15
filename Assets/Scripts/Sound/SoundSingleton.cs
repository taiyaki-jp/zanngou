using UnityEngine;

public class SoundSingleton : MonoBehaviour
{
    private static SoundSingleton _instanceClosed;

    private static AudioSource _audioSourceBGM;
    private static AudioSource _audioSourceSE;

    private static bool _isFirst=true;
    private void Awake()
    {
        //もしすでに生成されていれば
        if (_instanceClosed != null && _instanceClosed != this)
        {
            Destroy(this.gameObject);//自身を削除

        }
        else//これがないとDestroyしたあと初期化され直す
        {

            //staticに自身を入れる
            _instanceClosed = this;
            DontDestroyOnLoad(this.gameObject);//それをシーンを跨ぐ様にする

            //↓初期化処理
            _audioSourceBGM = this.gameObject.AddComponent<AudioSource>();
            _audioSourceBGM.loop = true;
            _audioSourceSE  = this.gameObject.AddComponent<AudioSource>();
            _audioSourceSE.playOnAwake = false;
            _isFirst = true;
        }
    }
    private SoundSingleton(){}

    public static AudioSource AudioSourceBGM => _audioSourceBGM;

    public static AudioSource AudioSourceSE => _audioSourceSE;
    public static bool IsFirst{ get => _isFirst; set => _isFirst = value;}
}
