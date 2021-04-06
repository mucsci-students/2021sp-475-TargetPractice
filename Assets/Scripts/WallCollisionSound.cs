using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource SoundVFX;

    void Start()
    {
    	SoundVFX = GetComponent<AudioSource> ();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {
    	if(collision.gameObject.tag == "SurroundingWalls")
    	{
    		SoundVFX.Play();
    	}
    }
}
