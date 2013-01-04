using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

[InitializeOnLoad]
public static class SceneViewToolController
{
	static bool _toolActive;
	static bool ToolActive {
		get { return _toolActive; }
		set {
			if (value == true)
				Tools.current = Tool.None;
			_toolActive = value;
		}
	}

	static SceneViewToolController ()
	{
		Init ();

		ToolActive = true;
		SceneView.onSceneGUIDelegate += HandleSceneGUI;
	}

	static void Init ()
	{
		var types = FindDerivedTypes (Assembly.GetExecutingAssembly (), typeof(SceneViewTool));
		// Find all SceneViewTools in the project
	}

	static IEnumerable<System.Type> FindDerivedTypes (Assembly assembly, System.Type baseType)
	{
		return assembly.GetTypes ().Where (t => baseType.IsAssignableFrom (t));
	}



	// TODO use reflection to find special methods in subclasses for different types of events.
	// If the methods are defined in the subclass, call Event.current.use after executing each method

	public static void HandleSceneGUI (SceneView view)
	{
		if (!ToolActive)
			return;

		switch (Event.current.type) {
		case EventType.ContextClick:
			Debug.Log("context");
			break;
		case EventType.KeyDown:
			Debug.Log("down");
			break;
		case EventType.KeyUp:
			break;
		case EventType.MouseDown:
			OnMouseDown (Event.current.button);
			break;
		case EventType.MouseUp:
			OnMouseUp (Event.current.button);
			break;
		case EventType.MouseDrag:
			Debug.Log("drag");
			break;
		case EventType.MouseMove:
			break;
		case EventType.ScrollWheel:
			break;
		case EventType.DragPerform:
			break;
		case EventType.DragUpdated:
			break;
		case EventType.DragExited:
			break;
		case EventType.ExecuteCommand:
			break;
		}
	}

	static void OnMouseDown (int button)
	{

	}

	static void OnMouseUp (int button)
	{
		
	}

	static void OnMouseDrag ()
	{

	}
}
