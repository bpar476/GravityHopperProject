using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodOrientation : MonoBehaviour
{

    /// <summary>
    /// The magnitude of the corrective torque applied
    /// to the pod when turning
    /// </summary>
    [SerializeField]
    private float turnSpeed = 100;

    private Vector3 currentTorque = new Vector3(0, 0, 0);

    private Rigidbody rb;

    private float angleBetweenOrientationAndVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude >= 0.1f)
        {
            if (!OrientationAlignsWithVelocity())
            {
                if (!OrientationBeingCorrected())
                {
                    ApplyCorrectiveTorque();
                }
            }
            else
            {
                if (OrientationBeingCorrected())
                {
                    NegateCurrentTorque();

                    ResetCurrentTorque();
                }
            }
        }
    }

    private bool OrientationAlignsWithVelocity()
    {
        angleBetweenOrientationAndVelocity = Vector3.SignedAngle(rb.velocity, rb.transform.up, Vector3.forward);
        return Mathf.Abs(angleBetweenOrientationAndVelocity) < 5f;
    }

    private bool OrientationBeingCorrected()
    {
        return currentTorque.magnitude > 0.05f;
    }

    private void ApplyCorrectiveTorque()
    {
        float normalXComponent = 0;
        float normalZComponent = -1 * Mathf.Sign(angleBetweenOrientationAndVelocity);

        float normalYComponent = (rb.velocity.z * normalZComponent) / rb.velocity.y;

        Vector3 correctiveTorque = new Vector3(normalXComponent, normalYComponent, normalZComponent);
        Vector3 scaledCorrectiveTorque = correctiveTorque * turnSpeed;

        rb.AddTorque(scaledCorrectiveTorque);

        currentTorque = scaledCorrectiveTorque;
    }

    private void NegateCurrentTorque()
    {
        rb.AddTorque(-1 * currentTorque);
    }

    private void ResetCurrentTorque()
    {
        currentTorque = new Vector3(0, 0, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 3f);
    }
}
