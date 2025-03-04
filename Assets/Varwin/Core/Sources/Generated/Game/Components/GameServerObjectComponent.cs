//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Varwin.ECS.Components.Server.ServerObjectComponent serverObject { get { return (Varwin.ECS.Components.Server.ServerObjectComponent)GetComponent(GameComponentsLookup.ServerObject); } }
    public bool hasServerObject { get { return HasComponent(GameComponentsLookup.ServerObject); } }

    public void AddServerObject(Varwin.Data.PrefabObject newValue) {
        var index = GameComponentsLookup.ServerObject;
        var component = CreateComponent<Varwin.ECS.Components.Server.ServerObjectComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceServerObject(Varwin.Data.PrefabObject newValue) {
        var index = GameComponentsLookup.ServerObject;
        var component = CreateComponent<Varwin.ECS.Components.Server.ServerObjectComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveServerObject() {
        RemoveComponent(GameComponentsLookup.ServerObject);
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

    static Entitas.IMatcher<GameEntity> _matcherServerObject;

    public static Entitas.IMatcher<GameEntity> ServerObject {
        get {
            if (_matcherServerObject == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ServerObject);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherServerObject = matcher;
            }

            return _matcherServerObject;
        }
    }
}
