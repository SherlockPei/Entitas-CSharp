namespace Entitas {
    public partial class Entity {
        public SystemObjectComponent systemObject { get { return (SystemObjectComponent)GetComponent(ComponentIds.SystemObject); } }

        public bool hasSystemObject { get { return HasComponent(ComponentIds.SystemObject); } }

        public Entity AddSystemObject(object newSystemObject) {
            var componentPool = GetComponentPool(ComponentIds.SystemObject);
            var component = (SystemObjectComponent)(componentPool.Count > 0 ? componentPool.Pop() : new SystemObjectComponent());
            component.systemObject = newSystemObject;
            return AddComponent(ComponentIds.SystemObject, component);
        }

        public Entity ReplaceSystemObject(object newSystemObject) {
            var componentPool = GetComponentPool(ComponentIds.SystemObject);
            var component = (SystemObjectComponent)(componentPool.Count > 0 ? componentPool.Pop() : new SystemObjectComponent());
            component.systemObject = newSystemObject;
            ReplaceComponent(ComponentIds.SystemObject, component);
            return this;
        }

        public Entity RemoveSystemObject() {
            return RemoveComponent(ComponentIds.SystemObject);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherSystemObject;

        public static IMatcher SystemObject {
            get {
                if (_matcherSystemObject == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.SystemObject);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSystemObject = matcher;
                }

                return _matcherSystemObject;
            }
        }
    }
}