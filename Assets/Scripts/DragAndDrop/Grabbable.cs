using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Grabbable : MonoBehaviour
{
    [Header("Grab Properties")]
    public bool isGrabbed = false;
    public Vector2 xGrabBoundaries = new Vector2(2f, 20f);
    public Vector2 yGrabBoundaries = new Vector2(-20f, 3f);
    public Vector2 zGrabBoundaries = new Vector2(-4f, 4f);


    [Header("Position Properties")]
    public DropZone closestPosition = null;
    public float positionMaxDistance = 20f;
    public string dropZoneTag = "SliceDropZone";
    DropZoneController dropZoneController;
    Transform cosmos;
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cosmos = GameObject.Find("Cosmos").transform;
        dropZoneController = GameObject.FindWithTag(dropZoneTag).GetComponent<DropZoneController>();
    }

    void Update()
    {
        if (isGrabbed)
        {
            dropZoneController.UnhighlightAllDropZones();
            dropZoneController.HighlightClosestDropZone(transform.position);
        }

        if (!rb.isKinematic) LimitPositionToBoundaries();
    }

    public void LimitPositionToBoundaries()
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

    public void Drop()
    {
        // Debug.Log("Dropped");
        closestPosition = dropZoneController.GetClosestDropZone(transform.position);
        if (closestPosition != null)
        {
            // Debug.Log("Dropped in: " + closestPosition.name);
            closestPosition.Unhighlight();
            rb.velocity = Vector3.zero;
            closestPosition.AddSlice(gameObject);
        }
    }

    public void Grab()
    {
        // Debug.Log("Grabbed");
        isGrabbed = true;
        rb.isKinematic = false;
        if (transform.parent.GetComponent<DropZone>() != null)
        {
            transform.parent.GetComponent<DropZone>().RemoveSlice();
        }
    }
}
