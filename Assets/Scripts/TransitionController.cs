using UnityEngine;

public class TransitionController : MonoBehaviour
{
    [HideInInspector] public static TransitionController instance;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
    }

    public void StartTransition()
    {
        anim.SetBool("isWalk", !anim.GetBool("isWalk"));
    }
}
