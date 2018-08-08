using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_door : MonoBehaviour {
    float r = 0;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.isTrigger)
        {
            switch (coll.tag)
            {
                case "Player":
                    Vector3 os = new Vector3(0, 0, 1);
                    r = r == 0 ? 90 : 0; 
                    transform.rotation = Quaternion.AngleAxis(r, os);
                    break;
            }

        }
    }
}
