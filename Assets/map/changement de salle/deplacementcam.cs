using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cr1 : MonoBehaviour
{
    public bool CR1 = false;
    public bool CR2 = false;
    public bool CR3 = false;
    public bool CR4 = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "boxz1")
        {
            this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
            CR1 = true;
        }
        if (gameObject.tag == "boxz2")
        {
            CR2 = true;
        }
        if (gameObject.tag == "boxz3")
        {
            CR3 = true;
        }
        if (gameObject.tag == "boxz4")
        {
            CR4 = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObject.tag == "boxz1")
        {
            CR1 = false;
        }
        if (gameObject.tag == "boxz2")
        {
            CR2 = false;
        }
        if (gameObject.tag == "boxz3")
        {
            CR3 = false;
        }
        if (gameObject.tag == "boxz4")
        {
            CR4 = false;
        }
    }
}
