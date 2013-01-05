using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;


[InitializeOnLoad]
public static class SceneViewToolController
{
	public class MethodRef
	{
		public SceneViewTool instance;
		public MethodInfo method;
	
		public MethodRef (SceneViewTool instance, MethodInfo method)
		{
			this.instance = instance;
			this.method = method;
		}
	}
	
	static List<SceneViewTool> tools = new List<SceneViewTool> ();
	static Dictionary<EventType, List<MethodRef>> methods = new Dictionary<EventType, List<MethodRef>> ();
	
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
		foreach (var t in types) {
			if (t == typeof(SceneViewTool))
				continue;
			// Instantiate all SceneViewTool subclasses
			var instance = System.Activator.CreateInstance (t) as SceneViewTool;
			tools.Add (instance);
			// Find special methods
			AddMethodToLookup (t, instance, "OnContextClick", EventType.ContextClick);
			AddMethodToLookup (t, instance, "OnKeyDown", EventType.KeyDown);
			AddMethodToLookup (t, instance, "OnKeyUp", EventType.KeyUp);
			AddMethodToLookup (t, instance, "OnMouseDown", EventType.MouseDown);
			AddMethodToLookup (t, instance, "OnMouseUp", EventType.MouseUp);
			AddMethodToLookup (t, instance, "OnMouseDrag", EventType.MouseDrag);
			AddMethodToLookup (t, instance, "OnMouseMove", EventType.MouseMove);
			AddMethodToLookup (t, instance, "OnScrollWheel", EventType.ScrollWheel);
			AddMethodToLookup (t, instance, "OnDragPerform", EventType.DragPerform);
			AddMethodToLookup (t, instance, "OnDragUpdated", EventType.DragUpdated);
			AddMethodToLookup (t, instance, "OnDragExited", EventType.DragExited);
		}
	}
	
	static void AddMethodToLookup (System.Type type, SceneViewTool obj, string methodName, EventType eventType)
	{
		if (!methods.ContainsKey (eventType))
			methods.Add (eventType, new List<MethodRef> ());
		var method = type.GetMethod (methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		if (method != null) 
			methods[eventType].Add (new MethodRef (obj, method));
	}

	static IEnumerable<System.Type> FindDerivedTypes (Assembly assembly, System.Type baseType)
	{
		return assembly.GetTypes ().Where (t => baseType.IsAssignableFrom (t));
	}

	public static void HandleSceneGUI (SceneView view)
	{
		if (!ToolActive)
			return;
		
		var e = Event.current;
		
		// Set up method parameters for current event
		object[] parameters = null;
		if (e.isMouse) {
			parameters = new object[] { Event.current.button, Event.current.mousePosition };
		} else if (e.isKey) {
			parameters = new object[] { Event.current.keyCode };
		}
		
		// Execute event methods on all SceneViewTool subclasses
		if (methods.ContainsKey (e.type)) {
			foreach (var m in methods[e.type]) {
				m.method.Invoke (m.instance, parameters);
			}
		}
	}
}
