using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSlider : MonoBehaviour
{
    [SerializeField] public Slider endSlider; 
    //public GameObject sliderObject;
    public float Counter;
    private float activeCounter;
    // Start is called before the first frame update
    void Start()
    {
        activeCounter = Counter;
        //endSlider = sliderObject.GetComponent<Slider>();
        endSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(endSlider.value < 100)
        {
            CountUp();
        }
        if(endSlider.value >= 100)
        {
            Invoke("END", 1);
        }
    }
    void CountUp()
    {
        activeCounter -= Time.deltaTime;
        if(activeCounter <= 0)
        {
            endSlider.value += 1;
            activeCounter = Counter;
        }
    }
    void END()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
