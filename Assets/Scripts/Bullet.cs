using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Bullet : MonoBehaviour
{
    public GameObject GameManager;
    public AudioSource sound;
    private Vector3 shootDir;

    private void Start ()
    {
        GameManager = GameObject.Find("GameManager");
        sound.Play();

    }

    public void Setup(Vector3 shootDir, float bulletVelocity)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>(); 
        this.shootDir = shootDir;
        transform.eulerAngles = new Vector3 (0, 0, UtilsClass.GetAngleFromVectorFloat(shootDir));
        rb.velocity = new Vector2(shootDir.x * bulletVelocity, shootDir.y * bulletVelocity) * bulletVelocity;
        Destroy(gameObject, 10f);
    }

    private void Update() 
    {
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        sound.Stop();
        GameObject targetObject = collision.gameObject;
        if (targetObject.layer == 0)
        {
            Destroy(gameObject);
        }
        else if (targetObject.layer == 8 & collision == targetObject.GetComponent<TargetScript>().head)
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
}
