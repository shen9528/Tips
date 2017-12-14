using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button GetBtn;
    public Button HideBtn;
    public Button HideAllBtn;
    
    void Start ()
    {
        GetBtn.onClick.AddListener(Get);
        HideBtn.onClick.AddListener(Hide);
        HideAllBtn.onClick.AddListener(HideAll);
	}

    void Get()
    {
        PoolManager.Instance.GetObject("Prefabs/Cube");
    }

    void Hide()
    {
        PoolManager.Instance.HideObject(GameObject.FindObjectOfType<GameObject>());
    }

    void HideAll()
    {
        PoolManager.Instance.HideAllObject("Prefabs/Cube");
    }    
}
