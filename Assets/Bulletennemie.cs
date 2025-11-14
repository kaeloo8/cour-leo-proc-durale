using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletennemie : MonoBehaviour
{
    public float moveSpeedennemi = 5f;
    public float lifeennemi = 5;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, lifeennemi);
    }

    private void OnCollisionEnter2D(Collision2D ennemie)
    {
        if (ennemie.gameObject.tag != "Ennemis" )
        {
            if(ennemie.gameObject.tag != "Bulletennemi")
            {
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * moveSpeedennemi * Time.deltaTime;
    }
}
