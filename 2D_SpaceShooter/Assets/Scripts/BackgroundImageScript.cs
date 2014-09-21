using UnityEngine;
using System.Collections;

public class BackgroundImageScript : MonoBehaviour {

    public float imageSize = 20.4f;
    public Transform previousImage;
    public float speed;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position - new Vector3(0, 1, 0), Time.deltaTime * speed);
    }

    void OnBecameInvisible()
    {
        if (previousImage != null)
            transform.position = previousImage.position + new Vector3(0, imageSize, 0);
    }

}
