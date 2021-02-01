using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    private AudioSource _audioEat;
    
    void Start()
    {
        _audioEat = this.GetComponent<AudioSource>();
    }
    
    
    private float OldSpeed;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SnakeHead"))
        {
            _audioEat.Play();
            
            OldSpeed = NodeMovement.GetSpeed();
            transform.position = Vector3.down * 2;
            
            GameManager.SetAddScore(-50);
            
            StartCoroutine(Slowly(Random.Range(0.5f, 4f)));
        }
    }
    
    
    IEnumerator Slowly(float _delay) {
        NodeMovement.SetSpeed(2f);
        SnakeHeadController.SetSpeed(2f);
        yield return new WaitForSeconds(_delay);
        NodeMovement.SetSpeed(OldSpeed);
        SnakeHeadController.SetSpeed(OldSpeed);
        Destroy(gameObject);
    }
}
