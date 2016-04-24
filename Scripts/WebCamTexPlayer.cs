// Copyright (c) 2016 Yasuhide Okamoto
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using UnityEngine;
using System.Linq;

/// <summary>
/// The class to initialize and play WebCamTexture. 
/// </summary>
[RequireComponent(typeof(Renderer))]
public class WebCamTexPlayer : MonoBehaviour {
    /// <summary>
    /// Set a part of device name you want to play. 
    /// </summary>
    [SerializeField]
    string deviceKeyword = "PIXPRO";

    /// <summary>
    /// Set requested width, height, and fps of WebCamTexture. 
    /// </summary>
    [SerializeField]
    int texWidth = 1440;
    [SerializeField]
    int texHeight = 1440;
    [SerializeField]
    int fps = 15;
    
	void Start () {
        var devices = WebCamTexture.devices.Select(d => d.name);
        var cdevice = devices.FirstOrDefault(devname => devname.Contains(deviceKeyword));

        if(cdevice != null)
        {
            var wcamtex = new WebCamTexture(cdevice, texWidth, texHeight, fps);
            var mat = GetComponent<Renderer>().sharedMaterial;
            if (mat != null)
                mat.mainTexture = wcamtex;

            wcamtex.Play();
        }
	}
}
