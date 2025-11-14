using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zt3 : MonoBehaviour
{
    public Camera cam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            cam.depth = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.depth = -1;
        }
    }

}
