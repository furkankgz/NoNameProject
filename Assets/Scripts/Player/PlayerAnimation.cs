using UnityEngine;

[System.Serializable]
public class PlayerAnimation 
{
    public Animator animatior;

    public void UpdateAnimatorParameters(float horizontal, float vertical)
    {
        animatior.SetFloat("Horizontal", horizontal);
        animatior.SetFloat("Vertical", vertical);
    }

    public void PlayLightAttackAnimation(bool lightAttackValue)
    {
        UpdateAnimatorParameters(0f, 0f);
        animatior.SetBool("LightAttack", lightAttackValue);
    }

    public void PlayBlockAnimation(bool blockAttackValue)
    {
        UpdateAnimatorParameters(0f, 0f);
        animatior.SetBool("Block", blockAttackValue);
    }
}
