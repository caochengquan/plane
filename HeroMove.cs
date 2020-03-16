using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour {
    public GameObject bomb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void OnMouseDrag()
    {
        Vector3 pos = Input.mousePosition;
        //屏幕转世界坐标
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.y = transform.position.y;
        transform.position = pos;
        //print(pos);
    }

    void Move()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical")*0.2f);
        if (transform.position.x <= -3.67f)
        {
            transform.position = new Vector3(3.67f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 3.67f)
        {
            transform.position = new Vector3(-3.67f, transform.position.y, transform.position.z);
        }
        transform.Translate(Input.GetAxis("Horizontal")*0.2f, 0, 0);
    }

    //触发开始
    private void OnTriggerEnter(Collider other)
    {
        //print(other.name /*+ "OnTriggerStay"*/);
        if (other.tag == "BulletBuff" && Fire.bulletlv<4)
        {
            ++Fire.bulletlv;
            Destroy(other.gameObject);
        }
        else if(other.tag=="Monster")
        {
            Instantiate(bomb, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
            
    }
}
