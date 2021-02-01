using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
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
            _audioEat.Play();
            transform.position = Vector3.down * 2;
            
            NodeMovement.SetAddSpeed(0.5f);
            SnakeHeadController.SetAddSpeed(0.5f);
            
            GameManager.SetAddScore(-100);
            
            Destroy(gameObject, _audioEat.clip.length);
        }
    }
}
