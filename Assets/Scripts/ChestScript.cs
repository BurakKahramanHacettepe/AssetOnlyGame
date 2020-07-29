using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{

    public Sprite opened;
    public GameObject[] inside;
    // Start is called before the first frame update
    
    // Update is called once per frame
    public void unlock()
    {
        GetComponent<SpriteRenderer>().sprite = opened;
        GetComponent<BoxCollider2D>().enabled = false;
        GameObject clone = Instantiate(inside[Random.Range(0,inside.Length)], transform.position, Quaternion.identity);
        Vector3 spawn = Random.onUnitSphere*1000;
        spawn.z = 0;
        spawn = Vector3.ClampMagnitude(spawn,1);
        LeanTween.move(clone, transform.position+ spawn, 1f).setEaseOutElastic();
    }
}
