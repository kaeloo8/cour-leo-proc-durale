using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float life = 5;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter2D(Collision2D ennemie)
    {
        if (ennemie.gameObject.tag != "Player")
        {
            if (ennemie.gameObject.tag != "BulletPlayer")
            {
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }
}
