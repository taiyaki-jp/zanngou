using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private HitManager _hitManager;
    private MainGameVariables _variables;
    // Start is called before the first frame update
    private void Start()
    {
        _hitManager =  GameObject.Find("Manager").GetComponent<HitManager>();
        _variables = GameObject.Find("SingletonCanvas").GetComponent<MainGameVariables>();
        _moveSpeed = _variables.DiffcultySpeed;
    }

    private void Update()
    {
        if(_variables.Missed)return;
        this.transform.position-=new Vector3(0f,0f,_moveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        _hitManager .Hit(this.gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
