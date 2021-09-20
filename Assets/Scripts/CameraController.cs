
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;

    public float yawSpeed = 100f;

    private float currentZoom = 10f;
    private float currentYaw = 0f;


    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }


    private void LateUpdate()
    {
        // Move the camera offset distance away from the target
        transform.position = target.position + offset * currentZoom;

        // Look at the target, offset by pitch so it's not looking at the feet
        transform.LookAt(target.position + Vector3.up * pitch);

        // Rotate based on yaw
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
