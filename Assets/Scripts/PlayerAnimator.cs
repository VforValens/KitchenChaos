using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [SerializeField] private Player player;
    private Animator animator;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IsWalking, player.IsWalking());
    }
    
}
