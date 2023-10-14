using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KatanaScan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // trQ → v3Angle
        float PlayerAngleZ = transform.eulerAngles.z; // z軸の回転量
                                                  // 実質、オブジェクトの向いている角度になります。
        
    }
}