 using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 lastPosition;
    public float speed = 2f;
    private float limitX = 15f;
    private float limitY = 8.8f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))      
        {
            Vector3 dir = Input.mousePosition - lastPosition;
            Camera.main.transform.position += dir * Time.deltaTime * speed;
            Vector3 camPos = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(Mathf.Clamp(camPos.x, -limitX, limitX), Mathf.Clamp(camPos.y, -limitY, limitY), camPos.z);
            lastPosition = Input.mousePosition;
        }
    }  
}