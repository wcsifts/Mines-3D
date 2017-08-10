using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    public Transform target;
    public Vector3 targetOffset;
    public float distance;
    public float maxDistance;
    public float minDistance;
    public float zoomSpeed = 40f;
    public float zoomDampening = 5.0f;
    public float zoomRate = 40f;

    private float currentDistance;
    private float desiredDistance;
    private Vector3 position;
    private Vector2 desiredInputPosition;
    private Vector2 currentTargetPosition;
    private Vector2 currentInputPosition;

    void Start()
    {
        Zoom();
    }

    void onEnable()
    {
        Zoom();
    }

   public void Zoom()
    {
        if (!target)
        {
            GameObject goTo = new GameObject("Camera Target");
            goTo.transform.position = transform.position + (transform.forward * distance);
            target = goTo.transform;
        }

        distance = Vector3.Distance(transform.position, target.position);
        currentDistance = distance;
        desiredDistance = distance;


    }

    void LateUpdate()
    {

        desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
        desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
        currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);
        currentTargetPosition = target.position;
        currentInputPosition = Vector2.Lerp(currentInputPosition, desiredInputPosition, Time.deltaTime * 5f);
        position = target.position - (Vector3.forward * currentDistance + targetOffset);
        transform.position = position;
    }

}
