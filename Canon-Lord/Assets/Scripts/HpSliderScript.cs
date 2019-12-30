using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSliderScript : MonoBehaviour
{
    [SerializeField] Slider hpSlider;

    HpScript hpScript;
    // Start is called before the first frame update
    void Start()
    {
        hpScript = GetComponent<HpScript>();
        hpSlider.minValue = 0;
        hpSlider.maxValue = hpScript.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = hpScript.Hp;
    }
}
