using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class hit_en : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.isTrigger)
        {
            switch (coll.tag)
            {
                case "Player":
                   // Destroy(coll.gameObject);
                    Destroy(gameObject);
                    break;
            }

        }
    }
}