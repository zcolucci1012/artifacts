using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float SPEED = 7.5f;
    private Vector2 movement;
    private float friction = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        
        
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
    }
}
