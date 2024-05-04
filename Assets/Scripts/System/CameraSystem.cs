using Cinemachine;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private Transform followTarget;

    float xRotation;
    float yRotation;
    float mouseX;
    float mouseY;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _camera.Follow = followTarget;
    }
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }
    private void LateUpdate()
    {
        CameraRotation();
    }
    private void CameraRotation()
    {
        xRotation += mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -35, 25);
        Quaternion rotation = Quaternion.Euler(xRotation,yRotation,0);
        followTarget.rotation = rotation;
    }
}
