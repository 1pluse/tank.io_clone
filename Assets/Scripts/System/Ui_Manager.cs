using TMPro;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] Font[] fonts;
    private void Start()
    {
        foreach (Font font in fonts) { 
            font.material.mainTexture.filterMode = FilterMode.Point;
        }
    }

    private void Update()
    {
        LevelText.text = "LV:" + GameManager.instance.player.Level; 
    }
}
