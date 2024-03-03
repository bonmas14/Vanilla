using UnityEngine;

public class EntityVisualizer : MonoBehaviour
{
    private IEntity _entity;

    public void Subscribe(IEntity entity)
    {
        _entity = entity;
    }

    private void OnGUI()
    {
        if (_entity == null)
            return;

        var rect = new Rect(0, 0, 100, 50);
        GUI.TextArea(rect, $"e: {Mathf.Round(_entity.Energy)}\nf: {Mathf.Round(_entity.Food)}\nh: {Mathf.Round(_entity.Health)}");
    }
}
