using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
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
        print(collision.tag);

        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().Hurt();
        }
        else if (collision.CompareTag("Chest"))
        {
            collision.GetComponent<ChestScript>().unlock();
        }
    }
}
