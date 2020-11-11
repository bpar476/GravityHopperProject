using UnityEngine;

/// <summary>
/// Pulls the pod to it when holding click
/// </summary>
public abstract class GravityWell : MonoBehaviour
{
    // FIXME: Refactor me into multiple, smaller responsibility components

    /// <summary>
    /// Game object which will be enabled when the player is trying to
    /// pull on the well but is out of the well's radius
    /// </summary>
    [SerializeField]
    private ParticleSystem rangeEffect;

    /// <summary>
    /// The maximum distance between the pod and the well in which
    /// the well can pull the pod
    /// </summary>
    [SerializeField]
    private float wellRadius = 20.0f;

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

    /// <summary>
    /// The radius from the well in which the pod starts to orbit instead of being
    /// pulled directly to it
    /// </summary>
    [SerializeField]
    private float orbitRadius = 1.0f;

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
        PodInformation.Instance.Release(this);
    }

    private void Update()
    {
        if (isBeingClicked)
        {
            var pod = PodInformation.Instance;
            float distance = Vector3.Distance(transform.position, pod.transform.position);

            if (distance < wellRadius)
            {
                if (!pod.IsBeingPulled)
                {
                    pod.Grab(this);
                    if (rangeEffect.isPlaying)
                    {
                        rangeEffect.Stop();
                    }
                }

                var rb = pod.GetComponent<Rigidbody>();
                Vector3 directionFromPodToWell = transform.position - pod.transform.position;

                if (distance < orbitRadius)
                {
                    float normalZComponent = 0;
                    float normalXComponent = 1 * Mathf.Sign(transform.position.y - pod.transform.position.y);

                    float normalYComponent = (-(normalXComponent * directionFromPodToWell.x) - (normalZComponent * directionFromPodToWell.z)) / directionFromPodToWell.y;

                    Vector3 normal = new Vector3(normalXComponent, normalYComponent, normalZComponent).normalized;

                    rb.velocity = normal;
                }
                else
                {
                    movePodTowardsWell(rb, directionFromPodToWell, distance);

                    rb.velocity = rb.velocity.normalized * clampVelocityComponent(rb.velocity.magnitude) - new Vector3();
                }

            }
            else
            {
                if (!rangeEffect.isPlaying)
                {
                    rangeEffect.Play();
                }
                pod.Release(this);
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, orbitRadius);
    }
}
