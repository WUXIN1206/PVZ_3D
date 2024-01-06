using UnityEngine;

public class Sunflower : MonoBehaviour
{
    public int sunProductionRate = 1;
    public GameObject sunPrefab; 

    private float nextSunTime;
    private float timer2 = 0f;
    private float detectionInterval2 = 1.5f;
    private int damage = 0;

    void Start()
    {
        nextSunTime = Time.time + 1f; // 初始1秒后开始生成阳光
    }

    void Update()
    {
        if (Time.time > nextSunTime)
        {
            GenerateSun();
            nextSunTime = Time.time + 5f / sunProductionRate; // 更新下一次生成阳光的时间
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

    void GenerateSun()
    {
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-1f, 1f), 5f, Random.Range(-1f, 1f));
        Instantiate(sunPrefab, spawnPosition, Quaternion.identity);
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