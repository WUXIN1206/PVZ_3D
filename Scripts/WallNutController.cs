using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNutController : MonoBehaviour
{
    private float timer2 = 0f;
    private float detectionInterval2 = 1.5f;
    private int damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (damage == 15)
        {
            transform.Translate(Vector3.down*100f*Time.deltaTime);
            Invoke("Die",1f);
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
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
