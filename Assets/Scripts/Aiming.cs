using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //pointing the hand
        Vector2 m = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 dir = m - (Vector2)cam.WorldToScreenPoint(this.transform.parent.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * 180 / Mathf.PI;
        this.transform.eulerAngles = new Vector3(0, 0, angle);
        this.transform.parent.localScale = new Vector3(Mathf.Sign(dir.x), 1, 1);
        this.transform.localScale = new Vector3(Mathf.Sign(dir.x), Mathf.Sign(dir.x), 1);
    }
}
