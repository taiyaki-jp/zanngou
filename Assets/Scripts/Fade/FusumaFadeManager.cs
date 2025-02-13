using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FusumaFadeManager : MonoBehaviour
{
    private FusumaFadeLogic _logic;
    private void Start()
    {
        _logic = new FusumaFadeLogic();
    }

    public async UniTask Fade(string sceneName)
    {
        await _logic.FadeIn();
        await UniTask.Delay(100,cancellationToken:this.GetCancellationTokenOnDestroy());
        await SceneManager.LoadSceneAsync(sceneName);
        await UniTask.Delay(100,cancellationToken:this.GetCancellationTokenOnDestroy());
        _ = _logic.FadeOut();
    }
}
