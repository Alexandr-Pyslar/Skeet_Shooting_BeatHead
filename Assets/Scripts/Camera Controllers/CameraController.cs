using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 touch;
    public float speed = 5f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            
            GetMove1();
            //GetMove2();          
        }
    }

    void GetMove1 ()
    {
        Vector3 direction = touch - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position += direction;
    }

    void GetMove2()
    {
        //смена направления вектора не решает проблемы
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - touch;
        //при попытке сгладить движение камера все равно ведет себя не совсем как ожидается.
        transform.position += direction.normalized * speed * Time.deltaTime;
    }




}