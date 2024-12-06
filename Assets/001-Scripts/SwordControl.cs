using UnityEngine;

public class SwordControl : MonoBehaviour
{
    //ƒvƒŒƒnƒu
    public GameObject Sword;
    //•régég¸ô¤Î×ûì¡‚
    public float minTime = 0.3f;
    //•régég¸ô¤Î×ûĞó‚E
    public float maxTime = 2.5f;
    //”³Éú³É•régég¸E
    private float interval;
    //½Uß^•rég
    private float time = 0f;

    public float RotateMin = 0f;
    public float RotateMax = 360f;
    private void Start()
    {
        interval = GetRandomTime();
    }

    // Update is called once per frame

    private void Update()
    {
        //•régÓ‹œy
        time += Time.deltaTime;
        float z = Random.Range(RotateMin, RotateMax);

        //½Uß^•rég¤¬Éú³É•rég¤Ë¤Ê¤Ã¤¿¤È¤­(Éú³É•rég¤è¤Eó¤­¤¯¤Ê¤Ã¤¿¤È¤­)
        if (time > interval)
        {
            //¥¤¥ó¥¹¥¿¥ó¥¹»¯¤¹¤EÉú³É¤¹¤E
            GameObject NewSword = Instantiate(Sword);
            //Éú³É¤·¤¿”³¤Î×ù˜Ë¤ò›Q¶¨¤¹¤E
            NewSword.transform.position = new Vector3(0, 0, 5);
            NewSword.transform.Rotate(0, 0, z);
            time = -999999999999999999;
        }
    }

    //¥é¥ó¥À¥à¤Ê•rég¤òÉú³É¤¹¤EvÊı
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }
    
}
