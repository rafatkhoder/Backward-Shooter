using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charchters : MonoBehaviour
{
    [SerializeField]
    protected float speed = 10f; // speed foe Wallk
    protected Animator anim;
    protected GameManger gameManger;
    protected AudioSource aud;

    public virtual void Start()
    {
        gameManger = GameManger.instance;
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }
    
    
}
