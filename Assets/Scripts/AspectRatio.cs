using UnityEngine;

public class AdjustWindow : MonoBehaviour
{

    private int lastWidth = 0;
    private int lastHeight = 0;

    void UpdateDisabled()
    {
        var width = Screen.width; var height = Screen.height;

        if (lastWidth != width) // if the user is changing the width
        {
            // update the height
            var heightAccordingToWidth = 9.0 * width / 16.0;
            Screen.SetResolution(width, (int)Mathf.Round((float)heightAccordingToWidth), false);
        }
        else if (lastHeight != height) // if the user is changing the height
        {
            // update the width
            var widthAccordingToHeight = 16.0 * height / 9.0;
            Screen.SetResolution((int)Mathf.Round((float)widthAccordingToHeight), height, false);
        }
        lastWidth = width;
        lastHeight = height;
    }
}
