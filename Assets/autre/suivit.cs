using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suivit : MonoBehaviour
{
    public Personnage mdr;
    public Rigidbody2D rb;
    public float speed = 1f;

    void Update()
    {

        if (mdr.transform.position.x > this.transform.position.x)
        {
            rb.transform.position = new Vector2(this.transform.position.x + 1 * speed, this.transform.position.y);
        }
        if (mdr.transform.position.x < this.transform.position.x)
        {
            rb.transform.position = new Vector2(this.transform.position.x - 1 * speed, this.transform.position.y);
        }
        if (mdr.transform.position.y > this.transform.position.y)
        {
            rb.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1 * speed);
        }
        if (mdr.transform.position.y < this.transform.position.y)
        {
            rb.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 1 * speed);
        }
    }
}
