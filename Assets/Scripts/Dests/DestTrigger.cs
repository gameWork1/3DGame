using UnityEngine;

public class DestTrigger : MonoBehaviour
{
    [SerializeField] private string rightAnswer;
    [HideInInspector]public bool isAnswered;
    [SerializeField] private GameObject rebus;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isAnswered)
        {
            DestController.instance.StartDest(rightAnswer, this);
        }
    }

    private void Update()
    {
        if(isAnswered) rebus.SetActive(false);
        else rebus.SetActive(true);
    }
}
