using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int[] LAYERS_TO_HIT;

    void Awake()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int ii = 0; ii < LAYERS_TO_HIT.Length; ii++)
        {
            if (collision.gameObject.layer == LAYERS_TO_HIT[ii])
            {
                //do something later
            }
        }

        Destroy(this.gameObject);
    }
}
