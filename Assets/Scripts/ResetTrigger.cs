using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    private PlayerController player;
    private bool collide;
    [SerializeField] private float startTime;
    private float time;

    private void Start()
    {
        time = startTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            collide = true;
            TransitionController.instance.StartTransition();
            DestController.instance.AfterInit.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if (collide)
        {
            if(time > 0)
                time -= Time.deltaTime;
            else
            {

                player.transform.position = player.startPos;
                time = startTime;
                collide = false;
            }
        }
    }
}
