namespace Endoscopy.Models
{
    internal class EndoscopyTypeModel
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public EndoscopyTypeModel(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("{0} \t {1} ", Id, Name);
        }
    }
}
