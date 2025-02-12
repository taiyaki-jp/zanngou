using UnityEngine;

public class Enemy : MonoBehaviour
{
    private HitManager _hitManager;
    // Start is called before the first frame update
    private void Start()
    {
        _hitManager =  GameObject.Find("Manager").GetComponent<HitManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _hitManager .Hit(this.gameObject.transform.rotation);
    }
}
