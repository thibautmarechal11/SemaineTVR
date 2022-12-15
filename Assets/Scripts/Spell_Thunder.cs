using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Spell_Thunder : SpellSystem
{
    [SerializeField] GameObject thunderProjectile;
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
        GameObject projectileInstance = Instantiate(thunderProjectile, projectileSpawn.position, projectileSpawn.rotation);
        projectileInstance.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * force, ForceMode.VelocityChange);
    }

    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor);
    }
}
