using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BigBoiCounter : MonoBehaviour
{
    public TMP_Text itemText;
    public GameObject burger;

    private int existingItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ItemCount()
    {

        if (burger.gameObject.tag == "Untagged")
        {
            existingItems++;
            itemText.text = "Item:" + existingItems;
            // Destroy(tag.Insert(""));
        }
        
    }
}
