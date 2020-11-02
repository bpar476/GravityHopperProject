using UnityEngine;

public class LinearGravityWell : GravityWell
{
    protected override void movePodTowardsWell(Rigidbody podRb, Vector3 directionFromPod, float distance)
    {
        podRb.velocity = directionFromPod.normalized * distance * coefficient;
    }
}
