using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    private void Start()
    {
        instance = this;
    }

    public void SetPlayerPosX(float x)
    {
        Vector3 pos = PlayerController.instance.transform.position;
        PlayerController.instance.transform.position = new Vector3(x, pos.y, pos.z);  
    }
    public void SetPlayerPosY(float x)
    {
        Vector3 pos = PlayerController.instance.transform.position;
        PlayerController.instance.transform.position = new Vector3(pos.x, x, pos.z);
    }
    public void SetPlayerPosZ(float x)
    {
        Vector3 pos = PlayerController.instance.transform.position;
        PlayerController.instance.transform.position = new Vector3(pos.x, pos.y, x);
    }

    public void ToOtherScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
