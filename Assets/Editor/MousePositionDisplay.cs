using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class MousePositionDisplay
{
    // Keep a cached position so we can display it at all times
    private static Vector3 _lastWorldPos;

    static MousePositionDisplay()
    {
        // Hook into SceneView event
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;

        // Update position if the mouse is moving in the Scene view
        if (e != null && e.isMouse && e.type == EventType.MouseMove)
        {
            // Convert from GUI space to screen space
            Vector2 mousePos = e.mousePosition;
            mousePos.y = sceneView.camera.pixelHeight - mousePos.y;

            // Convert screen space to world space (using a Z of 10 or nearClipPlane)
            _lastWorldPos = sceneView.camera.ScreenToWorldPoint(
                new Vector3(mousePos.x, mousePos.y, 10f)
            );

            // (Optional) Log to Console for debugging
            Debug.Log($"Mouse World Position: {_lastWorldPos}");

            // Force immediate Scene view refresh
            sceneView.Repaint();
        }

        // We draw the label on Repaint so it remains visible
        if (e.type == EventType.Repaint)
        {
            Handles.BeginGUI();
            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                normal = { textColor = Color.white },
                fontSize = 14
            };

            GUI.Label(
                new Rect(10, 10, 400, 20),
                $"Mouse Position: X = {_lastWorldPos.x:F2}, Y = {_lastWorldPos.y:F2}",
                style
            );

            Handles.EndGUI();
        }
    }
}
