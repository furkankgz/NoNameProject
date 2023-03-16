using UnityEngine;

public class PlayerAttack
{
    public bool isAttacking, isBlocking;

    public void OnUpdate()
    {
        if (Player.Instance.playerInputs.attackInput == true && !isAttacking)
        {
            Player.Instance.playerAnimation.PlayLightAttackAnimation(true);
            isAttacking = true; 
        }

        if (Player.Instance.playerInputs.blockInput == true && !isBlocking)
        {
            Player.Instance.playerAnimation.PlayBlockAnimation(true);
            isBlocking = true;
        }
    }
}
