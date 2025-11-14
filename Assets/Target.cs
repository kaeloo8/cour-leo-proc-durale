using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{

    public float health = 30f;
    public float maxihealth = 30f;

    public Image healthbarimage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthbarimage.fillAmount = health / maxihealth;
    }
    private void OnCollisionEnter2D(Collision2D Balle)
    {
        if (Balle.gameObject.tag == "BulletPlayer")
        {
            Destroy(Balle.gameObject);
            health -= 10;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
