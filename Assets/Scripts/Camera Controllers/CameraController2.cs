using UnityEngine;

public class CameraController2 : MonoBehaviour
{

    private Vector3 mousePos;
    public Rigidbody2D rb;
    private Vector3 direction;
    public float moveSpeed = 5f;
    bool MouseDOWN = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        MouseDOWN = true;
    }

    void OnMouseUp()
    {
        MouseDOWN = false;
    }


    void FixedUpdate()
    {
        if (MouseDOWN)
        {
            {

                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                mousePos.z = -1;
                direction = (mousePos - transform.position);
                rb.velocity = new Vector2(Mathf.Clamp(direction.x, -5f, 5f), Mathf.Clamp(direction.y, -4f, 4f)) * moveSpeed;
            }

        }
    }
}
