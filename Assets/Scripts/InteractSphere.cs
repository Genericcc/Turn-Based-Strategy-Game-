using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSphere : MonoBehaviour, IInteractable
{
    [SerializeField] private Material greenMaterial;
    [SerializeField] private Material redMaterial;
    [SerializeField] private MeshRenderer meshRenderer;

    private GridPosition gridPosition;
    private Action onInteractionComplete;

    private float timer;
    private bool isActive;
    private bool isGreen;

    private void Start() 
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.SetInteractableAtGridPosition(gridPosition, this);

        SetColorRed();
    }

    private void Update() 
    {
        if(!isActive)
        {
            return;
        }

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            isActive = false;
            onInteractionComplete();
        }
    }

    private void SetColorGreen()
    {
        isGreen = true;
        meshRenderer.material = greenMaterial;
    }

    private void SetColorRed()
    {
        isGreen = false;
        meshRenderer.material = redMaterial;
    }

    public void Interact(Action onInteractionComplete)
    {
        this.onInteractionComplete = onInteractionComplete;
        isActive = true;
        timer = .5f;

        if(isGreen)
        {
            SetColorRed();
        } else 
        {
            SetColorGreen();
        }
    }

    public bool IsSphereGreen()
    {
        if(isGreen)
        {
            return true;
        }

        return false;
    }
}
