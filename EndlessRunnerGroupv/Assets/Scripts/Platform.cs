using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float slidey = 0.5f;
    void Start()
    {
        
    }

   
    void Update()
    {
        float OffsetY = Time.time * slidey;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, OffsetY);
    }
}
