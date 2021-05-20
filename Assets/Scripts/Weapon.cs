using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float FIRE_RATE;
    public float BULLET_FORCE;

    public GameObject bullet;
    public GameObject bulletHole;

    private int fireTick = 0;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //firing
        fireTick++;
        if (fireTick >= 1000 / FIRE_RATE && Input.GetButton("Fire1"))
        {
            Fire();
            fireTick = 0;
        }
    }

    protected abstract void Fire();
}
