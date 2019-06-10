using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUse : MonoBehaviour
{
    public Movement gauge;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        gauge = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = gauge.specialGauge / 100;
    }
}
