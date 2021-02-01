using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadController : MonoBehaviour
{
    private static float Speed = 5f;
    private float RotationSpeed = 1.5f;
    private float z_offset = 1f;

    private int tailCount = 0;
    
    public List<GameObject> tailObjects = new List<GameObject>();

    public GameObject TailPrefab;
    
    public static void SetAddSpeed(float speed)
    {
        Speed += speed;
    }
    
    public static void SetSpeed(float speed)
    {
        Speed = speed;
    }
    
    private void Awake () {
        tailObjects.Add(this.gameObject);
    }
  
    private void Update ()
    {
        GetKeyLr();
    }

    private void LateUpdate()
    {
        MoveForce();
    }

    private void MoveForce()
    {
        transform.Translate(Vector3.forward * Speed * 0.01754f);
    }

    
    
    private void GetKeyLr()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 90.0f, 0f),  Time.deltaTime * RotationSpeed);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -90.0f, 0f),  Time.deltaTime * RotationSpeed);  
        }
    }

    
    
    
    public void AddTail()
    {
            tailCount = tailObjects.Count;
            
            Vector3 newTailPos = tailObjects[tailCount-1].transform.position;
                    newTailPos.z -= z_offset;
                    
            if (tailCount < 12)
                tailObjects.Add(GameObject.Instantiate(TailPrefab,newTailPos,Quaternion.identity) as GameObject);
            
    }
}
