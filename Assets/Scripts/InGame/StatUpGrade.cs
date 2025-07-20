using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    private void LateUpdate()
    {
        if (icon == null || Name == null || Description == null)
            return;
    }

    public void ChooseStat(GameObject skillchoosbutton)
    {
        data.Level++;
        GameObject SkillChoosePanel = transform.parent.gameObject;
        SkillChoosePanel.SetActive(false);
    }
}
