using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxFactor = 0.5f;
    private Vector3 previousCameraPosition;

    void Start()
    {
        previousCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cameraTransform.position - previousCameraPosition;
        transform.position += new Vector3(delta.x * parallaxFactor, 0, 0);
        previousCameraPosition = cameraTransform.position;
    }
}
