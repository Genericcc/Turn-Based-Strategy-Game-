using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleCrate : MonoBehaviour
{
    public static event EventHandler OnAnyDestroyed;

    [SerializeField] private Transform destroyedCratePrefab;

    private GridPosition gridPosition;

    private void Start() 
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
    }

    public void Damage()
    {
        Transform destroyedCrateTransform = Instantiate(destroyedCratePrefab, transform.position, transform.rotation);

        ApplyExplosionToChildren(destroyedCrateTransform, 150f, transform.position, 10f);

        Destroy(gameObject);

        OnAnyDestroyed?.Invoke(this, EventArgs.Empty);
    }
    
    private void ApplyExplosionToChildren(Transform root, float explosionForce, Vector3 explosionPosition, float exploasionRange)
    {
        foreach(Transform child in root)
        {
            if(child.TryGetComponent<Rigidbody>(out Rigidbody childRigidbody))
            {
                childRigidbody.AddExplosionForce(explosionForce, explosionPosition, exploasionRange);
            }

            ApplyExplosionToChildren(child, explosionForce, explosionPosition, exploasionRange);
        }
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }


}
