using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpellSystem : MonoBehaviour
{
    public float damage;
    public Transform projectileSpawn;

    protected virtual void OnCast(XRBaseInteractor interactor)
    {

    }

    protected virtual void StartShooting(XRBaseInteractor interactor)
    {

    }

    public virtual void Shoot()
    {

    }

    protected virtual void StopShooting(XRBaseInteractor interactor)
    {

    }

    public float GetDamage()
    {
        return damage;
    }

}
