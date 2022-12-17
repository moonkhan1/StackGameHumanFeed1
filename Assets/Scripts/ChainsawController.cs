using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChainsawController : MonoBehaviour
{
    private Transform _transform;
    private Transform _patrolPos;
    void Start()
    {
        _patrolPos = GetComponent<Transform>().GetChild(0);
        _transform = GetComponent<Transform>();
        _transform.DORotate(new Vector3(0,0,360), 1f, RotateMode.FastBeyond360)
        .SetLoops(-1, LoopType.Incremental)
        .SetRelative()
        .SetEase(Ease.Linear);
        _transform.DOMoveX(_patrolPos.position.x, 2f).SetLoops(-1, LoopType.Yoyo)
        .SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
