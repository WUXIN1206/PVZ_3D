using UnityEngine;

public class PeaShooterBehavior : MonoBehaviour
{
    private Animator animator;
    private bool isAlive = true;
    public GameObject peaPrefab;
   
    public float peaSpeed = 10f;
    private bool isShooting = false;
    private float detectionInterval = 1.5f;
    private float timer = 0f;
    private float timer2 = 0f;
    private float detectionInterval2 = 1.5f;
    private int damage = 0;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        
        timer += Time.deltaTime;
        if (timer >= detectionInterval)
        { 
            CheckForZombies();
            timer = 0f;
        }

        if (damage == 5)
        {
            transform.Translate(Vector3.down*100f*Time.deltaTime);
            Invoke("Die",1f);
        }
            
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void ShootPea()
    {
        if (!isShooting)
        {
            
            isShooting = true;
          
            Vector3 spawnPosition = transform.position + new Vector3(0f, 4f, 0f);
            GameObject pea = Instantiate(peaPrefab, spawnPosition, Quaternion.identity);
            Rigidbody peaRb = pea.GetComponent<Rigidbody>();
    
            
            if (peaRb != null)
            {
                peaRb.velocity = transform.forward * peaSpeed;
            }
            
        }

        
    }

    void CheckForZombies()
    {
        if (!isShooting)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, LayerMask.GetMask("Zombie")))
            {
               
                ShootPea();
            }
            isShooting = false;
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