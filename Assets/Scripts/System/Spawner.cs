using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�� ����");
            GameManager.instance.poolManager.Get(0);
        }
    }
}
