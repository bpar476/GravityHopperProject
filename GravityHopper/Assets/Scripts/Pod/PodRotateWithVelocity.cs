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

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAngularVelocity();
    }

    private void UpdateAngularVelocity()
    {
        rb.angularVelocity = new Vector3(rb.velocity.magnitude * angularVelocityCoefficient, 0, 0);
    }
}
