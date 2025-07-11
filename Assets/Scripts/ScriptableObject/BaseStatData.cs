using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseStat", menuName = "Scriptable Objects/BaseStat")]
public class BaseStatData : ScriptableObject
{
    public enum BaseStatype { EXP_GainAmount, HP, Speed, AttackDamage }
    [Header("Maininfo")]
    [SerializeField] BaseStatype Stattype;
    [SerializeField] int Id;
    [SerializeField] string StatName;
    [SerializeField] string StatExplane;
    [SerializeField] Sprite UpgradeIcon;

    [Header("UpgradeStat")]
    [SerializeField] float BaseStat;
    [SerializeField] float[] UpgradeStats;
}
    
