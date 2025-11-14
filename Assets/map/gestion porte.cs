using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool lockroom = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lockroom = false)
        {

        }
        if (lockroom = true)
        {
            Destroy(this.gameObject);
        }
    }
}
