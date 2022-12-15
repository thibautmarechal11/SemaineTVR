using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;


public class SpellController : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;


    /*[HideInInspector]*/
    [SerializeField] Spell currentSpell;
    public string currentSpellName;
    
    Spell_Fire spell_Fire;
    Spell_Ice spell_Ice;
    Spell_Air spell_Air;
    public enum Spell
    {
        Nothing,
        Fire,
        Ice,
        Air
    }

    private void Awake()
    {
        spell_Ice = GetComponent<Spell_Ice>();
        spell_Fire = GetComponent<Spell_Fire>();
        spell_Air = GetComponent<Spell_Air>();
    }

    private void Update()
    {
        if (currentSpellName != null)
        {
            switch (currentSpellName)
            {
                case "nothing":
                    Debug.Log("Nothing");
                    currentSpell = Spell.Nothing;
                    break;
                case "fire":
                    Debug.Log("Fire");
                    currentSpell = Spell.Fire;
                    break;
                case "ice":
                    Debug.Log("Ice");
                    currentSpell = Spell.Ice;
                    break;
                case "air":
                    Debug.Log("Air");
                    currentSpell = Spell.Air;
                    break;
            }
            currentSpellName = null;
        }
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed);

        if (isPressed) Shoot();
    }

    void Shoot()
    {
        Debug.Log("Shoot");

        if (currentSpell != Spell.Nothing)
        {
            switch (currentSpell)
            {
                case Spell.Nothing:
                    break;
                case Spell.Fire:
                    Debug.Log("FireDetectedToShoot");
                    spell_Fire.Shoot();
                    currentSpell = Spell.Nothing;
                    break;
                case Spell.Ice:
                    Debug.Log("IceDetectedToShoot");
                    spell_Ice.Shoot();
                    currentSpell = Spell.Nothing;
                    break;
                case Spell.Air:
                    Debug.Log("AirDetectedToShoot");
                    spell_Air.Shoot();
                    currentSpell = Spell.Nothing;
                    break;
                default:
                    break;
            }
        }

    }

}
