using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // The object to orbit around
    public float rotationSpeed = 2.0f;
    public float zoomSpeed = 5.0f;
    public float minZoomDistance = 2.0f;
    public float maxZoomDistance = 10.0f;

    private Vector3 lastMousePosition;
    private float currentZoomDistance = 5.0f;

    private void Start()
    {
        lastMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;

            // Rotate the camera around the target based on mouse input
            float rotationX = deltaMouse.y * rotationSpeed;
            float rotationY = -deltaMouse.x * rotationSpeed;

            transform.RotateAround(target.position, Vector3.up, rotationY);
            transform.RotateAround(target.position, transform.right, rotationX);
        }

        // Zoom using the mouse scroll wheel
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        currentZoomDistance -= scrollWheel * zoomSpeed * Time.deltaTime;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

        // Update the camera's position based on the zoom distance
        Vector3 offset = -transform.forward * currentZoomDistance;
        transform.position = target.position + offset;
    }

}
