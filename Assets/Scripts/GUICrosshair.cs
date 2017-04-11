using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICrosshair : MonoBehaviour {
    public Texture2D CrosshairTexture;

    Rect _position;
    bool _originalOn = true;

	// Use this for initialization
	void Start () {
        _position = new Rect((Screen.width - CrosshairTexture.width) / 2, (Screen.height - CrosshairTexture.height) / 2, CrosshairTexture.width, CrosshairTexture.height);
	}
	
	// Update is called once per frame
	void OnGUI () {
        if (_originalOn)
        {
            GUI.DrawTexture(_position, CrosshairTexture);
        }
	}
}
