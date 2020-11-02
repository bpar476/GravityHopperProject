using UnityEngine;

public class SquareGravityWell : GravityWell
{
    protected override void movePodTowardsWell(Rigidbody podRb, Vector3 directionFromPod, float distance)
    {
        podRb.velocity = directionFromPod.normalized * distance * distance * coefficient;
    }
}
