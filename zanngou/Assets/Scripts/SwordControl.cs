using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    //僾儗僴僽
    public GameObject Sword;
    //時間間隔の最小値
    public float minTime = 0.3f;
    //時間間隔の最大値
    public float maxTime = 2.5f;
    //敵生成時間間隔
    private float interval;
    //経過時間
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
        //時間計測
        time += Time.deltaTime;
        float z = Random.Range(RotateMin, RotateMax);

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (time > interval)
        {
            //インスタンス化する(生成する)
            GameObject NewSword = Instantiate(Sword);
            //生成した敵の座標を決定する
            NewSword.transform.position = new Vector3(0, 2, 5);
            NewSword.transform.Rotate(0, 0, z);
            time = -999999999999999999;
        }
    }

    //ランダムな時間を生成する関数
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }
    
}
