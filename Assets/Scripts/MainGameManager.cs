using UnityEngine;
//singletonでいろいろな変数を保持するためだけのもの
public class MainGameManager : MonoBehaviour
{
    [SerializeField] private int  [] _diffcultyAngle = new int   [] {35,30,25,15,5};
    [SerializeField] private float[] _diffcultySpeed = new float [] {5f,4f,3f,2.5f,1f};

    public int DiffcultyAngle => _diffcultyAngle[NowDiffculty];
    public float DiffcultySpeed => _diffcultySpeed[NowDiffculty];
    public int NowDiffculty { get; set; } = 0;
    public int HP { get; set; } = 3;
    public int BlockCount { get; set; } = 0;
}
