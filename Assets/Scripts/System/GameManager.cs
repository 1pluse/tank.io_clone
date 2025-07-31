using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerStats playerStats;
    public PlayerMoveControll player;
    public PoolManager poolManager; 
    public Ui_Manager Ui_Manager;
    public bool GameFreeze;

    [Header("Level Up UI")]
    public GameObject levelUpPanel; // ���� ���� ��ư���� �ִ� �θ� �г�
    public List<BaseStatData> allStats; // ��� ������ BaseStatData ���� ����Ʈ
    public StatUpGrade[] upgradeButtons; // 3���� ���� ��ư (StatUpGrade ��ũ��Ʈ)
    private void Awake()
    {
        instance = this;
    }

    // �÷��̾ ������ ���� �� �� �Լ��� ȣ���մϴ�.
    public void ShowRandomStatUpgrades()
    {
        // 1. ���׷��̵� ������ ���� ��� �����
        List<BaseStatData> availableUpgrades = new List<BaseStatData>();

        if (allStats.Count == 0)
        {
            Debug.LogError("GameManager�� 'All Stats' ����Ʈ�� ����ֽ��ϴ�! �ν����Ϳ��� ��� ���� ������ �߰����ּ���.");
            return;
        }

        foreach (BaseStatData stat in allStats)
        {
            // ����: �� ������ ���� ������ �ִ� ������ Ȯ���մϴ�.
            if (playerStats.statLevels.ContainsKey(stat.StatType))
            {
                if (playerStats.statLevels[stat.StatType] < stat.UpgradeStats.Length)
                {
                    availableUpgrades.Add(stat);
                }
            }
            else
            {
                Debug.LogError($"'{stat.StatName}' ������ Player�� statLevels ��ųʸ��� �����ϴ�! Player.cs�� Awake()�� Ȯ���ϼ���.");
            }
        }

        if (availableUpgrades.Count == 0)
        {
            Debug.LogWarning("���׷��̵��� ������ �����ϴ�. ��� ������ �ִ� �����̰ų� UpgradeStats �迭�� ������� �� �ֽ��ϴ�.");
            levelUpPanel.SetActive(true); // �������� ������ �г��� ����� Ȯ��
            return;
        }

        // 2. �ĺ� ����� �������� ���� (�Ǽ�-������ ����)
        for (int i = 0; i < availableUpgrades.Count; i++)
        {
            int rand = Random.Range(i, availableUpgrades.Count);
            BaseStatData temp = availableUpgrades[i];
            availableUpgrades[i] = availableUpgrades[rand];
            availableUpgrades[rand] = temp;
        }

        // 3. 3���� ��ư�� ���� ���� �����͸� �Ҵ�
        int count = Mathf.Min(availableUpgrades.Count, upgradeButtons.Length);
        for (int i = 0; i < count; i++)
        {
            // ����: � ��ư�� � ������ �Ҵ�Ǵ��� Ȯ���մϴ�.
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].SetStat(availableUpgrades[i]);
        }

        for (int i = count; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
        GameFreeze = true;
    }
}
