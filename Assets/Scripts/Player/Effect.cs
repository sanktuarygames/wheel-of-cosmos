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
            case EffectEnum.Heal:
                Debug.Log("Heal");
                break;
            case EffectEnum.Cursed:
                Debug.Log("Cursed");
                break;
            case EffectEnum.Special:
                Debug.Log("Special");
                break;
            case EffectEnum.Super:
                Debug.Log("Super");
                break;
            case EffectEnum.Void:
                Debug.Log("Void");
                break;
            case EffectEnum.Normal:
                Debug.Log("Normal");
                break;
            default:
                Debug.Log("Default");
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