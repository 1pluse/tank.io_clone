using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Àû »ý¼º");
            GameManager.instance.poolManager.Get(0);
        }
    }
}
