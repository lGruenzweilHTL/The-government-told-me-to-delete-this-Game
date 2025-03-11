using UnityEngine;
using UnityEngine.UI;

public class FlightMetricsHUD : MonoBehaviour
{
    [SerializeField] private FlightMetrics flightMetrics;
    [SerializeField] private Text text;

    private void Update()
    {
        text.text = $"Altitude: {flightMetrics.Altitude}\nDistance from ground: {flightMetrics.DistanceFromGround}";
    }
}
