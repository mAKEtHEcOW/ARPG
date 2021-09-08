using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMosnterControl : MonoBehaviour
{
    public GameObject[] monsterSpawnPoint;
    public GameObject[] MonsterPrefab;

    private void Awake()
    {
        monsterSpawnPoint = GameObject.FindGameObjectsWithTag("MonssterSpawnPoint");
        this.gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        List<GameDateConfig.MonsterDateToCreate> mDate = GameDateConfig.GetMonster();
        MonsterPrefab[1] = Resources.Load<GameObject>("Monster/" + mDate[1].monsterName);
        Debug.Log("mDate[1]的名字 " + mDate[1].monsterName);
        StartCoroutine(MakeMonster());
    }

    public void OnDisable()
    {
        MonsterPrefab = null;
    }

    IEnumerator MakeMonster()
    {
        yield return 0;
        Instantiate(MonsterPrefab[1], monsterSpawnPoint[1].transform, monsterSpawnPoint[1].transform);
    }
}


