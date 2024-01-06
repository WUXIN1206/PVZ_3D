using UnityEngine;

public class Sun : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
               
                FindObjectOfType<SunCollector>().CollectSun(25);

                
                Destroy(gameObject);
            }
        }
    }
}