using Entitas;
using UnityEngine;

public class InputRotationSystem : IExecuteSystem
{
    private Contexts _contexts;

    public InputRotationSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var verticalAxisValue = Input.GetAxisRaw("Horizontal");
        var playerEntity = _contexts.game.playerEntity;
        var rotation = playerEntity.rotation.value -
                       verticalAxisValue * _contexts.game.settings.value.rotateSpeed * Time.deltaTime;

        _contexts.game.playerEntity.ReplaceRotation(rotation);
    }
}
