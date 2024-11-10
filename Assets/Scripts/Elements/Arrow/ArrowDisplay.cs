using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ArrowDisplay : MonoBehaviour
{
    [Header("Arrow")]
    public Arrow currentArrow;

    // Only used for inventory arrows. Remove in future TODO
    public void SetupDisplay() {
        currentArrow = GetComponent<Arrow>();
        GetComponent<MeshRenderer>().material = currentArrow.currentType.material;
    }
    public void SetupDisplay(Arrow arrow)
    {
        currentArrow = arrow;
        GetComponent<MeshRenderer>().material = arrow.currentType.material;
    }

    public void SetDefaultDisplay() {
        GetComponent<MeshRenderer>().material = currentArrow.arrowSO.type.material;
    }

    public void SetVoidDisplay() {
        GetComponent<MeshRenderer>().material = currentArrow.arrowSO.type.material;
    }

    public Slice GetSelectedSlice() {
        return new Slice();
    }
}