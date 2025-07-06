using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    [SerializeField] Font[] fonts;
    private void Start()
    {
        foreach (Font font in fonts) { 
            font.material.mainTexture.filterMode = FilterMode.Point;
        }
    }
}
