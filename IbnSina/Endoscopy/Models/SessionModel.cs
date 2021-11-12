using System;

namespace Endoscopy.Models
{
    class SessionModel
    {
        public string Id { get; private set; }
        public DateTime Date { get; private set; }
        public SessionModel(string id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        public override string ToString()
        {
            return Date.ToString("dd MMMM yyyy");
        }
    }
}
