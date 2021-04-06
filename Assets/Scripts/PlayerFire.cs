using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
   [SerializeField] private Transform pfBullet;

    private void Awake()
    {
        GetComponent<PlayerController>().OnLMBDown += PlayerShootProjectiles_OnShoot;
    }

    private void PlayerShootProjectiles_OnShoot(object sender, PlayerController.OnLMBDownEventArgs e) {
        Transform bulletTransform = Instantiate(pfBullet, e.gunEndPointPosition, Quaternion.identity);
        Vector3 shootDir = (e.shootPosition - e.gunEndPointPosition).normalized;
        bulletTransform.GetComponent<Bullet>().Setup(shootDir, 6f);
    }    
}
