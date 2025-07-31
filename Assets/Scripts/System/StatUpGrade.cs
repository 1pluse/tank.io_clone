using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUpGrade : MonoBehaviour
{
    // �ν����Ϳ��� ���� ������ UI ��ҵ�
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    private BaseStatData data;

    // ��� ���� ���� ǥ�ÿ� ��ũ��Ʈ�� ���� ����
    private UpGradeRankManager upgradeStatLevelDisplay;

    private void Awake()
    {
        // �� ���ӿ�����Ʈ�� �پ��ִ� UpgradeStatLevel ������Ʈ�� ã�ƿɴϴ�.
        upgradeStatLevelDisplay = GetComponent<UpGradeRankManager>();
    }

    // GameManager�� ȣ���� �Լ�
    public void SetStat(BaseStatData newData)
    {
        this.data = newData;
        UpdateUI();
    }

    // UI ��ҵ��� �����Ϳ� �°� �����ϴ� �Լ�
    private void UpdateUI()
    {
        if (data == null) return;

        iconImage.sprite = data.Icon;
        nameText.text = data.StatName;

        PlayerStats player = GameManager.instance.playerStats;
        int currentLevel = player.statLevels[data.StatType];

        // �ڡ� �߰��� �κ� �ڡ�
        // ���� ǥ�� ��ũ��Ʈ���� ���� ������ �˷��ְ� UI ������ ��û�մϴ�.
        upgradeStatLevelDisplay.UpdateLevelDisplay(currentLevel);   

        if (currentLevel >= data.UpgradeStats.Length)
        {
            descriptionText.text = "�ִ� ����";
        }
        else
        {
            float nextUpgradeValue = data.UpgradeStats[currentLevel];
            descriptionText.text = string.Format(data.StatDiscription, nextUpgradeValue);
        }
    }

    // ��ư Ŭ�� �� ȣ��� �Լ�
    public void ChooseThisStat()
    {
        if (data == null) return;
        GameManager.instance.GameFreeze = false; 
        GameManager.instance.playerStats.UpgradeStat(data);
        GameManager.instance.levelUpPanel.SetActive(false);
    }
}