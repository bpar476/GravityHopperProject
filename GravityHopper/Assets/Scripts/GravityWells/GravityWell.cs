using UnityEngine;

/// <summary>
/// Pulls the pod to it when holding click
/// </summary>
public abstract class GravityWell : MonoBehaviour
{

    [SerializeField]
    private float wellRadius = 1.0f;

    [SerializeField]
    /// <summary>
    /// Value to multiply movement by when being pulled.
    /// </summary>
    protected float coefficient;

    [SerializeField]
    /// <summary>
    /// Value to clamp the velocity in any given direction to.
    /// </summary>
    private float velocityClamp;

    /// <summary>
    /// The time it takes for the pod to ramp up to its max velocity
    /// after being pulled by the well.
    /// </summary>
    [SerializeField]
    private float rampTime = 0.5f;

    private bool isBeingClicked = false;
    private float clickTime;

    private void OnMouseDown()
    {
        isBeingClicked = true;
        clickTime = Time.time;
    }

    private void OnMouseUp()
    {
        isBeingClicked = false;
    }

    private void Update()
    {
        if (isBeingClicked)
        {
            var pod = PodInformation.Instance;
            float distance = Vector3.Distance(transform.position, pod.transform.position);

            if (distance < wellRadius)
            {
                var rb = pod.GetComponent<Rigidbody>();

                Vector3 directionFromPodToWell = transform.position - pod.transform.position;

                movePodTowardsWell(rb, directionFromPodToWell, distance);

                rb.velocity = rb.velocity.normalized * clampVelocityComponent(rb.velocity.magnitude) - new Vector3();
            }
        }
    }

    /// <summary>
    /// Moves the pod towards the well using the distance and direction of the pod from the well
    /// </summary>
    /// <param name="podRb">The pod's rigid body</param>
    /// <param name="directionFromPod">The direction to the well from the pod</param>
    /// <param name="distance">The distance between the pod and the well</param>
    protected abstract void movePodTowardsWell(Rigidbody podRb, Vector3 directionFromPod, float distance);

    private float clampVelocityComponent(float velocityComponent)
    {
        return Mathf.Clamp(velocityComponent, velocityComponent, ((Time.time - clickTime) / rampTime) * velocityClamp);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, wellRadius);
    }
}
