using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire: MonoBehaviour
{

    public float speed = 10; 
    public Rigidbody2D bullet; 
    public Transform gunPoint; 
    public float fireRate = 1;
    private rot Hand;
    private float curTimeout;

    void Start()
    {
      Hand = GetComponent<rot>();
    }


    void Update()
    {
        curTimeout = 100;
    }

    public void Fire()
    {
        curTimeout += Time.deltaTime;
        if (curTimeout > fireRate)
        {
            curTimeout = 0;
            
            Vector3 direction = Hand.transform.position - gunPoint.position;
            direction.Normalize();
            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Hand.transform.rotation) as Rigidbody2D;
            clone.velocity = direction * speed;
        }
    }
}