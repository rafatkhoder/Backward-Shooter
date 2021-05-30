using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRespown : Singleton<EnemyRespown>
{
    
    public int enemyCount = 15;
    private int defaultEnemyCount;
    [SerializeField]
    private GameObject enemyPrefap;
    [SerializeField]
    private Text enemyContText;
    private float x; 
    private float z;

    void Awake()
    {
        base.RegisterSingleton(); 
    }
    void Start()
    {
        defaultEnemyCount = enemyCount;
        Respown();
    }
    private void Update()
    {
        EnemyCountupdate();
    }
    void EnemyCountupdate()
    {
        enemyContText.text = defaultEnemyCount.ToString() + " / " + enemyCount.ToString();
    }
    void Respown()
    {
        float num = 2.5f;
        float count = 0;
        int thirdCount = defaultEnemyCount / 3;
        for (int i = 0; i < enemyCount; i++)
        {

            if (i < thirdCount)
            {
                z = transform.position.z + num + count;
                x = 1.5f;
                count--;
            }
            else if (i < thirdCount * 2 && i > thirdCount - 1)
            {
                z = transform.position.z + num + count;
                x = 0f;
                count++;
            }
            else
            {
                z = transform.position.z + num + count;
                x = -1.5f;
                count--;
            }
            Vector3 pos = new Vector3(x, transform.position.y, z);
            Instantiate(enemyPrefap, pos,transform.rotation, this.transform);
        }
    }
}
