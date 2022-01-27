namespace Endoscopy
{
    internal class EndoscopyType
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public EndoscopyType(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
