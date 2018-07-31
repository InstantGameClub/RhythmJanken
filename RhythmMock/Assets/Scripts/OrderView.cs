using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderView : MonoBehaviour {
	public Image[] OrderImage;

	public void allDisable(){
		foreach(Image order in OrderImage) {
			order.enabled = false;
		}
	}

	public void changeOrderImage(int orderNum) {
        allDisable();
		OrderImage[orderNum].enabled = true;
        OrderImage[orderNum].color = new Color(Random.Range(0.2f,1.0f),Random.Range(0.2f, 1.0f),Random.Range(0.2f, 1.0f));
	}

}
