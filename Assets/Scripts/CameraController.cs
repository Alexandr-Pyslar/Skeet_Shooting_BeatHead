using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 touchPos;
    private float rangeX = 14f;
    private float rangeY = 7f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Camera.main.transform.position = MovedCamera();
        }
    }

    Vector3 MovedCamera()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - touchPos;
        Vector3 camPos = Camera.main.transform.position;
        return new Vector3(Mathf.Clamp(camPos.x - direction.x, -rangeX, rangeX), Mathf.Clamp(camPos.y - direction.y, -rangeY, rangeY), camPos.z);
    }

}