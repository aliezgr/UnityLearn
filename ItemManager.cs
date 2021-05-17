using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public int jsonId;
    public int autoId;
    public ItemJsonData jsonData
    {
        get
        {
            return ReadJson.instance.GetItemJsonData(jsonId);
        }
    }

    //
    public int quality;
    public int addAtk;
}

public class ItemManager
{
    //����
    private static ItemManager Instance;
    public static ItemManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new ItemManager();
            }
            return Instance;
        }
    }

    List<ItemData> AllItems = new List<ItemData>();
    int autoidConter = 1;

    public ItemData Additem(int jsonId)
    {
        ItemData data = new ItemData();
        data.autoId = autoidConter;
        autoidConter++;
        data.jsonId = jsonId;

        data.addAtk = Random.Range(0, 5);

        AllItems.Add(data);
        return data;    
    }

    public ItemData GetItem(int Autoid)
    {
        ItemData data = new ItemData();

        for (int i = 0; i < AllItems.Count; i++)
        {
            if (AllItems[i].autoId == Autoid)
            {
                data = AllItems[i];
                break;
            }
        }
        return data;
    }

    public void RemoveItem(int autoId)
    {
        for (int i = 0; i < AllItems.Count; i++)
        {
            if(AllItems[i].autoId == autoId)
            {
                AllItems.Remove(AllItems[i]);
                return;
            }
        }
    }
}
