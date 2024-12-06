using UnityEngine;

public class ObjectAddForce : MonoBehaviour
{
    void Start()
    {
        // ‰“‚­‚É”ò‚Î‚·
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0.0f, 0.0f, -5.0f);
        rb.AddForce(force, ForceMode.Impulse);
    }
}