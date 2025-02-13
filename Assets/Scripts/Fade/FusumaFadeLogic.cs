using Cysharp.Threading.Tasks;
using UnityEngine;

public class FusumaFadeLogic
{
    private static int[] CLOSED_POS = { 1440, 480 };
    private static int[] OPEN_POS = { 2340, -480 };

    private RectTransform rectTransform;

    public async UniTask FadeIn()
    {
        var t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;

            var Pos =new float[2];
            for (int i = 0; i < 2; i++)
            {
                Pos[i] = Mathf.Lerp(OPEN_POS[i], CLOSED_POS[i], t);
            }

            for (int i = 0; i < 2; i++)
            {
                FadeSingleton.Fusuma[i].transform.position=new Vector3(Pos[i],FadeSingleton.Fusuma[i].transform.position.y,FadeSingleton.Fusuma[i].transform.position.z);
            }
            await UniTask.Yield();
        }
    }

    public async UniTask FadeOut()
    {
        var t = 0f;


        var fusumas = new Rigidbody2D[4];
        for (int i = 0; i < 4; i++)
        {
            fusumas[i] = FadeSingleton.ChildFusuma[i].GetComponent<Rigidbody2D>();
        }

        var vel = new Vector2[]
        {
            new (Random.Range(-7f,-3f), 2f),
            new (0f, -1f),
            new (Random.Range(-9f,-3f), 2f),
            new (0f, -1f),
        };

        for (int i = 0; i < 4; i++)
        {
            fusumas[i].velocity = vel[i]*100f;
            fusumas[i].gravityScale = 100f;
        }


        while (t<5f)
        {
            t += Time.deltaTime;
            await UniTask.Yield();
        }

        for (int i = 0; i < 2; i++)
        {
            FadeSingleton.Fusuma[i].transform.position= new Vector3(OPEN_POS[i],FadeSingleton.Fusuma[i].transform.position.y,FadeSingleton.Fusuma[i].transform.position.z);
        }

        for (int i = 0; i < 4; i++)
        {
            fusumas[i].gravityScale = 0f;
            fusumas[i].velocity = Vector2.zero;
        }
    }
}
