using UnityEngine;

/// <summary>
/// Pulls the pod to it when holding click
/// </summary>
public abstract class GravityWell : MonoBehaviour
{

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

    private bool isBeingClicked = false;

    private void OnMouseDown()
    {
        isBeingClicked = true;
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
            var rb = pod.GetComponent<Rigidbody>();

            Vector3 directionFromPodToWell = transform.position - pod.transform.position;
            float distance = Vector3.Distance(transform.position, pod.transform.position);

            movePodTowardsWell(rb, directionFromPodToWell, distance);

            rb.velocity = rb.velocity.normalized * clampVelocityComponent(rb.velocity.magnitude);
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
        return Mathf.Clamp(velocityComponent, velocityComponent, velocityClamp);
    }
}
