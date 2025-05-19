using System;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private static readonly int OpenClose = Animator.StringToHash(OPEN_CLOSE);


    private const string OPEN_CLOSE = "OpenClose";
    
    
    [SerializeField] private ContainerCounter containerCounter;
    
    
    private Animator animator;
    
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        containerCounter.OnPlayerGrabsObject += ContainerCounter_OnPlayerGrabsObject;
    }
    
    private void ContainerCounter_OnPlayerGrabsObject(object sender, EventArgs e)
    {
        animator.SetTrigger(OpenClose);
    }
    
}
