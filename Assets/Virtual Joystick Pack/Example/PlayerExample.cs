using UnityEngine;

public class PlayerExample : MonoBehaviour {

    bool FacingRight = false;
    public Joystick joystick;

    private rot Hand;

    Rigidbody2D rig;
    float posX, posY;
    public float speed = 10f;


    void Start()
    { 
        rig = GetComponent<Rigidbody2D>();
        posX = rig.position.x;
        posY = rig.position.y;
    }
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        FacingRight = !FacingRight;
    }

	void Update () 
	{
        Hand = GetComponentInChildren<rot>();

        rig.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);

        if ((joystick.Horizontal < 0 && (FacingRight == true && Hand.aimed_check == false)) || (Hand.dist < 0 && FacingRight == true && Hand.aim != Hand.Player))
        {
            flip();
        }
        if ((joystick.Horizontal > 0 && (FacingRight == false && Hand.aimed_check == false)) || (Hand.dist > 0 && FacingRight == false && Hand.aim != Hand.Player))
        {
            flip();
        }
    }
}
