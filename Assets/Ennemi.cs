using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public Transform player;
    public GameObject balle;
    private float shotCooldown;
    public float startShotCooldown;
    // Start is called before the first frame update
    void Start()
    {
        shotCooldown = startShotCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

        transform.right = direction;

        if (shotCooldown <= 0)
        {
            Instantiate(balle, transform.position, transform.rotation);
            shotCooldown = startShotCooldown;
        }
        else
        {
            shotCooldown -= Time.deltaTime;
        }
    }
}
