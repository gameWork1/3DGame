using UnityEngine;
using UnityEngine.Events;

public class ActionTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent action;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            action.Invoke();
        }
    }
}
