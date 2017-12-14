using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    string prefabName;
    GameObject prefab;
    int maxCount = 100;
    List<GameObject> prefabList = new List<GameObject>();

    public bool Contains(GameObject go)
    {
        return prefabList.Contains(go);
    }

    public GameObject GetObject(string name)
    {
        prefabName = name;
        GameObject go = null;
        for (int i = 0; i < prefabList.Count; i++)
        {
            if (!prefabList[i].activeSelf)
            {
                go = prefabList[i];
                go.SetActive(true);
                break;
            }
        }

        if (go == null)
        {
            if (prefabList.Count >= maxCount)
            {
                GameObject.Destroy(prefabList[0]);
                prefabList.RemoveAt(0);
            }
            prefab = Resources.Load(name) as GameObject;
            go = GameObject.Instantiate<GameObject>(prefab);
            prefabList.Add(go);
        }

        //go.SendMessage("BeforeGetObject", SendMessageOptions.DontRequireReceiver);
        return go;
    }

    public void HideObject(GameObject go)
    {
        if (prefabList.Contains(go))
        {
            go.SetActive(false);
            //go.SendMessage("BeforeHideObject", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void HideAllObject()
    {
        for (int i = 0; i < prefabList.Count; i++)
        {
            if (prefabList[i].activeSelf)
            {
                HideObject(prefabList[i]);
            }
        }
    }
}
