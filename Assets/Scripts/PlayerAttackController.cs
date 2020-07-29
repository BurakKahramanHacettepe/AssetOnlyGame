using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private GameObject weapon;
    private Transform weapon_transform;
    private BoxCollider2D weapon_collider;
    Vector3 mousePos;
    Vector3 wepPos;
    bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        weapon = transform.GetChild(0).gameObject;
        weapon_collider = weapon.GetComponent<BoxCollider2D>();
        weapon_transform = weapon.transform;
    }
    void WeaponTransform()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        wepPos = Vector3.ClampMagnitude((mousePos - transform.position) * 1000f, 0.9f);
        weapon_transform.localPosition = wepPos;

        float angle = Mathf.Atan2(wepPos.y, wepPos.x) * Mathf.Rad2Deg;
        weapon_transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (wepPos.x < 0)
        {
            weapon_transform.localScale = Vector3.right+Vector3.down+ Vector3.forward ;//(1,-1,1)
            
        }
        else
        {
            weapon_transform.localScale = Vector3.one;
        }
    }
    void Attack()
    {
       

        
    }
    Vector3 update, lateupdate;
    // Update is called once per frame
    void Update()
    {
        WeaponTransform();

        if (Input.GetMouseButtonDown(0))
        {
            //Attack();
        }
    }
   

    private void TurnOff()
    {
       

    }
}
