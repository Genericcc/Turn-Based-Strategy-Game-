using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;
    
    private MeshRenderer meshRenderer;

    private void Awake() 
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start() 
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChange;

        UpdateVisual();
    }

    private void UnitActionSystem_OnSelectedUnitChange(object sender, EventArgs empty) 
    {
        if(unit == UnitActionSystem.Instance.GetSelectedUnit()) 
        {
            meshRenderer.enabled = true;
        } else 
        {
            meshRenderer.enabled = false;
        }
    }

    private void UpdateVisual() 
    {
        if(unit == UnitActionSystem.Instance.GetSelectedUnit()) 
        {
            meshRenderer.enabled = true;
        } else 
        {
            meshRenderer.enabled = false;
        }
    }

    private void OnDestroy() 
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged -= UnitActionSystem_OnSelectedUnitChange;
    }
}

