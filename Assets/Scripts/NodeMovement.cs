using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{
    private static float Speed = 5f;
    
    public Vector3 tailTarget;
    public GameObject tailTargetObj;
    public SnakeHeadController mainSnake;

    private void Start()
    {
        mainSnake = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeHeadController>();
        tailTargetObj = mainSnake.tailObjects[mainSnake.tailObjects.Count-2];
    }
    
    
    
    private void LateUpdate () {
        tailTarget = tailTargetObj.transform.position;
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position,tailTarget,0.01754f * Speed);
    }

    public static void SetAddSpeed(float speed)
    {
        Speed += speed;
    }
    
    public static void SetSpeed(float speed)
    {
        Speed = speed;
    }
    
    public static float GetSpeed()
    {
        return Speed;
    }
    
}
