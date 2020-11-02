using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour
{
    /// <summary>
    /// Coefficient to multiply push force by.
    /// </summary>
    [SerializeField]
    private float pushCoefficient;

    private Rigidbody podRb;

    private void OnTriggerEnter(Collider other)
    {
        podRb = other.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (podRb != null)
        {
            var direction = podRb.velocity * -1;
            var distance = Vector3.Distance(transform.position, podRb.transform.position);

            var force = (direction.normalized * pushCoefficient) / distance;

            podRb.AddForce(force);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        podRb = null;
    }
}
