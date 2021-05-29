using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 offest;
    void Start()
    {
        offest = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offest;
    }
}
