using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "Player/Effect", order = 1)]
public class EffectSO : ScriptableObject
{
    public string display;
    public string description;
    public string target;   // Can be any character, slice or arrow
    public Effect effect;
}