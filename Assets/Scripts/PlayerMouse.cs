using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    void Update()
    {
        // カーソル位置を取得
        Vector3 mousePosition = Input.mousePosition;
        // カーソル位置のz座標を固定
        mousePosition.z = 10;
        // カーソル位置をワールド座標に変換
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
        // GameObjectのtransform.positionにカーソル位置(ワールド座標)を代入
        transform.position = target;
    }
}