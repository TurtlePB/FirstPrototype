using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public int numSelectors = 5;
    public GameObject[] selectorArr;
    private GameObject selector; //selected in the editor
    // private List<GameObject> ListOfFoodStuff;
    void Start()
    {
        selectorArr = new GameObject[numSelectors];
    }
}
