using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private CinemachineVirtualCamera VirtualCamera;
    public float moveStep;


    private void Start()
    {
        VirtualCamera = GetComponent<CinemachineVirtualCamera>();
        
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    private void Move()
    {
        VirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition += moveStep;
    }
}
