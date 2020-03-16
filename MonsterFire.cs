using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFire : MonoBehaviour {
    public GameObject MonsterBullet;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Create", 0, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Create()
    {
        if (transform.gameObject.activeSelf)
        {
            BulletMove bullet = BulletManage._bulletmage.takebullet(BulletType.monster);
            if (bullet == null)
            {
                GameObject go = Instantiate(MonsterBullet);
                bullet = go.GetComponent<BulletMove>();
                bullet.type = BulletType.monster;
            }
            bullet.gameObject.SetActive(true);
            bullet.transform.position = transform.position;
            BulletManage._bulletmage.addbullet(bullet);
        }
    }
}
