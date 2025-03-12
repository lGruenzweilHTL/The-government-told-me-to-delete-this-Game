using UnityEngine;

public class CameraModes : MonoBehaviour
{
    [System.Serializable]
    private struct CameraMode
    {
        public Vector3 position;
        public Vector3 rotation;
    }
    
    [SerializeField] private Transform cam;

    [SerializeField] private CameraMode firstPerson = new CameraMode()
    {
        position = new Vector3(0, 0, -0.145f),
        rotation = Vector3.zero
    };

    [SerializeField] private CameraMode thirdPerson = new CameraMode()
    {
        position = new Vector3(0, 0.07f, -0.5f),
        rotation = Vector3.zero
    };
    
    [SerializeField] private CameraMode back = new CameraMode()
    {
        position = new Vector3(0, 0.07f, -0.5f),
        rotation = Vector3.zero
    };
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) MoveCamera(firstPerson);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) MoveCamera(thirdPerson);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) MoveCamera(back);
    }
    
    private void MoveCamera(CameraMode mode)
    {
        cam.localPosition = mode.position;
        cam.localEulerAngles = mode.rotation;
    }
}
