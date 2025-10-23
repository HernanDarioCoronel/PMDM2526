using UnityEngine;

public static class GrapplingSystem
{
    public static bool StartGrapple(
        Rigidbody2D rb,
        DistanceJoint2D joint,
        LineRenderer line,
        Transform playerTransform,
        Collider2D grapplePoint,
        float maxRange
    )
    {
        if (grapplePoint == null)
            return false;

        Vector2 grapplePos = grapplePoint.bounds.center;
        float distance = Vector2.Distance(playerTransform.position, grapplePos);

        if (distance > maxRange)
            return false;

        joint.enabled = true;
        joint.connectedAnchor = grapplePos;
        joint.distance = distance * 0.8f;

        line.enabled = true;
        line.SetPosition(0, playerTransform.position);
        line.SetPosition(1, grapplePos);

        return true;
    }

    public static void StopGrapple(DistanceJoint2D joint, LineRenderer line)
    {
        joint.enabled = false;
        line.enabled = false;
    }

    public static void DrawGrappleLine(
        LineRenderer line,
        Transform playerTransform,
        Collider2D grapplePoint
    )
    {
        if (line == null || grapplePoint == null || !line.enabled)
            return;

        line.SetPosition(0, playerTransform.position);
        line.SetPosition(1, grapplePoint.bounds.center);
    }
}
