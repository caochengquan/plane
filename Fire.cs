using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public GameObject bullet;
    public GameObject bullet1;
    public GameObject bullet2;
    private float speed = 0.2f;
    public static int bulletlv = 1; //子弹等级
    BulletMove temp;//临时对象
    BulletType type;//临时对象
    GameObject tempObject;//临时对象
    Vector3 tempVector3;//临时对象
    //public Transform bulletpoint;
	// Use this for initialization
	void Start () {
        //Invoke(函数名);//隔多久调用1次,只调用1次
        //1.函数名 2.第一次前的等待时间 3.隔多久调用1次
      InvokeRepeating("CreateBullet", 0, speed);
	}
	
	// Update is called once per frame
    void Update(){
	}

    void CreateBullet()
    {
        //依照子弹等级发射子弹
        for(int i=0;i<bulletlv;i++)
        {
            switch(i)
            {
                case 0:
                    type = BulletType.bullet;
                    tempObject = bullet;
                    tempVector3 = new Vector3(0, 0, 0);
                    break;
                case 1:
                    type = BulletType.bullet1;
                    tempObject = bullet1;
                    tempVector3 = new Vector3(0, -10, 0);
                    break;
                case 2:
                    type = BulletType.bullet2;
                    tempObject = bullet2;
                    tempVector3 = new Vector3(0, 10, 0);
                    break;
            }

            temp = BulletManage._bulletmage.takebullet(type);
            if (temp == null)
            {
                GameObject go = Instantiate(tempObject);
                temp = go.GetComponent<BulletMove>();
                temp.type = type;
            }
            temp.gameObject.SetActive(true);
            temp.transform.position = transform.position;
            temp.transform.rotation = Quaternion.Euler(tempVector3);
            //temp.transform.rotation = transform.rotation;
            BulletManage._bulletmage.addbullet(temp);
        }
    }
}
