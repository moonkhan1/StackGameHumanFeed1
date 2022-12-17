using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCoffeeData : MonoBehaviour
{
    public static CollectedCoffeeData Instance;
    [SerializeField] public  List<List<Transform>> CoffeeList;
    [SerializeField] public  List<Transform> CoffeeList1;
    [SerializeField] public  List<Transform> CoffeeList2;
    [SerializeField] public  List<Transform> CoffeeList3;
    [SerializeField] public  List<Transform> CoffeeList4;

    [SerializeField] public List<Renderer> Meshes;
    // public List<Transform> CoffeeListPos;
    private void Awake() 
    {
        if(Instance ==null)
            Instance = this;
    }

    private void Start() {
        CoffeeList = new();
        CoffeeList.Add(CoffeeList1);
        CoffeeList.Add(CoffeeList2);
        CoffeeList.Add(CoffeeList3);
        CoffeeList.Add(CoffeeList4);
         ControlAllMeshes(false);
    }


public void ControlAllMeshes(bool command)
    {
        //  _coffees = GameObject.FindGameObjectWithTag("Collactable");
        // Meshes.Add(_coffees.GetComponentInChildren<Renderer>());
        foreach (var item in Meshes)
        {

            item.gameObject.SetActive(command);
            

        }
    }

    // public void OpenMeshes(int ind)
    // {
    //     foreach (var item in Meshes)
    //     {
    //         item.GetComponentsInChildren<Renderer>()[ind].enabled = true;

    //     }



    // }

    
}
