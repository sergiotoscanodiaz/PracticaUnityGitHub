using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloMortalmenteInvisible : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerManager>().GameOver();
        }
    }
   
    }

    //Update no es necesario
}
