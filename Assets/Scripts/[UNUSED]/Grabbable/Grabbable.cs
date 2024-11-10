using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Grabbable : MonoBehaviour, IGrabbable
{
    [Header("Grab Properties")]
    public bool isGrabbed = false;
    public float dragForce = 20f;
    public Vector3 offsetGrabPosition = new Vector3(0f, 0f, 5f);
    public Vector2 xGrabBoundaries = new Vector2(-15f, 20f);
    public Vector2 yGrabBoundaries = new Vector2(0f, 7.5f);
    public Vector2 zGrabBoundaries = new Vector2(-8f, 8f);
    private Rigidbody rb;


    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Update()
    {
        if (isGrabbed)
        {
            Drag();
            LimitPositionToBoundaries();
        }
    }

    public virtual void Drag() {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z) + offsetGrabPosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);


        if (Vector3.Distance(transform.position, worldPosition) < 0.1f)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }
        // Calculate the direction from the transform position to the position
        Vector3 direction = worldPosition - transform.position;
        direction = direction.normalized;
        if (transform.position.y > GetComponent<Grabbable>().yGrabBoundaries.x && transform.position.y < GetComponent<Grabbable>().yGrabBoundaries.y)
        {
            direction.y = 1.2f;
        }
        GetComponent<Rigidbody>().velocity = direction * dragForce;
    }

    public virtual void LimitPositionToBoundaries()
    {
        if (transform.position.x < xGrabBoundaries.x)
        {
            transform.position = new Vector3(xGrabBoundaries.x, transform.position.y, transform.position.z);
            rb.velocity = Vector3.zero;
        }
        else if (transform.position.x > xGrabBoundaries.y)
        {
            transform.position = new Vector3(xGrabBoundaries.y, transform.position.y, transform.position.z);
            rb.velocity = Vector3.zero;
        }
        if (transform.position.y < yGrabBoundaries.x)
        {
            transform.position = new Vector3(transform.position.x, yGrabBoundaries.x, transform.position.z);
            rb.velocity = Vector3.zero;
        }
        else if (transform.position.y > yGrabBoundaries.y)
        {
            transform.position = new Vector3(transform.position.x, yGrabBoundaries.y, transform.position.z);
            rb.velocity = Vector3.zero;
        }
        if (transform.position.z < zGrabBoundaries.x)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zGrabBoundaries.x);
            rb.velocity = Vector3.zero;
        }
        else if (transform.position.z > zGrabBoundaries.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zGrabBoundaries.y);
            rb.velocity = Vector3.zero;
        }
    }

    public virtual void Drop()
    {
        Cursor.visible = true;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        isGrabbed = false;
    }

    public virtual void Grab()
    {
        Cursor.visible = false;
        isGrabbed = true;
        rb.isKinematic = false;
    }
}
