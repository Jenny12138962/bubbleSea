using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TrashCounter : MonoBehaviour
{
    public RectTransform fill;
    public RectTransform handle;
    public int maxCollectableTrash = 10;
    private SliderDisplay sliderDisplay;
    private int count;
    private float maxHandlePos = 160;
    private float maxFillLength = 180;

    void Awake()
    {
        sliderDisplay = transform.GetComponentInChildren<SliderDisplay>();
    }
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        UpdateConsole();
    }

    // Update is called when the energy is updated
    public void UpdateTrashCount()
    {
        count ++;
        UpdateConsole();
    }
    private void UpdateConsole()
    {
        if (count >= maxCollectableTrash)
            return;
        sliderDisplay.UpdateProgressBar(count, maxCollectableTrash);
    }
}
