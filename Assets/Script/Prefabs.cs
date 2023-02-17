using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prefabs : MonoBehaviour
{
    // use Serializable to inspect variables without using Public
    [SerializeField]
    private GameObject buttonRestart;
    // Create titles for variables
    [Header("Knife Count Display")]
    [SerializeField]
    private GameObject panelKnife;
    [SerializeField]
    private GameObject shadowKnife;
    [SerializeField]
    private Color fuzzyKnife;

    // Enforcement()
    public void showRestart()
    {
        buttonRestart.SetActive(true);
    }
    
    public void SetKnifeCountDisplay(int countKnife)
    {
        for (int i = 0; i < countKnife + 1; i++)
        {
            Instantiate(shadowKnife, panelKnife.transform);
        }
    }

    // Including the original knife
    private int indexKnifeChange = 0;

    // Abatement displayed knife count
    public void reductionKnife()
    {
        // If reduced, the knife will fade
        panelKnife.transform.GetChild(indexKnifeChange++).GetComponent<Image>().color = fuzzyKnife;
    }

}
