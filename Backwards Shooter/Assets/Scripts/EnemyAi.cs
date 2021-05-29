using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : Charchters
{
    [SerializeField]
    private float runDis = 400f;

    PlayerController playerController;
    EnemyRespown enemyRespown;
    Vector3 playerPos;
    Vector3 targetPos;
    NavMeshAgent nav;
    Vector3 targetPosZ;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        playerController = PlayerController.instnce;
        enemyRespown = EnemyRespown.instance;

        float targetDis = transform.position.z + runDis;
        targetPosZ = new Vector3(transform.position.x, transform.position.y, targetDis);

        targetPos = targetPosZ;
        playerPos = playerController.transform.position;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManger)
        {
            if (gameManger.gameState)
            {
                MoveEnemy();
            }
        }
    }
    /// <summary>
    /// use for to move ai
    /// </summary>
    void MoveEnemy()
    {
        // in first The enemy goes towards the end
        // When the distance between the player and the enemy approaches, he pursues him
        nav.speed = speed;
        anim.SetBool(GameString.run, true);
        playerPos = playerController.transform.position;
        nav.SetDestination(targetPos); // 
        
        float dis = Vector3.Distance(this.transform.position, playerPos);
        if(dis <= 3.0f)
        {
            nav.SetDestination(playerPos); 
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == GameString.bullet)
        {
            aud.Play();
            speed = 0;
            enemyRespown.enemyCount--;
            if (enemyRespown.enemyCount == 0)
            {
                MainMenu.instance.Win(true,null);
            }

            Destroy(col.gameObject); // for destroy Bullet
            Destroy(gameObject, 0.3f); // for destroy enemy
        }
    }
}
