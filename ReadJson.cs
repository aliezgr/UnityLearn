using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class ItemJsonData
{
    public int id;
    public int type;
    public string name;
    public int atk;
    public int def;
    public double Crit;
    public string ModelPath;
    public string ImagePath;
}
public class ReadJson 
{
    private static ReadJson Instance;
    public static ReadJson instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new ReadJson();
                Instance.InitItemData();
            }
            return Instance;
        }
    }

    Dictionary<int, ItemJsonData> itemDatas = new Dictionary<int, ItemJsonData>();

    void InitItemData()
    {
        string str = Resources.Load<TextAsset>("ItemData").text;
        JsonData allData = JsonMapper.ToObject(str);

        for (int i = 0; i < allData.Count; i++)
        {
            int key = int.Parse(allData[i]["ID"].ToString());
            ItemJsonData data = new ItemJsonData();
            data.type = int.Parse(allData[i]["Type"].ToString());
            if (allData[i].ContainsKey("Defense"))
            {
                data.def = int.Parse(allData[i]["Defense"].ToString());
            }
            data.id = key;
            data.name = allData[i]["Name"].ToString();
            if (allData[i].ContainsKey("Attack"))
            {
                data.atk = int.Parse(allData[i]["Attack"].ToString());
            }
            if (allData[i].ContainsKey("Crit"))
            {
                data.Crit = double.Parse(allData[i]["Crit"].ToString());
            }
            
            data.ModelPath = allData[i]["ModelPath"].ToString();
            data.ImagePath = allData[i]["ImagePath"].ToString();
            itemDatas.Add(key, data);
        }
    }

    public ItemJsonData GetItemJsonData(int id)
    {
        if (itemDatas.ContainsKey(id))
        {
            return itemDatas[id];
        }
        Debug.LogError("2333");
        return null;
    }

}
