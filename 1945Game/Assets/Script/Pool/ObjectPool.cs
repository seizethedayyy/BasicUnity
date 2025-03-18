using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool
{
    private GameObject prefab;
    private Queue<GameObject> pool;
    private Transform parent;

    public ObjectPool(GameObject prefab, int initialSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;
        pool = new Queue<GameObject>();

        for (int i = 0; i < initialSize; i++)
        {
            CreateNewObject();
        }
    }

    private void CreateNewObject()
    {
        GameObject obj = GameObject.Instantiate(prefab, parent);
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public GameObject Get()
    {
        if (pool.Count == 0)
        {
            CreateNewObject();
        }

        GameObject obj = pool.Dequeue();
        obj.SetActive(true);

        // 활성화될 때 초기화 가능
        IPoolable poolable = obj.GetComponent<IPoolable>();
        if (poolable != null)
        {
            poolable.OnSpawn();
        }

        return obj;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
