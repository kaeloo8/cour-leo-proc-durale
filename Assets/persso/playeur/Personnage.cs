using UnityEngine;

public class Personnage : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    Vector2 move;
    public Animator animation;
    private Vector2 moveDirection;
    public Transform Bulletspawnpoint;
    public GameObject ballePrefab;
    public float Bulletspeed = 10;
    public float Health = 100;

    public Health health;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        animation.SetFloat("Horizontal", move.x);
        animation.SetFloat("speed", move.magnitude);

        Vector3 direction = mousePosition - transform.position;
        rb.MovePosition(rb.position + move * speed);

        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(ballePrefab, Bulletspawnpoint.position, Bulletspawnpoint.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = Bulletspawnpoint.forward * Bulletspeed;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.tag == "zone1")
        {
            //Camera.
        }
    }
    private void OnCollisionEnter2D(Collision2D Balleennemi)
    {
        if (Balleennemi.gameObject.tag == "Bulletennemi")
        {
            Destroy(Balleennemi.gameObject);
            health.Damageplayer(10);
        }
    }
}
