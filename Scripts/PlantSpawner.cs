using UnityEngine;
using UnityEngine.UI;

public class PlantSpawner : MonoBehaviour
{
    public GameObject[] plantPrefabs;
    public SunCollector SunCollector;

    private int selectedPlantIndex = -1; 

    void Start()
    {
        // 在按钮上添加点击监听
        
    }
    void Update()
    {
        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 检测是否点击到地面
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                
                if (selectedPlantIndex > 1 && selectedPlantIndex < plantPrefabs.Length)
                {
                    int sunCost = CalculateSunCost(selectedPlantIndex);

                    if (SunCollector.sunValue >= sunCost)
                    {
                        SunCollector.sunValue -= sunCost;
                        SunCollector.UpdateSunText();
                        Vector3 playerForward = Camera.main.transform.forward;
                        playerForward.y = 0f; 
                        Quaternion plantRotation = Quaternion.LookRotation(playerForward);

                        GameObject newPlant = Instantiate(plantPrefabs[selectedPlantIndex], hit.point, plantRotation);
                    }
                }
            }
        }
    }
    
    int CalculateSunCost(int plantIndex)
    {
        
        int sunCost = 0;

        switch (plantIndex)
        {
            case 2:
                sunCost = 100; 
                break;
            
            case 3:
                sunCost = 50; 
                break;
            case 4:
                sunCost = 50; 
                break;
            default:
                sunCost = 0; 
                break;
        }

        return sunCost;
    }

    public void SelectPlant(int plantIndex)
    {
        selectedPlantIndex = plantIndex;
    }
    
    
}