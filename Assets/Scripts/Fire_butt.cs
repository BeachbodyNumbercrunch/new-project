using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_butt : MonoBehaviour
{

    fire fire1;

    void Start()
    {
        fire1 = GetComponent<fire>();
    }

    public void ClickTest()
    {
        fire1.Fire();
    }
}
