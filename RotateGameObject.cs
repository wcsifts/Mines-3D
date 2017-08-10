using UnityEngine;
using System.Collections;

public class RotateGameObject : MonoBehaviour {

    public float ySpeed = 2.0f;
    public float xSpeed = 2.0f;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(2))
        {
            float y = ySpeed * Input.GetAxis("Mouse X");
            float x = xSpeed * Input.GetAxis("Mouse Y");

            transform.Rotate(x, y, 0);
        }
    }
}
