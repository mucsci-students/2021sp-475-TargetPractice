using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject SideKick;

    public void AddObject()
    {
    	Instantiate(SideKick, Vector3.zero, Quaternion.identity);
    }
}
