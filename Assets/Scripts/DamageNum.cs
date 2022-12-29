using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageNumbersPro;
using DG.Tweening;
using TMPro;


public class DamageNum : MonoBehaviour
{
    public static DamageNum Instance;
    [SerializeField] public DamageNumber numberPrefab;
    [SerializeField] public DamageNumber numberPrefabDecrease;
    [SerializeField] public TMP_Text _money;
    private Transform _playerTranform;
    // private float _numberMultipl = 2.3f;
    // private float _newnumberMultipl;
    private float _totalMoneyInOneRound = 0;
    [SerializeField] MoneySO _data;

    public float TotalMoney => _totalMoneyInOneRound;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    

    public void ShowNumber(float numberMultpl, Transform _transform)
    {
        // for (int i = 1; i < CollectedCoffeeData.Instance.CoffeeList.Count; i++)
        // {
            float NewnumberMultipl = numberMultpl;
            // _newnumberMultipl = NewnumberMultipl;
            _data.Money += System.Convert.ToInt32(NewnumberMultipl);
            _totalMoneyInOneRound++;

        // }
        DamageNumber damageNumber = numberPrefab.Spawn(_transform.position, NewnumberMultipl);
        _money.text = System.Convert.ToInt32(_data.Money).ToString();
    }

    public void ShowNumberDecrease(float numberMultpl, Transform _transform)
    {
        // for (int i = 1; i < CollectedCoffeeData.Instance.CoffeeList.Count; i++)
        // {
            float NewnumberMultipl = numberMultpl;
            // _newnumberMultipl = NewnumberMultipl;
            _data.Money -= System.Convert.ToInt32(NewnumberMultipl);
            _totalMoneyInOneRound--;

        // }
        DamageNumber damageNumber = numberPrefabDecrease.Spawn(_transform.position, NewnumberMultipl);
        if ( _data.Money < 0)
             _data.Money = 0;
        else
            _money.text = System.Convert.ToInt32( _data.Money).ToString();

    }

}
