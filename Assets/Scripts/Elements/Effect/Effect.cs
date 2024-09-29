using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "Elements/Effect", order = 1)]
public class Effect : ScriptableObject
{
    public string display;
    public string description;
    public string target;   // Can be a character, slice or arrow
}