using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    private CinemachineConfiner2D confiner2D;

    private void Awake()
    {
        confiner2D = GetComponent<CinemachineConfiner2D>();
        if (confiner2D == null)
        {
            Debug.LogError("CinemachineConfiner2D component not found on the GameObject.没找到有边框的物件");
        }
    }

    private void Start() //游戏一开始获取边界
    {
        GetNewCameraBounds();
    }
    private void GetNewCameraBounds()
    { 
       var obj = GameObject.FindGameObjectWithTag("Bounds");
        if (obj == null)
            return;
        //其他情况
        confiner2D.m_BoundingShape2D = obj.GetComponent<Collider2D>();

        confiner2D.InvalidateCache();//销毁上一个边框的缓存

    }
}
