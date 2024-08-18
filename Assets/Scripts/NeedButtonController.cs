using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedButtonController : MonoBehaviour
{
    [SerializeField] private GameObject needButton;
    [HideInInspector] public static NeedButtonController instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetTextButton(string image)
    {
        needButton.gameObject.SetActive(true);
        needButton.GetComponentInChildren<Text>().text = image;
    }

    public void ClearButton()
    {
        needButton.gameObject.SetActive(false);
    }
}
