using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public PlayerAnimation playerAnimation;
    public PlayerInputs playerInputs;
    public PlayerMovement playerMovement;
    public PlayerAttack playerAttack;

    public void Awake()
    {
        Instance = this;
        playerAttack = new PlayerAttack();
        playerInputs = new PlayerInputs();
    }
    private void Start()
    {
        playerMovement.OnStart();   
    }
    private void Update()
    {
        playerInputs.OnUpdate();
        playerAttack.OnUpdate();
        playerMovement.OnUpdate();
    }

    private void LateUpdate()
    {
        playerInputs.OnLateUpdate();
    }
}
