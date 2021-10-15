using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public float speed = 0.5f;
    private Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>(); //r is a reference to the renderer 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        r.material.mainTextureOffset = offset;   //offset material of object
    }
}
