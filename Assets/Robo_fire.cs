using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_fire : MonoBehaviour
{

    public float speed = 10;
    public Rigidbody2D bullet;
    public Transform gunPoint;
    public float fireRate = 1;
    public Robo_hand Rob_Hand;
    public float curTimeout;

    void Start()
    {
        Rob_Hand = GetComponent<Robo_hand>();
    }


    void Update()
    {
        if (curTimeout > 0.3)
        {
            Fire();
        }
        if (Rob_Hand.aimed_check)
        {
          curTimeout += Time.deltaTime;
        }
    }

    public void Fire()
    {
        
        if (curTimeout > fireRate)
        {
            curTimeout = 0;

            Vector3 direction = Rob_Hand.transform.position - gunPoint.position;
            direction.Normalize();
            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Rob_Hand.transform.rotation) as Rigidbody2D;
            clone.velocity = direction * speed;
        }
    }
}