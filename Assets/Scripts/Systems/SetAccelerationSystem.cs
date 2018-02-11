using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SetAccelerationSystem : ReactiveSystem<GameEntity>
{

    private Vector3 velocity;
    private Vector3 clampedVelocity;

    public SetAccelerationSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Inertia);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasInertia;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var rigidbody = entity.view.value.GetComponent<Rigidbody2D>();
            if(rigidbody != null) {
                rigidbody.AddRelativeForce(new Vector3(0f, entity.inertia.value, 0f), ForceMode2D.Impulse);
            }
        }
    }
}
