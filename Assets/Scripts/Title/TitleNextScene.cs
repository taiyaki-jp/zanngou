using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TitleNextScene : MonoBehaviour
{
    private FusumaFadeManager _fadeManager;
    private AudioSource _audioSource;
    [SerializeField]private Button _nextButton;
    private bool _isPressed = false;
    void Start()
    {
        _fadeManager = GameObject.Find("SingletonCanvas").GetComponent<FusumaFadeManager>();
        _isPressed = false;
        _nextButton.onClick.AddListener(NextScene);
        _audioSource = GetComponent<AudioSource>();
    }

    private async void NextScene()
    {
        if (_isPressed)return;
        _isPressed = true;
        _audioSource.Play();
        await UniTask.WaitUntil(() => _audioSource.isPlaying==false,cancellationToken:this.GetCancellationTokenOnDestroy());
        _ = _fadeManager.Fade("ModeSerect");
    }
}
