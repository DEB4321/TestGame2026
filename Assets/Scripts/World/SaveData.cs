using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    public string mapBoundary; //The Boundary name for the map
    public List<Item> items;
}
