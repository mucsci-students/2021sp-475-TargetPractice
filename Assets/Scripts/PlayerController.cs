using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bullet_spawn_location;
    public event EventHandler<OnLMBDownEventArgs> OnLMBDown;
    public class OnLMBDownEventArgs : EventArgs {
    public Vector3 gunEndPointPosition; 
    public Vector3 shootPosition;
    }
    private Vector3 gunEndPointPosition;
    private Vector3 shootPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 shootPosition = Input.mousePosition;
            shootPosition.z = 0.0f;
            shootPosition = Camera.main.ScreenToWorldPoint(shootPosition);
            shootPosition = shootPosition - gunEndPointPosition;
            OnLMBDown?.Invoke(this, new OnLMBDownEventArgs { gunEndPointPosition = bullet_spawn_location.transform.position, shootPosition = shootPosition});
        }

        Vector3 wantedPos = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        float angle = (Mathf.Atan2(wantedPos.y, wantedPos.x) * Mathf.Rad2Deg) - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
