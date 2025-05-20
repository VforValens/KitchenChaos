using UnityEngine;

public class StoveBurnFlashingBarUI : MonoBehaviour {


    private const string IsFlashing = "IsFlashing";


    [SerializeField] private StoveCounter stoveCounter;


    private Animator animator;


    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;

        animator.SetBool(IsFlashing, false);
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e) {
        float burnShowProgressAmount = .5f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;

        animator.SetBool(IsFlashing, show);
    }

}
