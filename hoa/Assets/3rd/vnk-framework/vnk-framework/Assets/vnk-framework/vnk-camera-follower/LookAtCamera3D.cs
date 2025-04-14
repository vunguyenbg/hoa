using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LookAtCamera3D : MonoBehaviour
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
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back, Camera.main.transform.rotation * Vector3.down);
        transform.localScale = new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y), transform.localScale.z);
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
}
