using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Spell_Fire : SpellSystem
{
    [SerializeField] GameObject fireProjectile;
    [SerializeField] float force = 8;

    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        Shoot();
    }

    public override void Shoot()
    {
        Debug.Log("Fire Shoot");
        //base.Shoot();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Spells/Fire");
        GameObject projectileInstance = Instantiate(fireProjectile, projectileSpawn.position, projectileSpawn.rotation);
        projectileInstance.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * force, ForceMode.VelocityChange);
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }
}
