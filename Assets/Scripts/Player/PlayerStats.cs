using UnityEngine;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    public Dictionary<BaseStatData.BaseStatype, int> statLevels;

    public float Speed;
    int MaxExp_Increase;
    public float CurrentHp;
    public float MaxHp;
    public int Level;
    public float CurrentExp;
    public float MaxExp;
    public float AttackDamage;
    public float Exp_CollectAmount = 1f;

    private void Awake()
    {
        statLevels = new Dictionary<BaseStatData.BaseStatype, int>();
        foreach (BaseStatData.BaseStatype stattype in System.Enum.GetValues(typeof(BaseStatData.BaseStatype)))
        {
            statLevels.Add(stattype, 0);    
        }
    }
    private void Start()
    {
        this.CurrentHp = this.MaxHp;
        this.CurrentExp = 0;
    }

    private void Update()
    {
        HpManager();
        ExpManager();
    }

    void HpManager()
    {
        if (this.CurrentHp <= 0)
            Destroy(gameObject);
    }

    void ExpManager()
    {
        if (CurrentExp >= MaxExp)
        {
            CurrentExp -= CurrentExp;
            GameManager.instance.ShowRandomStatUpgrades();
            GameManager.instance.Ui_Manager.SkillChooseBackGround.gameObject.SetActive(true);
            Level++;
            MaxExp_Increase += 15;
            MaxExp += Level * MaxExp_Increase;
        }
    }
    public void TakeDamage(float damage)
    {
        this.CurrentHp -= damage;
    }

    public void UpgradeStat(BaseStatData data)
    {
        // 현재 스탯 레벨을 가져옴
        int currentLevel = statLevels[data.StatType];

        // 업그레이드할 수 있는 최대 레벨인지 확인
        if (currentLevel >= data.UpgradeStats.Length)
        {
            Debug.LogWarning($"{data.StatName}은(는) 이미 최대 레벨입니다!");
            return;
        }

        // 레벨에 맞는 업그레이드 수치를 가져옴
        float upgradeValue = data.UpgradeStats[currentLevel];

        // 스탯 타입에 따라 실제 능력치 적용
        switch (data.StatType)
        {
            case BaseStatData.BaseStatype.AttackDamage:
                AttackDamage += upgradeValue;
                break;
            case BaseStatData.BaseStatype.EXP_GainAmount:
                Exp_CollectAmount += upgradeValue;
                break;
            case BaseStatData.BaseStatype.Speed:
                Speed += upgradeValue;
                break;
            case BaseStatData.BaseStatype.MaxHP:
                MaxHp += upgradeValue;
                CurrentHp = MaxHp; // 최대 체력 업그레이드 시 현재 체력도 회복
                break;
        }

        // 해당 스탯의 레벨을 1 증가시켜서 저장
        statLevels[data.StatType]++;
        Debug.Log($"{data.StatName} 레벨 업! 현재 레벨: {statLevels[data.StatType]}, 적용된 값: +{upgradeValue}");
    }

}
