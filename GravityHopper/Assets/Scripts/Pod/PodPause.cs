using UnityEngine;

public class PodPause : MonoBehaviour
{
    private Vector3 storedVelocity;
    private Vector3 storedAngularVelocity;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        PauseManager.Instance.OnPause += this.PauseRb;
        PauseManager.Instance.OnResume += this.ResumeRb;
    }

    private void OnDestroy()
    {
        PauseManager.Instance.OnPause -= this.PauseRb;
        PauseManager.Instance.OnResume -= this.ResumeRb;
    }

    private void PauseRb()
    {
        storedVelocity = rb.velocity;
        storedAngularVelocity = rb.angularVelocity;
        rb.isKinematic = true;
    }

    private void ResumeRb()
    {
        rb.isKinematic = false;
        rb.velocity = storedVelocity;
        rb.angularVelocity = storedAngularVelocity;
    }
}
