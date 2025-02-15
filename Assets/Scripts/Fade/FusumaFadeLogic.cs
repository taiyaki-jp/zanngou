using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class FusumaFadeLogic
{
    private static int[] CLOSED_POS = { 1440, 480 };
    private static int[] OPEN_POS = { 2400, -480 };
    private SoundPlayer _soundPlayer;
    public SoundPlayer SoundPlayer {set => _soundPlayer = value; }
    public async UniTask FadeIn()
    {
        var t = 0f;
        _soundPlayer.PlaySound(SoundEnum.Fusuma);
        while (t < 1f)
        {
            t += Time.deltaTime;

            var pos =new float[2];
            for (var i = 0; i < 2; i++)
            {
                pos[i] = Mathf.Lerp(OPEN_POS[i], CLOSED_POS[i], t);
            }

            for (var i = 0; i < 2; i++)
            {
                FadeSingleton.Fusuma[i].transform.position=new Vector3(pos[i],FadeSingleton.Fusuma[i].transform.position.y,FadeSingleton.Fusuma[i].transform.position.z);
            }
            await UniTask.Yield();
        }
    }

    public async UniTask FadeOut()
    {
        var fusumas = new Rigidbody2D[4];
        var fusumaDefPos = new Vector3[4];
        for (var i = 0; i < 4; i++)
        {
            fusumas[i] = FadeSingleton.ChildFusuma[i].GetComponent<Rigidbody2D>();
            fusumaDefPos[i] = FadeSingleton.ChildFusuma[i].transform.localPosition;
        }

        var vel = new Vector2[]
        {
            new (Random.Range(-7f,-3f), 2f),
            new (0f, -1f),
            new (Random.Range(-9f,-3f), 2f),
            new (0f, -1f),
        };

        for (var i = 0; i < 4; i++)
        {
            fusumas[i].velocity = vel[i]*100f;
            fusumas[i].gravityScale = 100f;
        }
        _soundPlayer.PlaySound(SoundEnum.KatanaCut);

        await UniTask.Delay(TimeSpan.FromSeconds(3f));

        for (var i = 0; i < 2; i++)
        {
            FadeSingleton.Fusuma[i].transform.position= new Vector3(OPEN_POS[i],FadeSingleton.Fusuma[i].transform.position.y,FadeSingleton.Fusuma[i].transform.position.z);
        }

        for (var i = 0; i < 4; i++)
        {
            fusumas[i].gravityScale = 0f;
            fusumas[i].velocity = Vector2.zero;
            FadeSingleton.ChildFusuma[i].transform.localPosition = fusumaDefPos[i];
        }
    }
}
