using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    private string[] DialogContent;
    [SerializeField] private Text Name;
    [SerializeField] private Text dialogText;
    [SerializeField] private float writeWaitingTime;
    [SerializeField] private DialogAnimator DA;
    [HideInInspector] public bool isStartDialog;
    [HideInInspector] public static DialogController instance;
    private UnityEvent action;
    private int index;

    private void Start()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetDialog(string[] dialog) => DialogContent = dialog;

    public void SetNameDialog(string name)
    {
        Name.text = name;
    }
    public void SetAction(UnityEvent action) => this.action = action;

    public void StartDialog()
    {
        if (Calculatore.instance.panel.GetBool("isOpen"))
            Calculatore.instance.SwitchModeCalculator();
        dialogText.text = "";
        isStartDialog = true;
        StartCoroutine(SlowWriteSentence(dialogText, DialogContent[index]));
    }

    public void NextSentence()
    {
        index++;
        if(index != DialogContent.Length)
        {
            StopAllCoroutines();
            dialogText.text = "";
            StartCoroutine(SlowWriteSentence(dialogText, DialogContent[index]));
        }
        else
        {
            DA.CloseDialogBox();
            isStartDialog = false;
            index = 0;
            if(action != null)
                action.Invoke();
            action = null;
        }
        

    }

    IEnumerator SlowWriteSentence(Text text, string sentence)
    {
        foreach(char i in sentence)
        {
            text.text += i;
            if (i == ',')
                yield return new WaitForSeconds(writeWaitingTime + 0.35f);
            else
                yield return new WaitForSeconds(writeWaitingTime);
        }
    }
}
