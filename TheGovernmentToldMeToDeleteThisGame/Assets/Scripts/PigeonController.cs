using UnityEngine;

public class PigeonController : MonoBehaviour
{
    [SerializeField] private Vector2 sensitivity = new Vector2(1f, 1f);
    [SerializeField] private float speed = 5f;
    [SerializeField] private AnimationCurve accelerationCurve;
    [SerializeField, Tooltip("The number of seconds it takes to reach full speed")] 
    private float acceleration = 1f;

    private float _currSpeed;
    private float _currAcceleration;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        bool spaceSpressed = Input.GetKey(KeyCode.Space);

        // Pigeon flight controls
        // Up/down => move up/down
        // Left/right => tilt left/right
        transform.Rotate(Vector3.forward, -mouseX * sensitivity.x);
        transform.Rotate(Vector3.right, mouseY * sensitivity.y);
        
        // Pigeon movement controls
        // Space => move forward
        if (spaceSpressed)
        {
            // Accelerate
            _currAcceleration = Mathf.Clamp(_currAcceleration + acceleration * Time.deltaTime, 0, 1);
        }
        else
        {
            // Decelerate
            _currAcceleration = Mathf.Clamp(_currAcceleration - acceleration * Time.deltaTime, 0, 1);
        }

        _currSpeed = speed * accelerationCurve.Evaluate(_currAcceleration);

        // Move forward
        transform.position += transform.forward * (_currSpeed * Time.deltaTime);
    }
}
