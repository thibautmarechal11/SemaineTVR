using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Spell_Fire : SpellSystem
{
    [SerializeField] GameObject fireProjectile;

    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        Shoot();
    }

    protected override void Shoot()
    {
        base.Shoot();
        GameObject projectileInstance = Instantiate(fireProjectile, projectileSpawn.position, projectileSpawn.rotation);
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }
}
