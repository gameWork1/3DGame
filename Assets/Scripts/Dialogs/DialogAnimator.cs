using UnityEngine;
using UnityEngine.Events;

public class DialogAnimator : MonoBehaviour
{
    private Animator anim;
    [SerializeField]private DialogController DC;

    private void Start()
    {
        anim= GetComponent<Animator>();
    }
    public void OpenDialogBox(string name, string[] dialogContent, UnityEvent action)
    {
        if (!DC.isStartDialog)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            DC.SetDialog(dialogContent);
            DC.SetNameDialog(name);
            DC.SetAction(action);
            anim.SetBool("isOpen", true);
            DC.StartDialog();
        }
        
    }
    public void CloseDialogBox()
    {
        anim.SetBool("isOpen", false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
