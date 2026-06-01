using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Unity.Cinemachine;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    private InventoryController inventoryController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Define save location
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        inventoryController = FindAnyObjectByType<InventoryController>();

        LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            mapBoundary = FindAnyObjectByType<CinemachineConfiner2D>().BoundingShape2D.name,
            items = inventoryController.items
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;

            FindAnyObjectByType<CinemachineConfiner2D>().BoundingShape2D = GameObject.Find(saveData.mapBoundary).GetComponent<PolygonCollider2D>();

            //foreach (ItemSaveData item in saveData.items)
            //{
            //    print($"itemID: {item.itemID}, quantity: {item.quantity}");
            //}

            inventoryController.SetInventoryItems(saveData.items);
        } 
        else
        {
            SaveGame();
        }
    }
}
