using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class orientationfleche : MonoBehaviour
{
    private Vector2 moveDirection;
    private Vector2 posplay;

    public List<Camera> cameras;
    // Update is called once per frame
    void Update()
    {

        Camera currentCam = cameras[0];

        foreach (Camera cam in cameras)
        {
            if(cam.depth > currentCam.depth)
            {
                currentCam=cam;
            }
        }

        Vector3 mousePosition = currentCam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        print(mousePosition- transform.position);

        Vector3 direction = mousePosition - transform.position;
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
