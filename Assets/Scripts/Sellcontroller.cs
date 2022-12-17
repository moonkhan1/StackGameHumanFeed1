using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageNumbersPro;
using DG.Tweening;
using System.Linq;

public class Sellcontroller : MonoBehaviour
{
    [SerializeField] public LayerMask _layer;
    [SerializeField]Transform _fireTransform;
    [SerializeField]Transform _moveTransform;
    private Transform _transform;

    private Sequence _seq;
    private float count = 0;
    // int index;

    private void Start() {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate() {
        
    count += Time.fixedDeltaTime;
    AddIngredient();
    
    }


    public void AddIngredient()
    {
        if (Physics.Raycast(_fireTransform.position, _fireTransform.TransformDirection(Vector3.back), out RaycastHit hit, 15f, _layer))
        {
            Debug.DrawRay(_fireTransform.position, _fireTransform.TransformDirection(Vector3.back) * hit.distance, Color.red);
             if (hit.collider.tag == "Collected")
             {
                if(count > 0.1)
                {
                    Debug.Log("hitted axi");
                    DamageNum.Instance.ShowNumber(1.3f, hit.transform);
                    //  CollectedCoffeeData.Instance.CoffeeList.ForEach(u => {
                    // u.RemoveAll(a => a == hit.transform);
                    // });
                   List<Transform> list = CollectedCoffeeData.Instance.CoffeeList[0];
                   List<Transform> list2 = CollectedCoffeeData.Instance.CoffeeList[1];

                    if(list.Contains(hit.transform))
                        list.Remove(hit.transform);
                    if(list2.Contains(hit.transform))
                        list2.Remove(hit.transform);

                    

                    hit.transform.parent =_transform;
                    GameObject go = hit.transform.gameObject;
                    go.transform.DOMove(_moveTransform.position, 0.8f)
                    .OnComplete(()=>
                    {
                        Destroy(go);
                    });
            
                count = 0;
                }
                Debug.Log("hitted");
                
             }
            
        }
       
    }
}
