using UnityEngine;

public class Effect : MonoBehaviour
{
    public EffectEnum effect;
    public void TriggerEffect()
    {
        switch (effect)
        {
            case EffectEnum.Attack:
                Debug.Log("Attack");
                break;
            case EffectEnum.Armor:
                Debug.Log("Armor");
                break;
            case EffectEnum.Vitality:
                Debug.Log("Vitality");
                break;
            case EffectEnum.DrainVitality:
                Debug.Log("DrainVitality");
                break;
            case EffectEnum.AttackArmor:
                Debug.Log("AttackArmor");
                break;
            case EffectEnum.AttackVitality:
                Debug.Log("AttackVitality");
                break;
            case EffectEnum.ArmorVitality:
                Debug.Log("ArmorVitality");
                break;
            case EffectEnum.Reveal:
                Debug.Log("Reveal");
                break;
            
            case EffectEnum.Void:
            default:
                Debug.Log("Void");
                break;
        }
    }
}

public enum EffectEnum
{
    // Applied to self or other characters
    // Red
    Attack,
    // Blue
    Armor,
    // Green
    Vitality,
    DrainVitality,
    // Pink
    AttackArmor,
    AttackVitality,
    ArmorVitality,
    Reveal,
    Steal,
    // Cursed
    LoseVitality,
    LoseArmor,
    LoseAttack,
    // Stellar
    UpgradeArrowExplosion,  // (Mony)
    Explode, // (Mony)
    KeepArrow, // (Mony)
    RedJackpot, // (Halfy) Combines 2 effects: DrainVitality, UpgradeOnTriggerRed, 
    KeepPink, // (BoobleGun) [wip]
    KeepCursed, // (Handam) [wip]
    Void,

    // Applied to other slices
    BlockRed,
    BlockBlue,
    BlockGreen,
    BlockPink,
    BlockCursed,
    BlockStellar,
    BlockAll,
    TriggerRed,
    TriggerBlue,
    TriggerGreen,
    TriggerPink,
    TriggerCursed,
    TriggerStellar,
    UpgradeRed,
    UpgradeBlue,
    UpgradeGreen,
    UpgradePink,
    UpgradeCursed,
    UpgradeStellar,
    UpgradeAll,
}

public enum Conditions 
{
    // Conditions
    LootOnDeath,
    ArrowsOnDeath,
    SlicesOnDeath,
    UpgradeOnTriggerRed,
    UpgradeOnTriggerBlue,
    UpgradeOnTriggerGreen,
    UpgradeOnTriggerPink,
    UpgradeOnTriggerCursed,
    UpgradeOnTriggerStellar,
    KeepCursed,
}