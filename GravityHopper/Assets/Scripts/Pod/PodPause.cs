using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodPause : MonoBehaviour
{
    private Vector3 storedVelocity;
    private Vector3 storedAngularVelocity;

    private void Start()
    {
        var rb = GetComponent<Rigidbody>();

        PauseManager.Instance.OnPause += () =>
        {
            storedVelocity = rb.velocity;
            storedAngularVelocity = rb.angularVelocity;
            rb.isKinematic = true;
        };

        PauseManager.Instance.OnResume += () =>
        {
            rb.isKinematic = false;
            rb.velocity = storedVelocity;
            rb.angularVelocity = storedAngularVelocity;
        };
    }
}
