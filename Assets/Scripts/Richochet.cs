using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Richochet : MonoBehaviour
{
	GameObject GameManager;
	private Rigidbody2D rb;
	public AudioSource SoundVFX;
	Vector3 lastVelocity;
	public int ammo;

	private void Awake()
	{
		GameManager = GameObject.Find("GameManager");
		rb = GetComponent<Rigidbody2D>();
		SoundVFX = GetComponent<AudioSource> ();    
	}

	void Update()
	{
		lastVelocity = rb.velocity;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var speed = lastVelocity.magnitude;
		var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
		rb.velocity = direction * Mathf.Max(speed, 0f);
	}

	private void OnTriggerEnter2D (Collider2D collision)
    {
        GameObject targetObject = collision.gameObject;
        if (targetObject.layer == 8 & collision == targetObject.GetComponent<TargetScript>().head)
        {
            collision.GetComponent<TargetScript>().destroyTarget();
            GameManager.GetComponent<GameManager>().addHeadshotPoints();
        } else if (targetObject.layer == 8 & collision == targetObject.GetComponent<TargetScript>().body)
        {
            collision.GetComponent<TargetScript>().destroyTarget();
            GameManager.GetComponent<GameManager>().addBodyPoints();
        }
        Destroy(gameObject);
    }

	/*private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == ("DefaultChar"))
		{
			Destroy(gameObject);
			SceneManager.LoadScene(0);
		}
	}*/

}
