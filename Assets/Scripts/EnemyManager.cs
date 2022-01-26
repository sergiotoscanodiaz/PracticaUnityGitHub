using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 endPosition;

    private Vector3 startPosition;
    private bool movingToEnd; 

    void Start()
    {
        startPosition = transform.position;
        movingToEnd = true;
    }

    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        Vector3 destinyPosition = (movingToEnd) ? endPosition : startPosition;

        transform.position = Vector3.MoveTowards(transform.position, destinyPosition, speed * Time.deltaTime);

        if (transform.position == endPosition) movingToEnd = false;
        if (transform.position == startPosition) movingToEnd = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerManager>().DamagePlayer();
        }
    }
}
