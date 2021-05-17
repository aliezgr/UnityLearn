using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ItemJsonData data = ReadJson.instance.GetItemJsonData(1001);
        Debug.LogError(data.id);
        Debug.LogError(data.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
