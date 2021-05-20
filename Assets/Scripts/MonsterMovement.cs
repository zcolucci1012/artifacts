using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float SPEED = 7.5f;
    public GameObject khopesh;
    public GameObject hand;

    private Vector2 movement;
    private float friction = 0.25f;
   
    private bool action = false;
    private int actionTick = 0;

    private bool slashing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0)
        {
            this.transform.localScale = new Vector3(Mathf.Sign(movement.x), 1, 1);
        }

        if (action || actionTick > 0)
        {

        }
        else if (Input.GetButtonDown("Fire1"))
        {
            action = true;
            slashing = true;
            actionTick = 50;
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

        if (slashing)
        {

        }
    }
}
