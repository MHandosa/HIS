namespace Endoscopy.Models
{
    public class FoundationModel
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public FoundationModel(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
