using UnityEngine;

public class ForceBasedGravityWell : GravityWell
{
    protected override void movePodTowardsWell(Rigidbody podRb, Vector3 directionFromPod, float distance)
    {
        podRb.AddForce(directionFromPod.normalized * distance * coefficient);
    }
}
