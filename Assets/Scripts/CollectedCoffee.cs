using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class CollectedCoffee : MonoBehaviour
{

    public PlayerController Parent;
    private float count = 0;
    Sequence seq;

    private void Start() {
        
    }
    private void Update()
    {
        // count += Time.deltaTime;
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Collactable"))
    //     {
    //         other.tag = "Collected";
    //         CollectedCoffeeData.Instance.CoffeeList.Add(other.transform);
    //         other.gameObject.AddComponent<CollectedCoffee>();
    //         other.gameObject.AddComponent<Rigidbody>().isKinematic = true;

    //         var seq = DOTween.Sequence();
    //         seq.Kill();
    //         seq = DOTween.Sequence();
    //         for (int i = CollectedCoffeeData.Instance.CoffeeList.Count - 1; i > 0; i--)
    //         {
    //             seq.Join(CollectedCoffeeData.Instance.CoffeeList[i].DOScale(1.5f, 0.2f));
    //             seq.AppendInterval(0.05f);
    //             seq.Join(CollectedCoffeeData.Instance.CoffeeList[i].DOScale(1f, 0.2f));
    //         }
    //     }

    //     if (other.CompareTag("Obstacles"))
    //     {
    //         other.transform.tag = "Touched";
    //         foreach (var item in CollectedCoffeeData.Instance.CoffeeList.TakeLast(Random.Range(1, CollectedCoffeeData.Instance.CoffeeList.Count-1)))
    //         {
    //             item.tag = "Collactable";
    //             print(item);
    //             seq.Join(item.DOScale(new Vector3(1.7f,1.5f,1.3f), 0.4f));
    //             seq.Append(item.DOLocalJump(new Vector3(Random.Range(-5, 5),-2.87f, Random.Range(-2, 15)), 0.7f, 1, 0.4f));
    //             seq.Join(item.DOScale(new Vector3(1,1,1), 0.4f));
                
    //             CollectedCoffeeData.Instance.CoffeeList.Remove(item);
    //             // item.position += new Vector3(Random.Range(2,6),0,Random.Range(2,6));
    //         }



    //     }

    // }

}
