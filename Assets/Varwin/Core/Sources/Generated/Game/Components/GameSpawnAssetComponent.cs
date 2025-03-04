//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Varwin.ECS.Components.Events.SpawnAssetComponent spawnAsset { get { return (Varwin.ECS.Components.Events.SpawnAssetComponent)GetComponent(GameComponentsLookup.SpawnAsset); } }
    public bool hasSpawnAsset { get { return HasComponent(GameComponentsLookup.SpawnAsset); } }

    public void AddSpawnAsset(Varwin.Data.SpawnInitParams newSpawnInitParams) {
        var index = GameComponentsLookup.SpawnAsset;
        var component = CreateComponent<Varwin.ECS.Components.Events.SpawnAssetComponent>(index);
        component.SpawnInitParams = newSpawnInitParams;
        AddComponent(index, component);
    }

    public void ReplaceSpawnAsset(Varwin.Data.SpawnInitParams newSpawnInitParams) {
        var index = GameComponentsLookup.SpawnAsset;
        var component = CreateComponent<Varwin.ECS.Components.Events.SpawnAssetComponent>(index);
        component.SpawnInitParams = newSpawnInitParams;
        ReplaceComponent(index, component);
    }

    public void RemoveSpawnAsset() {
        RemoveComponent(GameComponentsLookup.SpawnAsset);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpawnAsset;

    public static Entitas.IMatcher<GameEntity> SpawnAsset {
        get {
            if (_matcherSpawnAsset == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SpawnAsset);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpawnAsset = matcher;
            }

            return _matcherSpawnAsset;
        }
    }
}
