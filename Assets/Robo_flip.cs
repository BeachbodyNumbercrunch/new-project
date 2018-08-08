using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo_flip : MonoBehaviour {

    public bool FacingRight = true;
    public GameObject Player;
    public float dist;
    Robo_hand Hand;

	void Update () {

        Hand = GetComponentInChildren<Robo_hand>();
        dist = Player.transform.position.x - transform.position.x;

        if (dist > 0 && FacingRight == false && Hand.aimed_check)
        {
            flip();
        }
        else if(dist < 0 && FacingRight == true && Hand.aimed_check)
        {
            flip();
        }
    
	}

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        FacingRight = !FacingRight;
    }
}
