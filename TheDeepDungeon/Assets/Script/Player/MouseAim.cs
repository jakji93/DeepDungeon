using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        transform.position = new Vector2(mousePosition.x, mousePosition.y);
    }
}
