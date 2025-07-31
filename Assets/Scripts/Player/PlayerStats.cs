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
        // ���� ���� ������ ������
        int currentLevel = statLevels[data.StatType];

        // ���׷��̵��� �� �ִ� �ִ� �������� Ȯ��
        if (currentLevel >= data.UpgradeStats.Length)
        {
            Debug.LogWarning($"{data.StatName}��(��) �̹� �ִ� �����Դϴ�!");
            return;
        }

        // ������ �´� ���׷��̵� ��ġ�� ������
        float upgradeValue = data.UpgradeStats[currentLevel];

        // ���� Ÿ�Կ� ���� ���� �ɷ�ġ ����
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
                CurrentHp = MaxHp; // �ִ� ü�� ���׷��̵� �� ���� ü�µ� ȸ��
                break;
        }

        // �ش� ������ ������ 1 �������Ѽ� ����
        statLevels[data.StatType]++;
        Debug.Log($"{data.StatName} ���� ��! ���� ����: {statLevels[data.StatType]}, ����� ��: +{upgradeValue}");
    }

}
