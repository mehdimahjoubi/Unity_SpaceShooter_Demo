using UnityEngine;
using System.Collections;

public class ParticleLayerSortingScript : MonoBehaviour
{
    public string layerName;
    public int orderInLayer;

    void Start()
    {
        particleSystem.renderer.sortingLayerName = layerName;
        particleSystem.renderer.sortingOrder = orderInLayer;
    }

}
