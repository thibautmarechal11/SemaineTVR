using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Spell_Air : SpellSystem
{
    [SerializeField] GameObject airProjectile;
    [SerializeField] float force = 8;

    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        Shoot();
    }

    public override void Shoot()
    {
        Debug.Log("Air Shoot");
        //base.Shoot();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Spells/Wind");
        GameObject projectileInstance = Instantiate(airProjectile, projectileSpawn.position, projectileSpawn.rotation);
        projectileInstance.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * force, ForceMode.VelocityChange);
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }
}
