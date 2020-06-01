using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 相机跟随
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public float Durioon = 1;//相机跟随进度
    public Transform player;
    private Vector3 offset;
    public bool followY = true;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        offset = player .position - transform.position;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetPos = player.position - offset;
        if (!followY)
            targetPos.y = transform.position.y;
        transform.position = Vector3.Slerp(transform.position, targetPos, Durioon * Time.deltaTime);
    }
}
