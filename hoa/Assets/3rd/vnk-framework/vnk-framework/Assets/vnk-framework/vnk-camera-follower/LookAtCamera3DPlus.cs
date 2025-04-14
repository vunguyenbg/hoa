
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LookAtCamera3DPlus : MonoBehaviour
{
    [SerializeField] private bool activeOnEnable = true;
    [SerializeField] private bool activeOnStart = true;
    [SerializeField] private bool isUpdate = true;
    [SerializeField, ShowIf("isUpdate", true)] private int countTimesForUpdate;
    [SerializeField, ShowIf("isUpdate", true)] private int maxTimesForUpdate = 10;
    void Start()
    {
        if (activeOnStart)
            OnActive();
    }
    private void OnEnable()
    {
        if (activeOnEnable)
            OnActive();
    }
    void OnActive()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        //transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
    }
    void OnReset()
    {
        transform.localRotation = Quaternion.identity;
    }
    private void LateUpdate()
    {
        if (isUpdate)
        {
            if (AcceptUpdate())
            {
                OnActive();
            }
        }
    }
    bool AcceptUpdate()
    {
        if (countTimesForUpdate > 0)
        {
            countTimesForUpdate--;
            return false;
        }
        else
        {
            countTimesForUpdate = maxTimesForUpdate;
            return true;
        }
    }

    [Button]
    void LookAtCamera()
    {
        OnActive();
    }
    [Button]
    void ResetCamera()
    {
        OnReset();
    }
}
