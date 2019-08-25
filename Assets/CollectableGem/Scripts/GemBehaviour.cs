﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Interface defining messages that can be sent to the gem.
/// </summary>
public interface ICollectibleEvents
{
    HealthBoost OnItemCollected();
}

public struct HealthBoost
{
    public HealthBoost(float energy)
    {
        Energy = energy;
    }

    public float Energy { get; }
}

public class GemBehaviour : MonoBehaviour, ICollectibleEvents
{
    private float _durationOfCollectedParticleSystem;

    [SerializeField] private GameObject collectedParticleSystem;
    [SerializeField] private CircleCollider2D gemCollider2D;
    [SerializeField] private int points = 100;

    [Header("References")]
    [SerializeField] private GameObject gemVisuals;

    private void Start()
    {
        _durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
    }

    private IEnumerator DeactivateGameObject(float time)
    {
        yield return new WaitForSeconds(time);
        
        gameObject.SetActive(false);
    }

    public HealthBoost OnItemCollected()
    {
        gemCollider2D.enabled = false;
        gemVisuals.SetActive(false);
        collectedParticleSystem.SetActive(true);
        
        StartCoroutine(DeactivateGameObject(_durationOfCollectedParticleSystem));
        
        return new HealthBoost(10);
    }
}
