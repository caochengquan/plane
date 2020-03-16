using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    bullet, bullet1, bullet2, monster
}

public class BulletMove : MonoBehaviour {
    public BulletType type;
    public GameObject bomb;
    public GameObject BulletBuff;
    private float speed = 10;
	// Use this for initialization
	void Start () {
        //1.函数名 2.第一次前的等待时间 3.隔多久调用1次
        //InvokeRepeating("Destorybullet", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
        if(type==BulletType.monster)
        {
            transform.Translate(-transform.forward * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);
        }

        Destorybullet();
	}

    void Destorybullet()
    {
        RaycastHit hit;
        if (type==BulletType.monster)
        {
            if (Physics.Linecast(transform.position, transform.position - transform.forward * Time.deltaTime * speed, out hit))
            {
                if (hit.transform.tag == "Hero")
                {
                    Instantiate(bomb, transform.position, transform.rotation);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        else
        {
            if (Physics.Linecast(transform.position, transform.position + transform.forward * Time.deltaTime * speed, out hit))
            {
                if(hit.transform.tag=="Monster")
                {
                    BulletManage._bulletmage.collection(this);//人物子弹回收
                    MonsterManage._monstermanage.collection(hit.transform.gameObject.GetComponent<MonsterMove>());//怪物回收
                    Instantiate(bomb, transform.position, transform.rotation);//创建粒子效果
                    float Buff = Random.Range(0, 100);//Buff几率
                    if(Buff<10)
                    {
                        Instantiate(BulletBuff,hit.transform.position,hit.transform.rotation);
                    }
                    //Destroy(hit.transform.gameObject);
                }
            }
        }
        if (transform.position.z >= 5.1f || transform.position.x >= 3.2f || transform.position.x <= -3.2f || transform.position.z <= -5.1f)
        {
            BulletManage._bulletmage.collection(this);
        }
    }
}
