using UnityEngine;

/// <summary>
/// ターゲットに振り向くスクリプト（オフセット考慮版）
/// </summary>
public class PlayerKatanaRotation : MonoBehaviour
{
    // 自身のTransform
    private Transform self;

    // ターゲットのTransform
    private Transform target;

    // 前方の基準となるローカル空間ベクトル
    [SerializeField] private Vector3 forward = Vector3.forward;

    private void Start()
    {
        self = this.transform;
        target=GameObject.Find("PrayerMouse").GetComponent<Transform>();
    }

    private void Update()
    {
        // ターゲットへの向きベクトル計算
        var dir = target.position - self.position;

        // ターゲットの方向への回転
        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
        // 回転補正
        var offsetRotation = Quaternion.FromToRotation(forward, Vector3.forward);

        // 回転補正→ターゲット方向への回転の順に、自身の向きを操作する
        self.rotation = lookAtRotation * offsetRotation;
    }
}