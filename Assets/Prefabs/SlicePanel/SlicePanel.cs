using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicePanel : MonoBehaviour
{
    public SliceProperties editSlice = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPanel() {
        
    }

    public void SetEditSlice(SliceProperties slice) {
        editSlice.Change(slice.sliceType, slice.sliceEffectTextString, slice.sliceValue);
    }


}
