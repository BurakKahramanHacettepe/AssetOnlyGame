using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEssentials : MonoBehaviour
{
    private GameObject hp_bar;

    
    // Start is called before the first frame update
    void Start()
    {
        hp_bar = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    public void Hurt()
    {
        if (hp_bar.transform.localScale.x != 0)
        {
            hp_bar.transform.localScale -= Vector3.right * 10;

            if (hp_bar.transform.localScale.x == 0)
            {
                GameOver();
            }
        }
       
            
        
    }

    private void GameOver()
    {
        GetComponent<PlayerMovementController>().enabled = false;
        GetComponent<PlayerAttackController>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;

    }
}
