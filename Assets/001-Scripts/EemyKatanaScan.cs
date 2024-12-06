using UnityEngine;

public class EemyKatanaScan : MonoBehaviour
{
    void Update()
    {
        // trQ → v3Angle
        float EnemyAngleZ = transform.eulerAngles.z; // z軸の回転量
                                                  // 実質、オブジェクトの向いている角度になります。
    }
}
