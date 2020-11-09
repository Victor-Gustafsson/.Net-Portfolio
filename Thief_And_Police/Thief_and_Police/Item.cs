namespace Thief_And_Police
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public Item(int Id, string name, int value)
        {
            ID = Id;
            Name = name;
            Value = value;
        }
    }
    class Key : Item
    { public Key(int Id, string name, int value) : base(Id, name, value) { } }
    class Phone : Item
    { public Phone(int Id, string name, int value) : base(Id, name, value) { } }
    class Money : Item
    { public Money(int Id, string name, int value) : base(Id, name, value) { } }
    class Watch : Item
    { public Watch(int Id, string name, int value) : base(Id, name, value) { } }
}
