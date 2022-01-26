using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int quantity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerManager>().PickUpPowerUp();
            Destroy(gameObject);
        }

    }
}
