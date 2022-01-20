using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float previousXPosition;

    private void Start()
    {
        previousXPosition = transform.parent.position.x;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sprite.flipX = previousXPosition < transform.position.x;
        previousXPosition = transform.position.x;

    }

}
