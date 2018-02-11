using Entitas;
using UnityEngine;

public class InputThrottleSystem : IExecuteSystem
{
    private Contexts _contexts;

    public InputThrottleSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var verticalAxisValue = Input.GetAxis("Vertical");
        _contexts.game.ReplaceThrottleInput(verticalAxisValue);
    }
}
