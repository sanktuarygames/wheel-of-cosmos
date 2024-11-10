using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class ArsenalDisplay : MonoBehaviour
{
    public static ArsenalDisplay instance { get; private set; }
    [Header("Arsenal")]
    public GameObject arsenalSlicePrefab;
    public List<SliceArsenal> arsenalSlices;
    public Transform arsenalSlicesParent;

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    void Start()
    {
        Initialize();
    }

    public void SetupDisplay(Arsenal arsenal)
    {
        Initialize();
        foreach (Slice sliceArsenal in arsenal.currentSlices)
        {
            AddSliceArsenal(sliceArsenal);
        }
        UpdateDisplay();
    }

    public void Initialize()
    {
        arsenalSlices = new List<SliceArsenal>();
    }

    public void AddSliceArsenal(Slice sliceArsenal)
    {
        SliceArsenal newSliceArsenal = Instantiate(arsenalSlicePrefab, arsenalSlicesParent).GetComponent<SliceArsenal>();
        newSliceArsenal.slice = sliceArsenal;
        arsenalSlices.Add(newSliceArsenal);
    }

    public void UpdateDisplay() {
        foreach (SliceArsenal sliceArsenal in arsenalSlices)
        {
            sliceArsenal.LoadDisplay();
        }
    }

    public void RemoveSliceArsenal(SliceArsenal sliceArsenal)
    {
        arsenalSlices.Remove(sliceArsenal);
        Destroy(sliceArsenal.gameObject);
    }
}