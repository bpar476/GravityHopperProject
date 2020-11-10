using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodOrientation : MonoBehaviour
{

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity);
            // transform.LookAt()
            // transform.rotation.SetLookRotation(transform.forward, Vector3.up);
            // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationOffset);
        }
    }
}
