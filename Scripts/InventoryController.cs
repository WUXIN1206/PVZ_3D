using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public int slotIndex; // 每个槽的索引，从1到6
    public Color selectedColor = Color.yellow; // 选中状态的颜色
    private Color defaultColor; // 初始颜色
    private bool isSelected = false;
    private static InventorySlot currentlySelectedSlot; 
    public int plantIndex;

    void Start()
    {
     
        defaultColor = GetComponent<Image>().color;
        

    }

    void Update()
    {
        // 检测对应的按键
        if (Input.GetKeyDown(KeyCode.Alpha1) && slotIndex == 1)
        {
            SelectSlot();
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && slotIndex == 2)
        {
            SelectSlot();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && slotIndex == 3)
        {
            SelectSlot();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && slotIndex == 4)
        {
            SelectSlot();
        }
        
      
    }

    void SelectSlot()
    {
        if (currentlySelectedSlot != null && currentlySelectedSlot != this)
        {
            currentlySelectedSlot.DeselectSlot();
        }

        
        isSelected = !isSelected;

        // 更新颜色
        if (isSelected)
        {
            GetComponent<Image>().color = selectedColor;
            plantIndex = slotIndex;
            FindObjectOfType<PlantSpawner>().SelectPlant(plantIndex);

           
        }
        else
        {
            GetComponent<Image>().color = defaultColor;
           
        }

        
        currentlySelectedSlot = isSelected ? this : null;
       
    }
    void DeselectSlot()
    {
        isSelected = false;
        GetComponent<Image>().color = defaultColor;
      
    }
 
}