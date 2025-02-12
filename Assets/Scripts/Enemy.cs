using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private HitManager _hitManager;
    // Start is called before the first frame update
    private void Start()
    {
        _hitManager =  GameObject.Find("EnemyManager").GetComponent<HitManager>();
    }

    private void Update()
    {
        this.transform.position-=new Vector3(0f,0f,_moveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        _hitManager .Hit(this.gameObject.transform.rotation);
    }
}
