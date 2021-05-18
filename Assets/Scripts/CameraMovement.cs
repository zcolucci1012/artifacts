using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float cameraSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = player.transform.position;
    }

    void FixedUpdate()
    {
        Vector2 finalPosition = player.transform.position;
        Vector2 lerpPosition = Vector2.Lerp(this.transform.position, finalPosition, cameraSpeed);
        this.transform.position = new Vector3(lerpPosition.x, lerpPosition.y, -10);
    }
}
