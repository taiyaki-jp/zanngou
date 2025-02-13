using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private HitManager _hitManager;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        _hitManager =  GameObject.Find("EnemyManager").GetComponent<HitManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        this.transform.position-=new Vector3(0f,0f,_moveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();
        _hitManager .Hit(this.gameObject.transform.rotation);
        this.transform.position=new Vector3(0f,0f,10f);
        this.transform.rotation=Quaternion.Euler(Random.Range(0f,360f),90f,0f);
    }
}
