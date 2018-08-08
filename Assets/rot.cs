using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour {

    public GameObject aim;

    public bool aimed_check;
    public float dist;

    public bool FacingRight = false;
    public Joystick joystick;
    public float rot1 = 0;
    GameObject[] enemies;
    public GameObject Player;
    public float en_num;
    public double rast= 10;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        en_num = enemies.Length;
        for (int i = 0; i < en_num; i++)
        {
        if ( Vector3.Distance(enemies[i].transform.position, Player.transform.position) < rast)
            {
                aim = enemies[i];
            }
        }
        
        if (rast > 10 ||aim == null)
        {
            aimed_check = false;
            rast = 10;
            aim = Player;
            rot1 = 0;
        }

        if (aim != Player)
        {
            aimed_check = true;
            Vector3 dir = aim.transform.position - transform.position;
            dir.Normalize();
            rot1 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rast = Vector3.Distance(aim.transform.position, Player.transform.position);
            dist = aim.transform.position.x - transform.position.x;
        }

        

        if ((joystick.Horizontal < 0 &&( FacingRight == true && aimed_check == false)) || (dist < 0 && FacingRight == true))
        {
            flip();
        }
        if ((joystick.Horizontal > 0 && (FacingRight == false && aimed_check == false)) || (dist  > 0 && FacingRight == false))
        {
            flip();
        }


        if (rot1 > 90)
        {
            rot1 = 180 + rot1;
        }
        if (rot1 < -90)
        {
            rot1 = 180 + rot1;
        }
        if (rot1 > 50 && FacingRight)
        {
            rot1 = 50;
        }
        else if (rot1 < -60 && FacingRight)
        {
            rot1 = -60;
        }

        Vector3 os = new Vector3(0, 0, 1);
        transform.rotation = Quaternion.AngleAxis(rot1, os);
    }
    void flip()
    {
        FacingRight = !FacingRight;
    }
}

