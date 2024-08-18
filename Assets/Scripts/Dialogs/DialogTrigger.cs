using UnityEngine;
using UnityEngine.Events;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private string[] DialogContent;
    [SerializeField] private string Name;
    [SerializeField] private UnityEvent action;
    private DialogAnimator DA;
    private bool playerIsNear;

    private void Start()
    {
        DA = GameObject.FindWithTag("DialogController").GetComponent<DialogAnimator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
            NeedButtonController.instance.SetTextButton("E");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            NeedButtonController.instance.ClearButton();
        }
    }

    private void Update()
    {
        if (playerIsNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                NeedButtonController.instance.ClearButton();
                DA.OpenDialogBox(Name, DialogContent, action);
            }
        }
    }

}
