using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUpGrade : MonoBehaviour
{
    // 인스펙터에서 직접 연결할 UI 요소들
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    private BaseStatData data;

    // 방금 만든 레벨 표시용 스크립트를 담을 변수
    private UpGradeRankManager upgradeStatLevelDisplay;

    private void Awake()
    {
        // 이 게임오브젝트에 붙어있는 UpgradeStatLevel 컴포넌트를 찾아옵니다.
        upgradeStatLevelDisplay = GetComponent<UpGradeRankManager>();
    }

    // GameManager가 호출할 함수
    public void SetStat(BaseStatData newData)
    {
        this.data = newData;
        UpdateUI();
    }

    // UI 요소들을 데이터에 맞게 갱신하는 함수
    private void UpdateUI()
    {
        if (data == null) return;

        iconImage.sprite = data.Icon;
        nameText.text = data.StatName;

        PlayerStats player = GameManager.instance.playerStats;
        int currentLevel = player.statLevels[data.StatType];

        // ★★ 추가된 부분 ★★
        // 레벨 표시 스크립트에게 현재 레벨을 알려주고 UI 갱신을 요청합니다.
        upgradeStatLevelDisplay.UpdateLevelDisplay(currentLevel);   

        if (currentLevel >= data.UpgradeStats.Length)
        {
            descriptionText.text = "최대 레벨";
        }
        else
        {
            float nextUpgradeValue = data.UpgradeStats[currentLevel];
            descriptionText.text = string.Format(data.StatDiscription, nextUpgradeValue);
        }
    }

    // 버튼 클릭 시 호출될 함수
    public void ChooseThisStat()
    {
        if (data == null) return;
        GameManager.instance.GameFreeze = false; 
        GameManager.instance.playerStats.UpgradeStat(data);
        GameManager.instance.levelUpPanel.SetActive(false);
    }
}