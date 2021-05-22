using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float cameraSpeed = 0.1f;
    public Animator camAnim;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent.position = player.transform.position;
    }

    void FixedUpdate()
    {
        Vector2 finalPosition = player.transform.position;
        Vector2 lerpPosition = Vector2.Lerp(this.transform.parent.position, finalPosition, cameraSpeed);
        this.transform.parent.position = new Vector3(lerpPosition.x, lerpPosition.y, -10);
    }

    public void Shake()
    {
        camAnim.SetTrigger("shake");
    }
}
