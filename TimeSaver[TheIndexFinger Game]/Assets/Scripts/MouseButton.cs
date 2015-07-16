using UnityEngine;
using System.Collections;

public class MouseButton : MonoBehaviour {
public static int jumping = 0;
public static int left = 0;
public static int right = 0;
public void OnMouseDown()
	{
		if (this.name == "Jump") 
		{
			jumping = 1;
		}
		if (this.name == "Left Button") 
		{
			left = 1;
		}
		if (this.name == "Right Button") 
		{
			right = 1;
		}
	}
public void OnMouseUp()
	{
		jumping = 0;
		left = 0;
		right = 0;
	}

	public void OnMouseClick()
	{


	}
}
