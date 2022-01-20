using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxImpact : MonoBehaviour
{
    public float parallaxImpact;

    private Transform camara;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        camara = Camera.main.transform;
        lastCameraPosition = camara.position;
    }

    private void LateUpdate()
    {
        Vector3 backgroundMove = camara.position - lastCameraPosition;
        transform.position += new Vector3(backgroundMove.x * parallaxImpact, backgroundMove.y, 0);
        lastCameraPosition = camara.position;
    }
}
