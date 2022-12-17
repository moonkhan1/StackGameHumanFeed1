using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using CASP.SoundManager;
public class PlayerController : MonoBehaviour
{
    private float Horizontal;
    [SerializeField] private float VerticalSpeed;
    private Transform _transform;
    [SerializeField] Transform[] _jumpTransform;
    [SerializeField] public float _speed = 10f;
    [SerializeField] private float LerpSpeed = 10f;
    [SerializeField] private float OffSet = 2f;
    public bool isFinished = false;



    void Start()
    {
        _transform = GetComponent<Transform>();
        // CollectedCoffeeData.Instance.CoffeeList[0].Add(_transform.GetChild(0));
        // CollectedCoffeeData.Instance.CoffeeList[1].Add(_transform.GetChild(1));
        // CollectedCoffeeData.Instance.CoffeeList[2].Add(_transform.GetChild(2));
        // CollectedCoffeeData.Instance.CoffeeList[3].Add(_transform.GetChild(3));


        // _jumpTransform = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinished)
        {
            float movement = (_speed * Input.GetAxis("Horizontal")) * Time.deltaTime;
            _transform.Translate(1 * movement, (Time.deltaTime * _speed * -1), 0);
            _transform.localPosition = new Vector3((Mathf.Clamp(transform.localPosition.x, 56, 66.6f)), transform.localPosition.y, transform.localPosition.z);
        }
        // _transform.position += new Vector3(Horizontal, 0, VerticalSpeed) * _speed * Time.deltaTime;
        if (CollectedCoffeeData.Instance.CoffeeList.Count > 1)
            CoffeeFollow();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collactable"))
        {
            CollectedCoffeeData.Instance.CoffeeList[Random.Range(0, 2)].Add(other.transform);
            other.tag = "Collected";
            SoundManager.Instance.Play("Collect"); 
            DamageNum.Instance.ShowNumber(4, _transform);
            other.gameObject.AddComponent<CollectedCoffee>();
            if (other.gameObject.GetComponent<Rigidbody>() == null)
            {
                other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            }
            var seq = DOTween.Sequence();
            seq.Kill();
            seq = DOTween.Sequence();
            foreach (var item in CollectedCoffeeData.Instance.CoffeeList)
            {
                for (int i = item.Count-1; i > 0; i--)
                {
                    // item[i].parent = item[0];
                    seq.Join(item[i].DOJump(new Vector3(item[i].position.x, item[i].position.y, item[i].position.z), 2f, 1, 0.2f));
                    // seq.Append(item[i].DOScale(new Vector3(item[0].localScale.x, item[0].localScale.y, item[0].localScale.z), 0.2f));
                    Debug.Log("item");
                    // seq.Join(CollectedCoffeeData.Instance.CoffeeList[i].DOScale(new Vector3(160, 191, 75), 0.2f));
                }
            }


        }

        if (other.CompareTag("Obstacles"))
        {
            // other.transform.tag = "Touched";
            SoundManager.Instance.Play("Damage");
            foreach (var item in CollectedCoffeeData.Instance.CoffeeList[Random.Range(0,2)].TakeLast(Random.Range(1, CollectedCoffeeData.Instance.CoffeeList.Count-1)))
            {
                DamageNum.Instance.ShowNumberDecrease(5, _transform); 
                var seq = DOTween.Sequence();
                seq.Kill();
                seq = DOTween.Sequence();
                // item.tag = "Collactable";
                // item.parent = this.transform;
                print(item);
                _transform.DOJump(new Vector3(_transform.position.x, _transform.position.y, _transform.position.z-13), 0.4f, 1, 0.5f);
                seq.Append(item.DOJump(new Vector3(item.position.x + Random.Range(-2, 2), 1.2f, (item.position.z + Random.Range(2, 7))), 0.7f, 1, 0.4f));
                Debug.Log(item.position);
                CollectedCoffeeData.Instance.CoffeeList.ForEach(u => {
                u.RemoveAll(a => a == item);
                });
                StartCoroutine(WaitAndMakeCollactabel(item));
            }



        }
    }

    public void CoffeeFollow()
    {
        foreach (var item in CollectedCoffeeData.Instance.CoffeeList)
        {
            for (int i = 1; i < item.Count; i++)
            {

                Vector3 PrevPos = item[i - 1].position + Vector3.up * OffSet;
                PrevPos.z = _transform.position.z;
                if(item[i].transform.position!=null){
                    Vector3 CurrentPos = item[i].transform.position;
                    item[i].transform.position = Vector3.Lerp(CurrentPos, PrevPos, LerpSpeed * Time.deltaTime);
                }
                
            }
        }
    }

    IEnumerator WaitAndMakeCollactabel(Transform item)
    {
        
        yield return new WaitForSeconds(0.4f);
        item.tag = "Collactable";
        
    }


}
