using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateMonster : MonoBehaviour {
    public GameObject BigMonster;
    public GameObject MediumMonster;
    public GameObject SmallMonster;
    //public Transform MonsterPoint;
    Vector3 tempVector3;
    GameObject temp;

	// Use this for initialization
	void Start () {
        //Invoke(函数名);//隔多久调用1次,只调用1次
        //1.函数名 2.第一次前的等待时间 3.隔多久调用1次
        InvokeRepeating("Create", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void Create()
    {
        int odds = Random.Range(0, 100);
        TYPE type;
        if(odds<51)
        {
            type = TYPE.SMALL;
        }
        else if(odds<86)
        {
            type=TYPE.MEDIUM;
        }
        else
        {
            type=TYPE.BIG;
        }
        //生成怪物
        MonsterMove monster = MonsterManage._monstermanage.takemonster(type);
        if(monster==null)
        {
            switch(type)
            {
                case TYPE.BIG:
                    temp = Instantiate(BigMonster);
                    break;
                case TYPE.MEDIUM:
                    temp = Instantiate(MediumMonster);
                    break;
                case TYPE.SMALL:
                    temp = Instantiate(SmallMonster);
                    break;
            }
            monster = temp.GetComponent<MonsterMove>();
        }
        monster.gameObject.SetActive(true);
        tempVector3 = new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y, transform.position.z);
        monster.transform.position = tempVector3;

        //MonsterPoint.position = new Vector3(Random.Range(-2.5f, 2.5f), MonsterPoint.position.y, MonsterPoint.position.z);
        //monster.transform.position = MonsterPoint.position;
        //monster.transform.rotation = MonsterPoint.rotation;
        //monster.transform.parent = MonsterPoint;
        MonsterManage._monstermanage.addmonster(monster);
    }
}
