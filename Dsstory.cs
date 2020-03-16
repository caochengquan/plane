using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dsstory : MonoBehaviour {
    float temptime = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        temptime += Time.deltaTime;
        d();
	}

    void d()
    {
        if (temptime >= 0.9f)
        {
            Destroy(gameObject);
            temptime = 0;
        }
    }
}
