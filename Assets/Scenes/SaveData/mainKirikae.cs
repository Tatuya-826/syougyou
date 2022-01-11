using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainkirikae : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject subPanel;

    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
    }

    public void SubView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(true);
    }
}
