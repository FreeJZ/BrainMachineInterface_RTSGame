using UnityEditor;

public static class ExtesionMenuItem
{
    [MenuItem("自定义工具/ExcelTool")]
    private static void ExcelTool()
    {
        if (EditorWindow.HasOpenInstances<ExcelToolEditorWindow>()) return;
        ExcelToolEditorWindow window = EditorWindow.GetWindow<ExcelToolEditorWindow>(false, "ExcelTool", false);
        window.Show();
    }

}
