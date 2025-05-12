using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{

    
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;


    private List<GameObject> plateVisualGameObjectList;

    private void Awake()
    {
        plateVisualGameObjectList = new List<GameObject>();
    }

    private void Start()
    {
        platesCounter.OnPlatesSpawned += PlatesCounter_OnPlatesSpawned;
        platesCounter.OnPlatesCleared += PlatesCounter_OnPlatesCleared;
    }
    
    private void PlatesCounter_OnPlatesSpawned(object sender, EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopPoint);

        float plateOffsetY = .1f;
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * plateVisualGameObjectList.Count, 0);
        
        plateVisualGameObjectList.Add(plateVisualTransform.gameObject);
    }

    private void PlatesCounter_OnPlatesCleared(object sender, EventArgs e)
    {
        GameObject plateGameObject = plateVisualGameObjectList[^1];
        plateVisualGameObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }
    
}
