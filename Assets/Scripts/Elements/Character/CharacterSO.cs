using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Elements/Character", order = 1)]
public class CharacterSO : ScriptableObject
{
    public string title;
    public string description;
    public WheelSO initialWheelPrefab;
    public ArrowSO[] initialArrows;
    public Inventory initialInventoryPrefab;
    public int initialHealth = 15;
    public int initialMaxHealth = 15;
    public int initialArmor = 0;
    public int initialMaxArmor = 0;
    public Effect[] effects;
}
