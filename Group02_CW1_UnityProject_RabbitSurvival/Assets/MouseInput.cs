using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public float speed = 10f;

    void OnMouseDrag()
    {
        float moveX = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        transform.Translate(moveX, 0f, moveZ, Space.World);
    }
}