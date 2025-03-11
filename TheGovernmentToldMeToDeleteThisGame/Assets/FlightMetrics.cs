using System;
using UnityEngine;

public class FlightMetrics : MonoBehaviour
{
    [SerializeField] private float groundCheckDistance = 10f;
    [SerializeField] private LayerMask groundLayers;
    public float DistanceFromGround { get; private set; }
    public float Altitude => transform.position.y;

    private void Update()
    {
        DistanceFromGround = FindGroundDistance();
    }

    private float FindGroundDistance()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out var hit, groundCheckDistance, groundLayers))
        {
            return hit.distance;
        }

        return -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * groundCheckDistance);
    }
}
