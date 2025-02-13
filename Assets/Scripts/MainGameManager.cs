using System;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    [SerializeField] private int  [] _diffcultyAngle = new int   [5] {35,30,25,15,5};
    [SerializeField] private float[] _diffcultySpeed = new float [5] {5f,4f,3f,2.5f,1f};

    private int _nowDiffculty = 0;
    private int _hp = 3;

    public int DiffcultyAngle=>_diffcultyAngle[_nowDiffculty];
    public float DiffcultySpeed => _diffcultySpeed[_nowDiffculty];
    public int NowDiffculty{ get => _nowDiffculty; set => _nowDiffculty = value; }
    public int HP { get => _hp; set => _hp = value; }
}
