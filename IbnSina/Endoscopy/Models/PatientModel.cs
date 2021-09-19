namespace Endoscopy.Models
{
    public class PatientModel
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public PatientModel(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} ", Id, Name);
        }
    }
}
