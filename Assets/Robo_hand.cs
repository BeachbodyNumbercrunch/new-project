using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_hand : MonoBehaviour
{

    public bool aimed_check;
    public float dist;
    public bool FacingRight = false;
    public float rot1 = 0;
    public GameObject Player;
    public GameObject Robo;
    Robo_flip body;
    public double rast = 10;
    RaycastHit2D hit;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (rast < 10)
        {
            aimed_check = true;
        }

        Vector3 dir = Player.transform.position - transform.position;
        dir.Normalize();
        rot1 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rast = Vector3.Distance(Player.transform.position, Robo.transform.position);
        dist = Player.transform.position.x - Robo.transform.position.x;

        hit = Physics2D.Raycast(transform.position, dir, 10);

        body = GetComponentInParent<Robo_flip>();
        FacingRight = body.FacingRight;

        if (rast >= 10 || ( hit.collider != null && hit.collider.tag == "wall"))
        {
            aimed_check = false;
            rast = 10;
            rot1 = FacingRight ? -90 : 90;
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
}
