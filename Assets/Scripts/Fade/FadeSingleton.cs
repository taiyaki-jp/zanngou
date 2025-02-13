using UnityEngine;

public class FadeSingleton : MonoBehaviour
{
    private static FadeSingleton _instanceClosed;
    private static GameObject[] _fusuma = new GameObject[2];
    private static GameObject[] _cFusumas = new GameObject[4];


    private void Awake()
    {
        //もしすでに生成されていれば
        if (_instanceClosed != null && _instanceClosed != this)
        {
            Destroy(this.gameObject);//自身を削除

        }
        else//これがないとDestroyしたあと初期化され直す
        {

            //staticに自身を入れる
            _instanceClosed = this;
            DontDestroyOnLoad(this.gameObject);//それをシーンを跨ぐ様にする

            //↓初期化処理
            _fusuma[0] = GameObject.Find("FusumaR");
            _fusuma[1] = GameObject.Find("FusumaL");
            _cFusumas[0] = GameObject.Find("FusumaRU");
            _cFusumas[1] = GameObject.Find("FusumaRD");
            _cFusumas[2] = GameObject.Find("FusumaLU");
            _cFusumas[3] = GameObject.Find("FusumaLD");
        }
    }
    private FadeSingleton() { }//外部からの生成をブロック

    public static GameObject[] Fusuma=>_fusuma;
    public static GameObject[] ChildFusuma => _cFusumas;
}
