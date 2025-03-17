using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ChestPersistence : MonoBehaviour
{
    private Chest chest;
    private string savePath;

    void Start()
    {
        chest = GetComponent<Chest>();
        savePath = Application.persistentDataPath + "/chest_" + gameObject.name + ".json";
        LoadChest();
    }

    public void SaveChest()
    {
        ChestSaveData saveData = new ChestSaveData();
        foreach (ItemData item in chest.chestItems)
        {
            saveData.itemNames.Add(item.itemName);
        }
        File.WriteAllText(savePath, JsonUtility.ToJson(saveData));
    }

    public void LoadChest()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            ChestSaveData loadData = JsonUtility.FromJson<ChestSaveData>(json);
            chest.chestItems.Clear();
            foreach (string itemName in loadData.itemNames)
            {
                ItemData item = FindItemByName(itemName);
                if (item != null) chest.chestItems.Add(item);
            }
            chest.PopulateChest();
        }
    }

    private ItemData FindItemByName(string name)
    {
        return Resources.Load<ItemData>("Items/" + name);
    }
}

[System.Serializable]
public class ChestSaveData
{
    public List<string> itemNames = new List<string>();
}
