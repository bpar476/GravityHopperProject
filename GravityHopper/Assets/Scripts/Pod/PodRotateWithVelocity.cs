using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodRotateWithVelocity : MonoBehaviour
{

    /// <summary>
    /// Factor affecting how much the pod rotates
    /// in relation to its velocity.
    /// </summary>
    [SerializeField]
    private float angularVelocityCoefficient;

    private Vector3 currentKnownVelocity;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity != currentKnownVelocity)
        {
            UpdateAngularVelocityAroundMovement();
            currentKnownVelocity = rb.velocity;
        }
    }

    private void UpdateAngularVelocityNaive()
    {
        rb.angularVelocity = new Vector3(rb.velocity.magnitude * angularVelocityCoefficient, 0, 0);
    }

    private void UpdateAngularVelocityAroundMovement()
    {
        rb.AddTorque(rb.velocity.normalized * 0.1f);
    }
}
