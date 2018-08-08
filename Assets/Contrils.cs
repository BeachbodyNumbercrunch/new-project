using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contrils : MonoBehaviour
{

    public float moveSpeed;
    public Joystick joystick;

    void Update()
    {
        Vector2 moveVector = (transform.right * joystick.Horizontal  + transform.forward * joystick.Vertical).normalized;
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
    }
}