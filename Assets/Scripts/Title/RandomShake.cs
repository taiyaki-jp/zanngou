using System.Collections.Generic;
using UnityEngine;


public class RandomShake : MonoBehaviour
{
    [SerializeField] private List<Transform> _pos = new();

    public float _shakePower;
    // 開始時の位置
    private readonly List<Vector3> _initPos = new();

    private void Start ()
    {
        foreach (Transform pos in _pos)
        {
            _initPos.Add(pos.position);
        }
    }


    private void Update ()
    {
        // ランダムに揺らす
        for(int i=0;i<_pos.Count;i++)
        {
            _pos[i].position = _initPos[i] + Random.insideUnitSphere * _shakePower;
        }
    }
}
