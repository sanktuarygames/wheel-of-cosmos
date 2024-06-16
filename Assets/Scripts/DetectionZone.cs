using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class DetectionZone : MonoBehaviour
{

    [Header("Tags")]
    public string[] tagFilter = { "Player", "Ball" };

    [SerializeField, Tooltip("If empty, all tags are accepted")]
    string[] Tags { get => tagFilter; }

    [Header("Layers")]
    [SerializeField] LayerMask[] layersToFilter;



    [Header("Events")]
    [SerializeField] protected UnityEvent onFirstEnter = default, onLastExit = default;
    protected List<Collider> colliders = new List<Collider>();


    private void Awake()
    {
        enabled = false;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            if (!colliders[i] || !colliders[i].gameObject.activeSelf)
            {
                colliders.RemoveAt(i--);
                if (colliders.Count == 0)
                {
                    onLastExit.Invoke();
                    enabled = false;
                }
            }
        }
    }

    virtual public void OnTriggerEnter(Collider other)
    {

        bool hasValidTag = Tags.Length <= 0 || CheckColliderHasValidTag(other);
        bool hasValidLayer = layersToFilter.Length <= 0 || CheckColliderHasValidLayer(other);

        // OR
        // Collider must have tag or be in layer.
        if (!hasValidTag && !hasValidLayer)
        {
            return;
        }

        /* 
        // AND
        // Collider must have tag and be in layer.
        if(!hasValidTag || !hasValidLayer)
        {
            return;
        } */

        if (colliders.Count == 0)
        {
            onFirstEnter.Invoke();
            enabled = true;
        }
        colliders.Add(other);
    }

    virtual public void OnTriggerStay(Collider other)
    {
        return;
    }

    virtual public void OnTriggerExit(Collider other)
    {
        if (colliders.Remove(other) && colliders.Count == 0)
        {
            onLastExit.Invoke();
            enabled = false;
        }
    }

    private void OnDisable()
    {
#if UNITY_EDITOR
        if (enabled && gameObject.activeInHierarchy)
        {
            return;
        }
#endif
        if (colliders.Count > 0)
        {
            colliders.Clear();
            onLastExit.Invoke();
        }
    }

    private bool CheckColliderHasValidTag(Collider collider)
    {
        foreach (string tag in Tags)
        {
            if (collider.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckColliderHasValidLayer(Collider collider)
    {
        foreach (LayerMask layer in layersToFilter)
        {
            //if (collider.gameObject.layer == layer.value)
            if (((1 << collider.gameObject.layer) & layer.value) != 0)
            {
                return true;
            }
        }
        return false;
    }
}
