using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleInput : MonoBehaviour {
	public KeyCode[] keys;
	public Image[] images;
	public Text[] text;
	public Vector2[] sizes;
	public float pivot = 100f,posY = 0f;

	public Sprite[] sprites;
	// Update is called once per frame
	void Update () {

		foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
			if (Input.GetKey(key) && keys[0] == KeyCode.None) {					
				keys [0] = key;
			} 
		}

		/*for (int i = 0; i < keys.Length; i++) {
			Debug.Log (i+1);
			if (keys [i] !=  KeyCode.None && keys [i+1] ==  KeyCode.None) {
				foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
					if (Input.GetKey (key) && key != keys [0]  && key != keys [1] && key != keys [2]) {						
						keys [i + 1] = key;				
					} 
				}
			}
		}*/
		if (keys [0] !=  KeyCode.None && keys [1] ==  KeyCode.None) {
			foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
				if (Input.GetKey (key) && key != keys [0]  && key != keys [1] && key != keys [2]) {						
					keys [1] = key;
				} 
			}
		}
		if (keys [1] !=  KeyCode.None && keys [2] ==  KeyCode.None) {
			foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
				if (Input.GetKey (key) && key != keys [0]  && key != keys [1] && key != keys [2]) {						
					keys [2] = key;
				} 
			}
		}
		if (keys [2] !=  KeyCode.None && keys [3] ==  KeyCode.None) {
			foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
				if (Input.GetKey (key) && key != keys [0]  && key != keys [1] && key != keys [2]) {						
					keys [3] = key;
				} 
			}
		}
		#region Unpress keys
		for (int i = 0; i < keys.Length; i++) {
			ImagePosition(i);
			TextKey(i);
			UpressKeys(i);
		}
		#endregion
	}
	void ImagePosition(int i){
		if (images[i]!= null) {	
			//Vector3  mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 100);
			//Vector3 imagesPosition = Camera.main.ScreenToWorldPoint(mousePosition);

			if (text [i].text.Length == 0) {
				images [i].sprite = null;
				images [i].color= new Color(1,1,1,0);
			}

			if (text [i].text.Length == 1) {
				images [i].sprite = sprites[0];
				images [i].rectTransform.sizeDelta = sizes[0];//sprites[0].rect.size/size;
				images [i].color= new Color(1,1,1,1);
			}

			if (text [i].text.Length > 1 && text [i].text.Length <= 7) {
				images [i].sprite = sprites[1];
				images [i].rectTransform.sizeDelta = sizes[1];//sprites[1].rect.size/size;
				images [i].color= new Color(1,1,1,1);
			}

			if (text [i].text.Length > 7) {
				images [i].sprite = sprites[2];
				images [i].rectTransform.sizeDelta = sizes[2];//sprites[1].rect.size/size;
				images [i].color= new Color(1,1,1,1);
			}

			images [i].rectTransform.position = new Vector3 (Input.mousePosition.x, //imagesPosition;
															Input.mousePosition.y + posY,
															Input.mousePosition.z);
			//pivot [i] = images [i].rectTransform.rect.width+( text [i].text.Length);
			if(i>0){
				float x = images [i-1].rectTransform.position.x + images [i-1].rectTransform.rect.width + pivot;
				images [i].transform.position =  new Vector3(x,images [i-1].rectTransform.position .y,images [i-1].rectTransform.position.z);	
			}
		}
	}
	void TextKey(int i){
		if (text[i]!= null) {			
			text[i].text = keys [i].ToString();
		}
		if (text[i].text== "None") {			
			text[i].text = "";
		}
	}

	void UpressKeys(int i){
		if (keys [i] != KeyCode.None) {
			if (Input.GetKeyUp (keys [i])) {
				keys [i] = KeyCode.None;
			}
		}
	}
}
