using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDateConfig : MonoBehaviour
{
    public struct MonsterDateToCreate
    {
        public string monsterName;
        public int maxNum;
        public int minNum;
    }

    public static List<MonsterDateToCreate> GetMonster()
    {
        MonsterDateToCreate mDate;
        List<MonsterDateToCreate> lsm = new List<MonsterDateToCreate>();

        mDate.monsterName = "Monster0001";
        mDate.maxNum = 10;
        mDate.minNum = 5;

        lsm.Add(mDate);
        return lsm;
    }

}
