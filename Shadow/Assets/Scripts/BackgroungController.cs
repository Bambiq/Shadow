using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroungController : MonoBehaviour
{
    private float lenght;
    private float startpos; // Starting position

    public GameObject cam;
    public float parallaxEffect;

    // Setting camera position & size of background
    private void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        // Movement of background
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        // Rendering new background
        if (temp > startpos + lenght)
            startpos += lenght;
        else if (temp < startpos - lenght)
            startpos -= lenght;
    }
}
