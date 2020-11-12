using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodVelocityDecay : MonoBehaviour
{
    /// <summary>
    /// The period that the pod will be allowed to continue
    /// at its current velocity before being decelerated.
    /// </summary>
    [SerializeField]
    private float delayPeriod = 1.5f;

    /// <summary>
    /// The period over which the pod will be decelerated
    /// when not being pulled by a well.
    /// </summary>
    [SerializeField]
    private float decelarationPeriod = 0.75f;

    /// <summary>
    /// The speed that the pod will drift at after decelerating
    /// </summary>
    [SerializeField]
    private float finalSpeed = 1.0f;

    private PodInformation podInformation;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        podInformation = PodInformation.Instance;

        podInformation.OnStopPulling += StartSlowPodOverPeriod;
    }

    private void StartSlowPodOverPeriod(Transform podTransform)
    {
        var initialVelocity = rb.velocity;
        // Only slow the pod if it's moving faster than the decay target
        if (rb.velocity.magnitude > finalSpeed)
        {
            var targetVelocity = rb.velocity.normalized * finalSpeed;

            var slowStartTime = Time.fixedTime;

            StartCoroutine(SlowPodOverPeriod(initialVelocity, targetVelocity, slowStartTime));
        }
    }

    private IEnumerator SlowPodOverPeriod(Vector3 initialVelocity, Vector3 targetVelocity, float slowStartTime)
    {
        yield return new WaitForSecondsRealtime(delayPeriod);

        while (rb.velocity.magnitude - targetVelocity.magnitude >= 0.05f)
        {
            rb.velocity = Vector3.Lerp(initialVelocity, targetVelocity, (Time.fixedTime - slowStartTime) / decelarationPeriod);

            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }
}
