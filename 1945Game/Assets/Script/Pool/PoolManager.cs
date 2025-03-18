using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PoolManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("PoolManager");
                    instance = go.AddComponent<PoolManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private Dictionary<string, ObjectPool> pools = new Dictionary<string, ObjectPool>();

    public void CreatePool(GameObject prefab, int initialSize)
    {
        string key = prefab.name;
        if (!pools.ContainsKey(key))
        {
            pools.Add(key, new ObjectPool(prefab, initialSize, transform));
        }
    }

    public GameObject Get(GameObject prefab)
    {
        string key = prefab.name;
        if (!pools.ContainsKey(key))
        {
            CreatePool(prefab, 10);
        }
        return pools[key].Get();
    }

    public void Return(GameObject obj)
    {
        string key = obj.name.Replace("(Clone)", "").Trim();
        if (pools.ContainsKey(key))
        {
            pools[key].Return(obj);
        }
        else
        {
            Debug.LogWarning($"[PoolManager] '{key}' 풀을 찾을 수 없습니다. 오브젝트를 제거합니다.");
            Destroy(obj);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
