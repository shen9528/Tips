using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResManager
{
    static ResManager instance;
    public static ResManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ResManager();
            }
            return instance;
        }
    }

    Dictionary<string, Object> loadedPrefabDict = new Dictionary<string, Object>();

    public Object LoadPrefab(string prefabName)
    {
        if (string.IsNullOrEmpty(prefabName))
        {
            return null;
        }
        else if (loadedPrefabDict.ContainsKey(prefabName))
        {
            return loadedPrefabDict[prefabName];
        }
        else
        {
            Object prefab = Resources.Load(prefabName);
            loadedPrefabDict.Add(prefabName, prefab);
            return loadedPrefabDict[prefabName];
        }
    }

    public void UnloadPrefab(string prefabName)
    {
        if (loadedPrefabDict.ContainsKey(prefabName))
        {
            return;
        }
        else
        {
            Resources.UnloadAsset(loadedPrefabDict[prefabName]);
            loadedPrefabDict[prefabName] = null;
            loadedPrefabDict.Remove(prefabName);
        }
    }

    public void UnloadAll()
    {
        foreach (KeyValuePair<string, Object> kv in loadedPrefabDict)
        {
            loadedPrefabDict[kv.Key] = null;
        }
        loadedPrefabDict.Clear();
        Resources.UnloadUnusedAssets();
    }
}
