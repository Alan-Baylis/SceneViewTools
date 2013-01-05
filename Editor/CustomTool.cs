using UnityEngine;
using System.Collections;

public class CustomTool : SceneViewTool
{
	void OnContextClick (Vector2 position)
	{
		Debug.Log ("ContextClick");
	}
	
	void OnKeyDown (KeyCode key, EventModifiers modifiers)
	{
		Debug.Log ("KeyDown " + key);
	}
	
	void OnKeyUp (KeyCode key, EventModifiers modifiers)
	{
		Debug.Log ("KeyUp " + key);
	}
	
	void OnMouseDown (int button, Vector2 position, Vector2 delta)
	{
		Debug.Log ("MouseDown " + button);
	}
	
	void OnMouseUp (int button, Vector2 position, Vector2 delta)
	{
		Debug.Log ("MouseUp " + button);
	}
	
	void OnMouseDrag (int button, Vector2 position, Vector2 delta)
	{
		Debug.Log ("MouseDrag " + button);
	}
	
	void OnMouseMove (int button, Vector2 position, Vector2 delta)
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
