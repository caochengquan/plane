using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManage : MonoBehaviour {
    public static BulletManage _bulletmage;
    LinkedList<BulletMove> lifepool = new LinkedList<BulletMove>();
    LinkedList<BulletMove> diepool = new LinkedList<BulletMove>();
	// Use this for initialization

    void Awake()
    {
        _bulletmage = this;
    }
	// Update is called once per frame
	void Update () {
	}

    //添加子弹
    public void addbullet(BulletMove bullet)
    {
        lifepool.AddLast(bullet);
    }
    //在死亡池中查找
    public BulletMove takebullet(BulletType Type)
    {
        var temp = diepool.First;
        for (int i = 0; i < diepool.Count;++i )
        {
            if(temp.Value.type==Type)
            {
                lifepool.AddLast(temp.Value);
                diepool.Remove(temp.Value);
                return temp.Value;
            }
            temp = temp.Next;
        }
        return null;
    }

    //回收子弹
    public void collection(BulletMove bullet)
    {
        lifepool.Remove(bullet);
        diepool.AddLast(bullet);
        bullet.gameObject.SetActive(false);
    }
}
