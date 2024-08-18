using System;
using UnityEngine;
using UnityEngine.UI;

public class Calculatore : MonoBehaviour
{
    [SerializeField] private Text text;
    public Animator panel;
    [HideInInspector] public static Calculatore instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SwitchModeCalculator()
    {
        if (!DialogController.instance.isStartDialog)
        {
            panel.SetBool("isOpen", !panel.GetBool("isOpen"));
            if (panel.GetBool("isOpen"))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
        }
       

    }


    public void Clear()
    {
        text.text = "0";
    }

    public void WriteSymbol(GameObject button)
    {
        string symbol = button.GetComponentInChildren<Text>().text;
        if (text.text == "0") text.text = "";
        if ((text.text.Contains("+") && symbol == "+") || (text.text.Contains("-") && symbol == "-") ||
            (text.text.Contains("-") && symbol == "+") || (text.text.Contains("+") && symbol == "-")) return;
        text.text += symbol;
    }

    public void Calculate()
    {
        if(text.text.Split('+').Length > 1)
        {
            long first = long.Parse(text.text.Split("+")[0]);
            long second = long.Parse(text.text.Split("+")[1]);
            text.text = Convert.ToString(first + second);
        }
        else if (text.text.Split('-').Length > 1)
        {
            int first = int.Parse(text.text.Split("-")[0]);
            int second = int.Parse(text.text.Split("-")[1]);
            text.text = Convert.ToString(first - second);
        }
    }
}
