using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE
{
    BIG, MEDIUM, SMALL
}
public class MonsterMove : MonoBehaviour {
    public TYPE type;
    float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= transform.forward * Time.deltaTime * speed;
        DestroyMonster();
	}

    void DestroyMonster()
    {
        if (transform.position.z <= -5.5f)
        {
            MonsterManage._monstermanage.collection(this);
        }
    }
}
