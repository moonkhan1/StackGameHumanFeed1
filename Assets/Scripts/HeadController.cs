using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HeadController : MonoBehaviour
{
    private Transform _transform;
    private Transform _movePos;
    private Transform _movePos2;
    private Transform _upperTooth;
    private Transform _lowerTooth;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _upperTooth = GetComponent<Transform>().GetChild(0);
        _lowerTooth = GetComponent<Transform>().GetChild(1);
        _movePos = GetComponent<Transform>().GetChild(2);
        _movePos2 = GetComponent<Transform>().GetChild(3);
        
        _upperTooth.DOMoveY(_movePos.position.y,0.8f).SetLoops(-1, LoopType.Yoyo);
        _lowerTooth.DOMoveY(_movePos2.position.y,0.8f).SetLoops(-1, LoopType.Yoyo);
        
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
