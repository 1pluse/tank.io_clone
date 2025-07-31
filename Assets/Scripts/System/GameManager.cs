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
    public GameObject levelUpPanel; // 스탯 선택 버튼들이 있는 부모 패널
    public List<BaseStatData> allStats; // 모든 종류의 BaseStatData 에셋 리스트
    public StatUpGrade[] upgradeButtons; // 3개의 스탯 버튼 (StatUpGrade 스크립트)
    private void Awake()
    {
        instance = this;
    }

    // 플레이어가 레벨업 했을 때 이 함수를 호출합니다.
    public void ShowRandomStatUpgrades()
    {
        // 1. 업그레이드 가능한 스탯 목록 만들기
        List<BaseStatData> availableUpgrades = new List<BaseStatData>();

        if (allStats.Count == 0)
        {
            Debug.LogError("GameManager의 'All Stats' 리스트가 비어있습니다! 인스펙터에서 모든 스탯 에셋을 추가해주세요.");
            return;
        }

        foreach (BaseStatData stat in allStats)
        {
            // 진단: 각 스탯의 현재 레벨과 최대 레벨을 확인합니다.
            if (playerStats.statLevels.ContainsKey(stat.StatType))
            {
                if (playerStats.statLevels[stat.StatType] < stat.UpgradeStats.Length)
                {
                    availableUpgrades.Add(stat);
                }
            }
            else
            {
                Debug.LogError($"'{stat.StatName}' 스탯이 Player의 statLevels 딕셔너리에 없습니다! Player.cs의 Awake()를 확인하세요.");
            }
        }

        if (availableUpgrades.Count == 0)
        {
            Debug.LogWarning("업그레이드할 스탯이 없습니다. 모든 스탯이 최대 레벨이거나 UpgradeStats 배열이 비어있을 수 있습니다.");
            levelUpPanel.SetActive(true); // 선택지가 없더라도 패널은 띄워서 확인
            return;
        }

        // 2. 후보 목록을 무작위로 섞기 (피셔-예이츠 셔플)
        for (int i = 0; i < availableUpgrades.Count; i++)
        {
            int rand = Random.Range(i, availableUpgrades.Count);
            BaseStatData temp = availableUpgrades[i];
            availableUpgrades[i] = availableUpgrades[rand];
            availableUpgrades[rand] = temp;
        }

        // 3. 3개의 버튼에 섞인 스탯 데이터를 할당
        int count = Mathf.Min(availableUpgrades.Count, upgradeButtons.Length);
        for (int i = 0; i < count; i++)
        {
            // 진단: 어떤 버튼에 어떤 스탯이 할당되는지 확인합니다.
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
