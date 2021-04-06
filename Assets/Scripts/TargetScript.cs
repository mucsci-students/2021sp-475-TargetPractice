using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public CircleCollider2D head;
    public BoxCollider2D body;
    public AudioClip impact;
    public AudioSource audio;
    
    // Start is called before the first frame update
    void Start()
    {
         audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnCollisionEnter2D (Collision2D collision)
    {
        audio.PlayOneShot(impact, 0.7F);
    }

    public void destroyTarget ()
    {
        Destroy(gameObject);
    }
}
