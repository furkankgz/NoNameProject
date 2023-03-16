using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerMovement
{
    private Rigidbody rigidbody;
    private Vector3 movementDirection, movementAmount;

    public float movementSpeed = 7f;
    public float rotationSpeed = 7f;

    public void OnStart()
    {
        rigidbody = Player.Instance.GetComponent<Rigidbody>();
    }

    public void OnUpdate()
    {
        movementDirection = Camera.main.transform.right * Player.Instance.playerInputs.horizontal;
        movementDirection += Camera.main.transform.forward * Player.Instance.playerInputs.vertical;
        movementDirection.Normalize();
        movementDirection.y = 0;
        movementAmount = movementSpeed * movementDirection;

        if (movementAmount.x != 0 || movementAmount.z != 0)
        {
            Player.Instance.playerAnimation.UpdateAnimatorParameters(1,0);
        }
        else
        {
            Player.Instance.playerAnimation.UpdateAnimatorParameters(0, 0);
        }
        rigidbody.velocity = Vector3.ProjectOnPlane(movementAmount, Vector3.zero);
    }
}
