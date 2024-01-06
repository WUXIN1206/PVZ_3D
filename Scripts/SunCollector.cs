using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class SunCollector : MonoBehaviour
{
    public TMP_Text sunText; 
    public int sunValue = 0; 
    public GameObject sunPrefab;
    private float nextSunTime;
    public int sunProductionRate = 1;

    void Start()
    {
        UpdateSunText();
        nextSunTime = Time.time + 1f;
        
    }

    private void Update()
    {
        if (Time.time > nextSunTime)
        {
            GenerateSun();
            nextSunTime = Time.time + 5f / sunProductionRate; // 更新下一次生成阳光的时间
        }
    }

    void GenerateSun()
    {
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-25f, 25f), -30f, Random.Range(-25f, 25f));
        Instantiate(sunPrefab, spawnPosition, Quaternion.identity);
    }

    public void UpdateSunText()
    {
        // 更新UI Text显示的阳光值
        sunText.text = "Sun: " + sunValue.ToString();
    }

    public void CollectSun(int amount)
    {
        // 收集阳光时调用此方法，传递阳光值的数量
        sunValue += amount;
        UpdateSunText();
    }
}
