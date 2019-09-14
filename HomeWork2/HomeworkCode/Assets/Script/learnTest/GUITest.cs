using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
        
    private float mySlider = 1.0f;
    
    void OnGUI () {
        mySlider = LabelSlider (new Rect (10, 100, 100, 20), mySlider, 5.0f, "Label text here");
    }
    
    float LabelSlider (Rect screenRect, float sliderValue, float sliderMaxValue, string labelText) {
        GUI.Label (screenRect, labelText);
    
        // <- Push the Slider to the end of the Label
        screenRect.x += screenRect.width; 
    
        sliderValue = GUI.HorizontalSlider (screenRect, sliderValue, 0.0f, sliderMaxValue);
        return sliderValue;
    }

}