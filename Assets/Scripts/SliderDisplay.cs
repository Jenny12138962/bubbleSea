using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderDisplay : MonoBehaviour
{
    public Slider progressBar;
    void Start()
    {
        progressBar.value = 0;
    }

    public void UpdateProgressBar(int currentEnergy, int totalEnergy)
    {
        float percentage = (float)currentEnergy / totalEnergy;
        progressBar.value = percentage;
    }
}
