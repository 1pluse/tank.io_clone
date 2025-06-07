using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
            
        for (int i = 0; i < pools.Length; i++) { 
        pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int i)
    {
        GameObject select = null;
        foreach (GameObject prefab in pools[i]) {
            if (!prefab.activeSelf)
            {
                select = prefab;
                select.SetActive(true);
                break;
            }
        }

        if (!select) { 
            select = Instantiate(prefabs[i],transform);
            pools[i].Add(select);
        }
        return select;
    }
}
