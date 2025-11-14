using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PersonnageV1 : MonoBehaviour
{
    public float speed;
    public Rigidbody2D Rb;
    private Vector2 moveDirection;
    public Transform Bulletspawnpoint;
    public GameObject ballePrefab;
    public float Bulletspeed = 10;
    public float Health = 100;

    public Health health;


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 

        Vector3 direction = mousePosition - transform.position;
        if (direction != Vector3.zero)
        {
           float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if(Input.GetMouseButtonDown(0)) 
        {
            var bullet = Instantiate(ballePrefab, Bulletspawnpoint.position, Bulletspawnpoint.rotation);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = Bulletspawnpoint.forward * Bulletspeed;
        }
    }
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        Rb.linearVelocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
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