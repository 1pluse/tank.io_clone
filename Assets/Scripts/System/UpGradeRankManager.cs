using UnityEngine;
using UnityEngine.UI;
public class UpGradeRankManager : MonoBehaviour
{
    // �ν����Ϳ��� 5���� ���� ǥ�ÿ� ���ӿ�����Ʈ(�̹���)�� ������ �迭
    public GameObject[] levelImages;

    // ���� ������ ���� �̹����� �Ѱ� ���� �Լ�
    public void UpdateLevelDisplay(int currentLevel)
    {
        // levelImages �迭�� �ִ� ��� �̹����� ��ȸ�մϴ�.
        for (int i = 0; i < levelImages.Length; i++)
        {
            // i�� ���� �������� ������(��: ���� 2�� �� i�� 0, 1) �̹����� Ȱ��ȭ�մϴ�.
            if (i < currentLevel)
            {
                levelImages[i].SetActive(true);
            }
            // �׷��� ������(i�� ���� �������� ũ�ų� ������) �̹����� ��Ȱ��ȭ�մϴ�.
            else
            {
                levelImages[i].SetActive(false);
            }
        }
    }
}
