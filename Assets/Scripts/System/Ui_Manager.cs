using TMPro;
using Unity.AppUI.UI;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] Font[] fonts;
    public GameObject SkillChooseBackGround;
    public bool GameFreeze;

    private void Awake()
    {
        SkillChooseBackGround = GameObject.Find("SkillChoosePanel");
    }
    private void Start()
    {
        foreach (Font font in fonts) { 
            font.material.mainTexture.filterMode = FilterMode.Point;
        }
        SkillChooseBackGround.SetActive(false);
    }

    private void Update()
    {
        LevelText.text = "LV:" + GameManager.instance.player.Level;
        if (SkillChooseBackGround.activeSelf) { 
            GameFreeze = true;
        }
        else
        {
            GameFreeze = false;
        }
    }
}
