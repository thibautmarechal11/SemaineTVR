using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;


public class SpellController : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;


    [HideInInspector] Spell currentSpell;    
    
    Spell_Fire spell_Fire;
    public enum Spell
    {
        Nothing,
        Fire
    }

    private void Awake()
    {
        spell_Fire = GetComponent<Spell_Fire>();
    }

    private void Update()
    {
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
                    break;
                default:
                    break;
            }
        }
    }

}
