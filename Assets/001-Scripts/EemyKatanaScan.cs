using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EemyKatanaScan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // trQ → v3Angle
        float EnemyAngleZ = transform.eulerAngles.z; // z軸の回転量
                                                  // 実質、オブジェクトの向いている角度になります。
    }
}
