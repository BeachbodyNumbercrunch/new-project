using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class hit : MonoBehaviour
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
                case "Enemy":
                    Destroy(coll.gameObject);
                    Destroy(gameObject);
                    break;
            }

        }
    }
}