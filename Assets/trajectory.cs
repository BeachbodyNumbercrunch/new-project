using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectory : MonoBehaviour {

    public float speed;
    public GameObject[] points;
    Rigidbody2D objt;
    public int i = 0;

    void Start()
    {
        objt = GetComponent<Rigidbody2D>();
    }

    void Update () {

        if (i == points.Length)
        {
            i = 0;
        }
        Vector3 direction = points[i].transform.position - transform.position;
        direction.Normalize();
        objt.velocity = (direction * speed);
        if (Mathf.Abs(points[i].transform.position.x - transform.position.x) < 0.4)
         {
            i++;
         }
    }
}
