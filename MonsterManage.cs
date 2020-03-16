using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManage : MonoBehaviour {
    public static MonsterManage _monstermanage;
    LinkedList<MonsterMove> lifepool = new LinkedList<MonsterMove>();
    LinkedList<MonsterMove> diepool = new LinkedList<MonsterMove>();

	// Use this for initialization
	void Awake () {
        _monstermanage = this;
	}
	
	// Update is called once per frame
	void Update () {
	}

    //添加到生存池
    public void addmonster(MonsterMove monster)
    {
        lifepool.AddLast(monster);
    }

    //在死亡池中查找
    public MonsterMove takemonster(TYPE Type)
    {
        //print("生存"+lifepool.Count);
        //print("死亡"+diepool.Count);
        var temp = diepool.First;
        for (int i = 0; i < diepool.Count;++i )
        {
            if(temp.Value.GetComponent<MonsterMove>().type==Type)
            {
                diepool.Remove(temp.Value);
                return temp.Value;
            }
            temp = temp.Next;
        }
        return null;
    }

    //回收子弹
    public void collection(MonsterMove monster)
    {
        monster.gameObject.SetActive(false);
        lifepool.Remove(monster);
        diepool.AddLast(monster);
    }
}
