using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform limit1;
    [SerializeField] private Transform limit2;


    private Transform followingPosition;

    void Start()
    {
        speed = 5f;
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
