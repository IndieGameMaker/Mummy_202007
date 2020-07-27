using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject goodPrefab;
    public GameObject badPrefab;

    [Range(10, 30)]
    public int goodCount = 10;
    [Range(10, 30)]
    public int badCount  = 10;

    public List<GameObject> goodList = new List<GameObject>();
    public List<GameObject> badList  = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        MakeItems();
    }

    void MakeItems()
    {
        foreach (var obj in goodList)
        {
            Destroy(obj);
        }

        foreach (var obj in badList)
        {
            Destroy(obj);
        }

        goodList.Clear();
        badList.Clear();


        //Good Items 생성
        for(int i=0; i<goodCount; i++)
        {
            Vector3 pos = new Vector3( Random.Range(-23.0f, 23.0f)
                                     , 0.55f
                                     , Random.Range(-23.0f, 23.0f));
            GameObject obj = Instantiate(goodPrefab, pos, Quaternion.identity);
            goodList.Add(obj);
        }

        //Bad Items 생성
        for(int i=0; i<badCount; i++)
        {
            Vector3 pos = new Vector3( Random.Range(-23.0f, 23.0f)
                                     , 0.55f
                                     , Random.Range(-23.0f, 23.0f));
            GameObject obj = Instantiate(badPrefab, pos, Quaternion.identity);
            badList.Add(obj);
        }        
    }


}
