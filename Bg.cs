using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour {
    MeshRenderer meshRender;
    //private float offsetY = 0;
    public float speed;
	// Use this for initialization
	void Start () {
        meshRender = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //offsetY += Time.deltaTime * speed;
        //meshRender.material.SetTextureOffset("_MainTex",
        //    new Vector2(0,offsetY));

        meshRender.material.SetTextureOffset("_MainTex",
             new Vector2(0, Time.time*speed));
	}
}
