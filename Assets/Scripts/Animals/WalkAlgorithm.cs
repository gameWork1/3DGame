using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WalkAlgorithm : MonoBehaviour
{
    [SerializeField] private Vector2 startWaitTime;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float speed;
    private float waitTime;
    private int index;

    private void Start()
    {
        waitTime = Random.RandomRange(startWaitTime.x, startWaitTime.y);
    }

    private void OnDrawGizmos()
    {
        
        for(int i = 1; i <= wayPoints.Length; i++)
        {
            Gizmos.color = Color.cyan;
            if (i != wayPoints.Length)
                Gizmos.DrawLine(wayPoints[i - 1].position, wayPoints[i].position);
            else
                Gizmos.DrawLine(wayPoints[i - 1].position, wayPoints[0].position);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(wayPoints[i].position, wayPoints[i].transform.forward);
        }
    }

    private void Update()
    {
        if (waitTime <= 0)
        {
            if(CheckTransform())
                waitTime = Random.RandomRange(startWaitTime.x, startWaitTime.y);
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(wayPoints[index].position.x, transform.position.y, wayPoints[index].position.z), speed * Time.deltaTime);
            }
        }
        else
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, wayPoints[index].position, speed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            waitTime -= Time.deltaTime;
        }
            
    }

    bool CheckTransform()
    {
        if (new Vector2(transform.position.x, transform.position.z) == new Vector2(wayPoints[index].position.x, wayPoints[index].position.z))
        {
            index++;
            if (index == wayPoints.Length)
                index = 0;
            
            
            return true;
        }

        return false;
    }

}
