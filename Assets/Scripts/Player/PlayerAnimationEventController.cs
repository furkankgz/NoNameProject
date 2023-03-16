using UnityEngine;

public class PlayerAnimationEventController : MonoBehaviour
{
    public void ResetAttackStatus()
    {
        Player.Instance.playerAttack.isAttacking = false;
        Player.Instance.playerAnimation.PlayLightAttackAnimation(false);
    }

    public void ResetBlockStatus()
    {
        Player.Instance.playerAttack.isBlocking = false;
        Player.Instance.playerAnimation.PlayBlockAnimation(false);
    }

}
