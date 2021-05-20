using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon
{
    protected override void Fire()
    {
        GameObject newBullet = Instantiate(this.bullet);
        newBullet.transform.position = this.bulletHole.transform.position;
        newBullet.GetComponent<Rigidbody2D>().AddForce(BULLET_FORCE * 
            this.transform.right);

    }
}
