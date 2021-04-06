using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRenderLayer : MonoBehaviour
{
    public string sortingLayerName;
    public int sortingOrder;

    void Start()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = sortingLayerName;

        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = sortingOrder;
    }
}
