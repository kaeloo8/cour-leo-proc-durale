using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float health = 75f;
    public float maxihealth = 100f;

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

    public void Damageplayer (int damageamount)
    {
        health -= damageamount;
    }
    public void HealPlayer(int healamount)
    {
        health += healamount;
    }
}
