using UnityEngine;

public class PlayerInputs
{
    public PlayerInput inputActions;
    public Vector2 vector2Input;
    public bool attackInput, blockInput;

    public float horizontal, vertical, moveAmount;

    public PlayerInputs()
    {
        inputActions = new PlayerInput();
        inputActions.PlayerMovement.Movement.performed += i => vector2Input = i.ReadValue<Vector2>();
        inputActions.PlayerMovement.AttackLight.performed += i => attackInput = true;
        inputActions.PlayerMovement.Block.performed += i => blockInput = true;
        inputActions.Enable();
    }

    public void OnUpdate()
    {
        horizontal = vector2Input.x;
        vertical = vector2Input.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }

    public void OnLateUpdate()
    {
        attackInput = false;
        blockInput = false;
    }
}
