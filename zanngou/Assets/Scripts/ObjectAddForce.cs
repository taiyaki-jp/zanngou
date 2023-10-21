using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAddForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ‰“‚­‚É”ò‚Î‚·
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0.0f, 0.0f, -1.0f);
        rb.AddForce(force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}