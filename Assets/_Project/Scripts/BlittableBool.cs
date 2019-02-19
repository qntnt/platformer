namespace _Project.Scripts {
    public struct BlittableBool {
        private readonly byte _value;

        public BlittableBool(bool value) {
            _value = (byte) (value ? 1 : 0);
        }

        public static implicit operator BlittableBool(bool value) {
            return new BlittableBool(value);
        }

        public static implicit operator bool(BlittableBool value) {
            return value._value != 0;
        }
    }
}