using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float SPEED = 7.5f;
    public GameObject khopesh;
    public GameObject hand;
    public Animator anim;
    public Camera cam;

    private Vector2 movement;
    private float friction = 0.25f;
   
    private bool action = false;
    private int actionTick = 0;

    private bool slashing;
    private int SLASH_TICKS = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector2 m = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 dir = m - (Vector2)cam.WorldToScreenPoint(this.transform.position);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            this.transform.localScale = new Vector3(Mathf.Sign(dir.x), 1, 1);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("slash");
        }
        else if (Input.GetButtonDown("Ability1"))
        {
            action = true;
        }
        else if (Input.GetButtonDown("Ability2"))
        {
            action = true;
        }
        else if (Input.GetButtonDown("Dash"))
        {
            action = true;
        }
        else if (Input.GetButtonDown("PlaceItem"))
        {
            action = true;
        }

        
    }

    void FixedUpdate()
    {
        Vector2 vel = new Vector2(Mathf.Lerp(this.GetComponent<Rigidbody2D>().velocity.x, movement.x * SPEED, friction),
            Mathf.Lerp(this.GetComponent<Rigidbody2D>().velocity.y, movement.y * SPEED, friction));
        if (vel.magnitude > SPEED)
        {
            vel = vel.normalized * SPEED;
        }
        this.GetComponent<Rigidbody2D>().velocity = vel;
        
        /*
        if (slashing)
        {
            int frame = SLASH_TICKS - actionTick + 1;
            if (frame == 4)
            {
                this.khopesh.GetComponent<Collider2D>().enabled = true;
            }
            else if (frame > 6 && frame <= 8)
            {
                this.hand.transform.eulerAngles += new Vector3(0, 0, -25f * dir);
            } else if (frame > 10 && frame <= 12)
            {
                this.hand.transform.eulerAngles += new Vector3(0, 0, 25f * dir);
            } else if (frame > 13)
            {
                this.khopesh.GetComponent<Collider2D>().enabled = false;
            }
        }
        */

        if (action)
        {
            actionTick--;
            if (actionTick == 0)
            {
                action = false;
            }
        }
    }
}
