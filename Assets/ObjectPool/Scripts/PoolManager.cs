using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PoolManager();
            }
            return instance;
        }
    }

    Dictionary<string, ObjectPool> poolDict = new Dictionary<string, ObjectPool>();

    public GameObject GetObject(string poolName)
    {
        if (!poolDict.ContainsKey(poolName))
        {
            poolDict.Add(poolName, new ObjectPool());            
        }
        ObjectPool pool = poolDict[poolName];
        return pool.GetObject(poolName);
    }

    //------------replace foreach with for-----------------------
    //List<string> poolDictKeyList = new List<string>();

    //public void HideObject(GameObject go)
    //{
    //    poolDictKeyList = new List<string>(poolDict.Keys);
    //    for (int i = 0; i < poolDictKeyList.Count; i++)
    //    {
    //        if (poolDict[poolDictKeyList[i]].Contains(go))
    //        {
    //            poolDict[poolDictKeyList[i]].HideObject(go);
    //            return;
    //        }
    //    }
    //}

    public void HideObject(GameObject go)
    {
        foreach (ObjectPool p in poolDict.Values)
        {
            if (p.Contains(go))
            {
                p.HideObject(go);
                return;
            }
        }
    }

    public void HideAllObject(string poolName)
    {
        if (!poolDict.ContainsKey(poolName))
        {
            return;
        }
        ObjectPool pool = poolDict[poolName];
        pool.HideAllObject();
    }
}
