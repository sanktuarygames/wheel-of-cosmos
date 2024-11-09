using UnityEngine;

public class InformationDisplayMaster : MonoBehaviour
{
    public static InformationDisplayMaster instance { get; private set; }

    void Awake()
    {
        instance = this;
        if (instance != this)
        {
            Destroy(this);
        }
    }

    public void DisplayInformation()
    {
        Debug.Log("Displaying Information");
    }

    public void HideInformation()
    {
        Debug.Log("Hiding Information");
    }
}
