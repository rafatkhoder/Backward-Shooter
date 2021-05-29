using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Charchters
{
    public static PlayerController instnce;
    private MainMenu mainMenu;
    private Vector3 dragOrigin; // first touch pos to player
    [SerializeField]
    private float dragSpeed = 3; // left and right wallk speed for player

    [Header(" -----------  Sound  ------------")]
    public AudioClip hitWall;
    

    #region Default Funuction
    void Awake()
    {
        instnce = this;
    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        mainMenu = MainMenu.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManger)
        {
            if (gameManger.gameState)
            {  
                Movement();
                DragPlayer();
            }
        }
    }
    #endregion

    #region Player Controller
    /// <summary>
    /// Move player to forwrd
    /// </summary>
    void Movement()
    {
        anim.SetBool(GameString.run, true);
        transform.Translate(0f, 0f, speed * Time.deltaTime); 
    }

    /// <summary>
    /// left and right player toush or mouse
    /// </summary>
    void DragPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(Mathf.Clamp(pos.x * dragSpeed, -0.1f, 0.1f), 0, 0);
       
        transform.Translate(move, Space.World);
    }

    #endregion

    #region State Game Lose OR Win
    void WinGame()
    {
        anim.SetBool(GameString.run, false);
        mainMenu.Win(true ,aud);
    }
    void LoseGame()
    {
        anim.SetBool(GameString.run, false);
        mainMenu.Lose(true ,aud);
        aud.enabled = false;
    }

    #endregion

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == GameString.wall)
        {
            aud.PlayOneShot(hitWall);
            Destroy(col.gameObject, 0.2f);

        }
        else if(col.gameObject.tag == GameString.fainal)
        {
            WinGame();

        }
        else if(col.gameObject.tag == GameString.enemy)
        {
            LoseGame();
            col.GetComponent<Animator>().SetBool(GameString.run, false); // stop run anim after lose
        }
    }
}
