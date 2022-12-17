using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BabooController : MonoBehaviour
{
    private Transform _transform;
    void Start()
    {
        _transform = GetComponent<Transform>();
         _transform.DORotate(new Vector3(0,transform.position.y, 0), 0.8f, RotateMode.Fast)
        .SetLoops(-1, LoopType.Incremental)
        // .SetRelative()
        .SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
