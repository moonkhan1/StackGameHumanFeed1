using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using CASP.CameraManager;
using CASP.SoundManager;

public class FinalRoadPancakes : MonoBehaviour
{
    private PlayerController _player;
    // [SerializeField] public GameObject _finalMoney;
    [SerializeField] public Transform _jumpPos;
    private Sequence seq3;
    private float _waitAndJump = 0;
    public event System.Action OnFinish;
    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
    }

    private void FixedUpdate() {
        
    }


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            seq3 = DOTween.Sequence();
            _player.GetComponent<PlayerController>().isFinished = true; 
            StartCoroutine(WaitAndRemove(0, 0.2f));
            StartCoroutine(WaitAndRemove(1, 0.2f));
            CameraManager.instance.OpenCamera("Head", 0.4f, CameraEaseStates.EaseIn);

        }
    }

    IEnumerator WaitAndRemove(int _ind, float _time)
    {
        
            for (int i = CollectedCoffeeData.Instance.CoffeeList[_ind].Count-1; i > 0; i--)
            {
            
                Transform go = CollectedCoffeeData.Instance.CoffeeList[_ind][i];
                CollectedCoffeeData.Instance.CoffeeList[_ind].Remove(go);
                go.gameObject.SetActive(false);
                for (int j = 0; j < CollectedCoffeeData.Instance.CoffeeList[_ind].Count; j++)
                {
                    
                CollectedCoffeeData.Instance.Meshes[j].gameObject.SetActive(true);
                // SoundManager.Instance.Play("FinalJump");
                yield return new WaitForSeconds(_time);
                }
            }
                CollectedCoffeeData.Instance.Meshes.ForEach(u =>{
                    u.transform.DOJump(_jumpPos.transform.position, 0.6f, 1, 1f);
                });
            

            if(CollectedCoffeeData.Instance.CoffeeList[0].Count == 1 && CollectedCoffeeData.Instance.CoffeeList[1].Count == 1)
            {
                OnFinish?.Invoke();
                SoundManager.Instance.Play("Win");
            }
            
        

    }


}
