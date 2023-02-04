using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_SpellsBehaviour : MonoBehaviour
{

    public P_PlayerSpells playerSpellScript;

    private Animator spellsAnimator;

    public void spellMelee()
    {
        spellsAnimator.SetTrigger("spellMelee");
    }
}
