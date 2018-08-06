using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;

public class Bootstrap : MonoBehaviour {

    public Mesh PlayerMesh;
    public Material PlayerMaterial;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public void Start()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        //Default components for player
        var playerArchetype = entityManager.CreateArchetype(
            typeof(TransformMatrix),
            typeof(Position),
            typeof(MeshInstanceRenderer),
            typeof(PlayerInput)
            );

        //Creates the player
        var player = entityManager.CreateEntity(playerArchetype);

        //Shared Component
        entityManager.SetSharedComponentData(player, new MeshInstanceRenderer
        {
            mesh = PlayerMesh,
            material = PlayerMaterial
        });
           
    }
}
