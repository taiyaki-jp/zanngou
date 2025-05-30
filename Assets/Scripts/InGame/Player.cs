using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 自身のTransform
    private Transform _self;
    // ターゲットのTransform
    [SerializeField] private Transform _target;
    //[SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _self = this.transform;
    }

    private void Update()
    {
        // ターゲットへの向きベクトル計算
        var dir = _target.position - _self.position;

        // ターゲットの方向への回転
        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
        // 回転補正
        var offsetRotation = Quaternion.FromToRotation(Vector3.up, Vector3.forward);

        // 回転補正→ターゲット方向への回転の順に、自身の向きを操作する
        _self.rotation = lookAtRotation * offsetRotation;

        //_text.text = _self.rotation.eulerAngles.ToString();
        //これで出る数値のxは上下が0、左右が90　つまりx同士を足して90の時、yが同じなら並行、違えば直角に交わっていることになる　zは上下反転しているかどうかで関係ない
    }
}
