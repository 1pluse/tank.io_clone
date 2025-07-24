using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static BaseStatData;

public class StatUpGrade : MonoBehaviour
{
    public BaseStatData data;
    Image icon;
    TextMeshProUGUI Name;
    TextMeshProUGUI Description;
    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.Icon;

        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        Name = texts[0];
        Description = texts[1];
        Name.text = data.StatName;
        data.Reset();
    }

    private void OnEnable()
    {
        Description.text = string.Format(data.StatDiscription, data.UpgradeStats[data.Level]);    
    }

    public void ChooseStat(GameObject skillchoosbutton)
    {
        StatUpGrade statUpGrade = skillchoosbutton.GetComponentInChildren<StatUpGrade>();
        Player player = GameManager.instance.player;
        switch (statUpGrade.data.StatType) {
            case BaseStatype.AttackDamage:
               player.AttackDamage += data.UpgradeStats[data.Level];
                Debug.Log(GameManager.instance.player.AttackDamage);
                break;

            case BaseStatype.EXP_GainAmount:
                player.Exp_CollectAmount += data.UpgradeStats[data.Level];
                Debug.Log(GameManager.instance.player.Exp_CollectAmount);
                break;

            case BaseStatype.Speed:
                player.Speed += data.UpgradeStats[data.Level];
                Debug.Log(GameManager.instance.player.Speed);
                break;

            case BaseStatype.MaxHP:
                player.MaxHp += data.UpgradeStats[data.Level];
                Debug.Log(GameManager.instance.player.MaxHp);
                break;
        }
        data.Level++;
        GameObject SkillChoosePanel = transform.parent.gameObject;
        SkillChoosePanel.SetActive(false);  
    }
}
