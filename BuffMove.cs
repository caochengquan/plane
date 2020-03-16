using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    void move()
    {
        transform.Translate(-transform.forward * Time.deltaTime * 0.5f);
        if(transform.position.z<=-5.1f)
        {
            Destroy(this.gameObject);
        }
    }
}
