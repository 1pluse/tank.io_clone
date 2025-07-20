using UnityEngine;
using UnityEngine.UI;
public class UpGradeRankManager : MonoBehaviour
{
    [SerializeField] Image[] UpGradeRankImages;
    [SerializeField] StatUpGrade StatUpGrade;

    private void Awake()
    {
        StatUpGrade = GetComponentInParent<StatUpGrade>();
        UpGradeRankImages = transform.GetComponentsInChildren<Image>();
    }

    private void Start()
    {
        foreach (Image Rank in UpGradeRankImages)
        {
            Rank.enabled = false;
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < StatUpGrade.data.Level; i++)
        {
            UpGradeRankImages[i].enabled = true;
        }
    }
}
