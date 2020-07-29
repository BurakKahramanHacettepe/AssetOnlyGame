using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called befor-te the first frame update
    private Transform player_t;
    void Start()
    {
        player_t = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player_t.position + Vector3.back * 10;
    }

    [ContextMenu("Focus")]
    private void Focus()
    {
        player_t = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = player_t.position + Vector3.back * 10;

    }
}
