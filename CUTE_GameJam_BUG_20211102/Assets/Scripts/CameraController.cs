using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float speed = 10;
    public Vector2 limitHorizontal;
    public Vector2 limitVertical;

    private void LateUpdate() 
    {
        Track();
    }

    private void Track()
    {
        Vector3 posTarget = target.position;
        Vector3 posCamera = transform.position;

        posCamera = Vector3.Lerp(posCamera, posTarget, Time.deltaTime * speed);

        posCamera.x = Mathf.Clamp(posCamera.x, limitHorizontal.x, limitHorizontal.y);
        posCamera.y = Mathf.Clamp(posCamera.y, limitVertical.x, limitVertical.y);
        posCamera.z = -10;

        transform.position = posCamera;
    }
}
