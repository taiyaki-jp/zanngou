using UnityEngine;

public class FusumaFadeManager : MonoBehaviour
{
    private FusumaFadeLogic _logic;
    private async void Start()
    {
        _logic = new FusumaFadeLogic();
        if (FadeSingleton.IsFirst)
        {
            FadeSingleton.IsFirst = false;
            for (int i = 0; i < 4; i++)
            {
                Debug.Log(FadeSingleton.ChildFusuma[i].transform.position);
            }
        }
        await _logic.FadeIn();
        _ = _logic.FadeOut();
    }
}
