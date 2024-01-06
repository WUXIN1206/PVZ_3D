using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPController : MonoBehaviour
{
    private float timer2 = 0f;
    private float detectionInterval2 = 1.5f;
    private int damage = 0;
  
    void Start()
    {
        
    }

  
    void Update()
    {
        if (damage == 10)
        {
            SceneManager.LoadScene(1);
        }
    }
    
  

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {

            timer2 += Time.deltaTime;
            if (timer2 >= detectionInterval2)
            {
                damage++;
                timer2 = 0f;
            }

        }
    }
}
