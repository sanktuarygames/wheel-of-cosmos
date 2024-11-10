using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ArrowDisplay : MonoBehaviour
{
    [Header("Arrow")]
    public Arrow currentArrow;

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
        currentArrow = new Arrow();
        currentArrow.Initialize(Resources.Load<ArrowSO>("ScriptableObjects/Types/Arrows/Normal"));
        GetComponent<MeshRenderer>().material = currentArrow.arrowSO.type.material;
    }

    public Slice GetSelectedSlice() {
        return new Slice();
    }
}