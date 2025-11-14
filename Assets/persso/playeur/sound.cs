using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class sound : MonoBehaviour
{
    public AudioClip son = null;
    private AudioSource tir;

    // Update is called once per frame
    private void Awake()
    {
        tir = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            tir.PlayOneShot(son);
        }
    }
}
