using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rBody;
    
    void Start()
    {
        //获取两个组件
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {   //方法getaxisram只会返回3个数值之一：-1, 0, 1
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            ani.SetFloat("Horizontal", horizontal);
            ani.SetFloat("Vertical", 0);
        }

        if (vertical != 0)
        {
            ani.SetFloat("Horizontal", 0);
            ani.SetFloat("Vertical", vertical);
        }

        //切换跑步状态
        Vector2 dir = new Vector2(horizontal, vertical);
        ani.SetFloat("Speed", dir.magnitude);//获取dir的长度，设置Speed参数
        //朝该方向移动
        rBody.velocity=dir.normalized * 1f; //设置速度为5f，normalized确保方向正确
    }
}
