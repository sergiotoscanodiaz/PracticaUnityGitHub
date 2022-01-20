using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed;
    public Transform limit1;
    public Transform limit2;


    private Transform followingPosition;

    void Start()
    {
        followingPosition = limit1;
    }

    void Update()
    {
        if (transform.position == limit1.position)
            followingPosition = limit2;

        if (transform.position == limit2.position)
            followingPosition = limit1;

        transform.position = Vector3.MoveTowards(transform.position, followingPosition.position, speed * Time.deltaTime);
    }
}
