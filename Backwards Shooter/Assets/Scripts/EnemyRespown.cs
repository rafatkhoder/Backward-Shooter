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
        for (int i = 0; i < enemyCount; i++)
        {

            if (i < 5)
            {
                z = transform.position.z + num + count;
                x = 1.5f;
                count--;
            }
            else if (i < 10 && i > 4)
            {
                z = transform.position.z + num + count;
                x = 0f;
                count++;
            }
            else if (i < 15 && i > 9)
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
