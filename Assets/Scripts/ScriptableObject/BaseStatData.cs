using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BaseStat", menuName = "Scriptable Objects/BaseStat")]
public class BaseStatData : ScriptableObject
{
    public enum BaseStatype { EXP_GainAmount, MaxHP, Speed, AttackDamage }
    [Header("Maininfo")]
    public BaseStatype StatType;
    public int Id;
    public int Level;
    public string StatName;
    [TextArea]
    public string StatDiscription;
    public Sprite Icon;

    [Header("UpgradeStat")]
    public float BaseStat;
    public float[] UpgradeStats;

    public void Reset()
    {
        Level = 0;
    }
}
    
