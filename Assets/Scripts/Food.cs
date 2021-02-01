using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private AudioSource _audioEat;
    
    void Start()
    {
        _audioEat = this.GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        
        
        if(other.CompareTag("SnakeHead"))
        {
            transform.position = Vector3.down * 2;
            _audioEat.Play();
            
            other.GetComponent<SnakeHeadController>().AddTail();
            
            GameManager.SetAddScore(100);
            Destroy(gameObject, _audioEat.clip.length);
        }
    }
}
