using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public LayerMask mask;
    public float runSpeed = 750f;
    private Vector3 movement;
    private Rigidbody2D _Rigidbody2D;
    private Vector3 init_pos;
    private bool detected = false;


    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 750f;
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        init_pos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Detect();
    }

    void Detect()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 5f, mask);
        if (collider != null)
        {
            detected = true;
            movement = Vector2.ClampMagnitude((collider.transform.position - transform.position), 1) * runSpeed * Time.deltaTime;
            _Rigidbody2D.velocity = movement;
        }
        else if (!detected && Vector3.Distance(transform.position, init_pos) > 0.5f)
        {
            movement = Vector2.ClampMagnitude((init_pos - transform.position), 1) * runSpeed* Time.deltaTime / 3f;
            _Rigidbody2D.velocity = movement;
        }
        else
        {
            detected = false;
            _Rigidbody2D.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerEssentials>().Hurt();

        }
    }

    public void Hurt()
    {
        Destroy(gameObject);
    }
}
