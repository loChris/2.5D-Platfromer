using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //on trigger enter
    //give the player a coin
    //destroy the object
    //notify the ui

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (other != null)
            {
                player.AddCoins();
            }
            
            Destroy(this.gameObject);
        }
    }
}
