using UnityEngine;
using UnityEngine.UI;
public class UpGradeRankManager : MonoBehaviour
{
    // 인스펙터에서 5개의 레벨 표시용 게임오브젝트(이미지)를 연결할 배열
    public GameObject[] levelImages;

    // 현재 레벨에 맞춰 이미지를 켜고 끄는 함수
    public void UpdateLevelDisplay(int currentLevel)
    {
        // levelImages 배열에 있는 모든 이미지를 순회합니다.
        for (int i = 0; i < levelImages.Length; i++)
        {
            // i가 현재 레벨보다 작으면(예: 레벨 2일 때 i가 0, 1) 이미지를 활성화합니다.
            if (i < currentLevel)
            {
                levelImages[i].SetActive(true);
            }
            // 그렇지 않으면(i가 현재 레벨보다 크거나 같으면) 이미지를 비활성화합니다.
            else
            {
                levelImages[i].SetActive(false);
            }
        }
    }
}
