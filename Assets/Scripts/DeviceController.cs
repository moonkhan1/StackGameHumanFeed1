using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CASP.SoundManager;
public class DeviceController : MonoBehaviour
{
    [SerializeField] public LayerMask _layer;
    [SerializeField] public GameObject _pourPref;
    [SerializeField] public GameObject _pouredPref;
    [SerializeField]Transform _fireTransform;

    private Sequence _seq;
    private float count = 0;
    private float _sousCount = 0;
    // int index;

    private void Start() {
    }

    private void FixedUpdate() {
        
    count += Time.fixedDeltaTime;
    AddIngredient();
    
    }


    public void AddIngredient()
    {
        if (Physics.Raycast(_fireTransform.position, _fireTransform.TransformDirection(Vector3.back), out RaycastHit hit, 10f, _layer))
        {
            Debug.DrawRay(_fireTransform.position, _fireTransform.TransformDirection(Vector3.back) * hit.distance, Color.red);
             if (hit.collider.tag == "Collected")
             {
                
                // GameObject go = Instantiate(_pourPref, _fireTransform.position, Quaternion.Euler(0,0,0));
                if(_sousCount == 0)
                {
                    SoundManager.Instance.Play("Souce");
                    GameObject go2 = Instantiate(_pouredPref, hit.transform.position, Quaternion.Euler(-90,0,90));
                    go2.transform.parent = hit.transform;
                    _sousCount = 1;
                }
                
                Debug.Log("hitted");
                
                
             }
            
        }
        else
        {
            Debug.DrawRay(_fireTransform.position, _fireTransform.TransformDirection(Vector3.back) * 1000, Color.blue);
            Debug.Log("Did not Hit");
        }
    }

    // IEnumerator WaitAndPour()
    // {
    //     while(true)
    //     {
    //         yield return new WaitForSeconds(0.5f);
    //         Instantiate(_cakePrfb, _fireTransform.position, Quaternion.identity).DOMoveY((_cakePrfb.position.y), 0.2f);
    //     }
    // }
    
}
