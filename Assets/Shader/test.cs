using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    public Transform t1,t2; 

	// Use this for initialization
	void Start () {
        float f = Vector3.Dot(t1.position.normalized, t2.position.normalized);
        float angle = Mathf.Acos(f) * Mathf.Rad2Deg;
        print(f + " dot: " + angle + t1.position.normalized + t2.position.normalized + t2.forward);
        Debug.DrawLine(Vector3.zero, t2.forward, Color.red, 10f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
