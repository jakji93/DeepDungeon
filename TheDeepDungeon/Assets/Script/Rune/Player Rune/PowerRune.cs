using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runes
{
    public class PowerRune : PlayerRune
    {
        public float damageIncrease;

        // Start is called before the first frame update

        public override void DestroyRune()
        {
            if (PlayerIsInside && GetPlayerInside()) WhenPlayerLeaves();
            Destroy(gameObject);
        }

        public override void WhenPlayerEnters()
        {
            PlayerOnject.GetComponent<PlayerAttack>().IncreaseAttackBuff(damageIncrease);
        }

        public override void WhenPlayerStay()
        {
            return;
        }

        public override void WhenPlayerLeaves()
        {
            PlayerOnject.GetComponent<PlayerAttack>().DecreaseAttackBuff(damageIncrease);
        }
    } 
}
