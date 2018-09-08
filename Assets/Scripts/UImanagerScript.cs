using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanagerScript : MonoBehaviour {
    public void StartGame()
    {
        InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
        options.displayURLAsPageTitle = false;
        options.pageTitle = "InAppBrowser example";
        options.loadingIndicatorColor = "#FF0000";
        options.hidesTopBar = true;

        InAppBrowser.OpenURL("https://www.heraldic.cloud", options);
    }

}
