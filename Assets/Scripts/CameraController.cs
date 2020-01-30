using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 lastPosition;
    public float speed = 0.7f;
    private float limit = 5f;
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
            Camera.main.transform.position = new Vector3(Mathf.Clamp(camPos.x, -limit, limit), Mathf.Clamp(camPos.y, -limit, limit), camPos.z);
            lastPosition = Input.mousePosition;
        }
    }




        
}