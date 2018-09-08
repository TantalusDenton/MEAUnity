using UnityEngine;
using System.Collections;

public class BrowserOpener : MonoBehaviour {

	public string pageToOpen = "https://www.heraldic.cloud";
    
	void Start() {
		InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions();
		options.displayURLAsPageTitle = false;
		options.pageTitle = "Mise En Abyme";
        options.loadingIndicatorColor = "#FF0000";
        options.hidesTopBar = true;

        InAppBrowser.OpenURL(pageToOpen, options);
	}

}
