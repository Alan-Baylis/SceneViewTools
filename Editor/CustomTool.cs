using UnityEngine;
using System.Collections;

public class CustomTool : SceneViewTool
{
	void OnContextClick ()
	{
		Debug.Log ("ContextClick");
	}
	
	void OnKeyDown (KeyCode key)
	{
		Debug.Log ("KeyDown " + key);
	}
	
	void OnKeyUp (KeyCode key)
	{
		Debug.Log ("KeyUp " + key);
	}
	
	void OnMouseDown (int button, Vector2 position)
	{
		Debug.Log ("MouseDown " + button);
	}
	
	void OnMouseUp (int button, Vector2 position)
	{
		Debug.Log ("MouseUp " + button);
	}
	
	void OnMouseDrag (int button, Vector2 position)
	{
		Debug.Log ("MouseDrag " + button);
	}
	
	void OnMouseMove (int button, Vector2 position)
	{
//		Debug.Log ("MouseMove " + button);
	}
	
	void OnScrollWheel ()
	{
		Debug.Log ("ScrollWheel");
	}
	
	void OnDragPerform ()
	{
		Debug.Log ("DragPerformed");
	}
	
	void OnDragExited ()
	{
		Debug.Log ("DragExited");
	}
	
	void OnDragUpdated ()
	{
		Debug.Log ("DragUpdated");
	}
}
