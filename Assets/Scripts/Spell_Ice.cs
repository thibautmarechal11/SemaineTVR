using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Spell_Ice : SpellSystem
{
    [SerializeField] GameObject iceProjectile;
    [SerializeField] float force = 6;

    protected override void StartShooting(XRBaseInteractor interactor)
    {
        base.StartShooting(interactor);
        Shoot();
    }

    public override void Shoot()
    {
        Debug.Log("Ice Shoot");
        //base.Shoot();
        GameObject projectileInstance = Instantiate(iceProjectile, projectileSpawn.position, projectileSpawn.rotation);
        projectileInstance.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * force, ForceMode.VelocityChange);
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }
}
