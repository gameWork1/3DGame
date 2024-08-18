using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DestController : MonoBehaviour
{
    public static DestController instance;
    private string rightAnswerCurrent;
    [SerializeField] private InputField Input;
    public UnityEvent OnInit;
    public UnityEvent AfterInit;
    private DestTrigger lastDest;

    private void Start()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void StartDest(string rightAnswer, DestTrigger trigger)
    {
        rightAnswerCurrent = rightAnswer;
        lastDest = trigger;
        InitiateGameObjects();
    }

    public void CheckAnswer()
    {
        if(Input.text == rightAnswerCurrent)
        {
            SwitchOffGameObjects();
            lastDest.isAnswered = true;
        }
        else 
        {
            lastDest.GetComponent<Animator>().SetTrigger("fall");
            SwitchOffGameObjects();
            
        }
        Input.text = "";
    } 

    void InitiateGameObjects()
    {
        OnInit.Invoke();
    }

    void SwitchOffGameObjects()
    {
        AfterInit.Invoke();
    }

}
