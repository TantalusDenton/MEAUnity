using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToLandscape : MonoBehaviour {
    
    public void ForceLandscape()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
