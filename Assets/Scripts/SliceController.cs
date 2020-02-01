using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceController : MonoBehaviour
{

    private Rigidbody2D bladeBody;
    private Collider2D collider;

    private Vector3 lastBladePosition;
    private float minSpeed = 0.1F;

    void Awake()
    {
        bladeBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        collider.enabled = IsBladeMoving();
        Slice();
    }

    private void Slice()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        bladeBody.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private bool IsBladeMoving()
    {
        Vector3 currentBladePosition = transform.position;
        float isMoving = (lastBladePosition - currentBladePosition).magnitude;
        lastBladePosition = currentBladePosition;

        return isMoving > minSpeed;
    }
}
