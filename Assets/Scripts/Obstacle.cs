using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    private AudioSource _audioImpact;
    private GameObject snakeHead;
    private Image bloodEffect;
    
    void Start()
    {
        _audioImpact = this.GetComponent<AudioSource>();
        snakeHead = GameObject.FindGameObjectWithTag("DamagedOpacity");
        bloodEffect = GameObject.FindGameObjectWithTag("Blood").GetComponent<Image>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (!this.CompareTag("Wall"))
        {
            if(other.CompareTag("SnakeHead"))
            {
                if (GameManager.GetHealth() == 1)            
                    UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
                else
                {
                    StartCoroutine(DamagedFlash());
                    GameManager.DecreaseHealth();
                    _audioImpact.Play();                    
                }
            }
        }
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        
        StopCoroutine(DamagedFlash());
    }

    IEnumerator DamagedFlash()
    {
        bloodEffect.color = new Color(255f,255f,255f,255f);
        snakeHead.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(0.25f);
        snakeHead.GetComponent<MeshRenderer>().enabled = true;
        bloodEffect.color = new Color(255f,255f,255f,0f);
    }
    
}
