using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceGenerator : MonoBehaviour
{
    public GameObject slicePrefab;
    public GameObject sliceParent;
    
    public void Generate()
    {
        GameObject slice = Instantiate(slicePrefab, sliceParent.transform);
    }
}
