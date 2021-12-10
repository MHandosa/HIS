using Endoscopy.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Endoscopy.ViewModels
{
    internal class SessionViewModel
    {
        private readonly ObservableCollection<SessionModel> _sessions;

        public SessionViewModel()
        {
            _sessions = new ObservableCollection<SessionModel>();
        }

        public ObservableCollection<SessionModel> Sessions
        {
            get
            {
                return _sessions;
            }
        }

        public int Count
        {
            get
            {
                return _sessions.Count;
            }
        }

        public void Clear()
        {
            _sessions.Clear();
        }

        public void Load(PatientModel patient)
        {
            _sessions.Clear();

            List<SessionModel> sessions = ServerAPI.GetSessions(patient);

            foreach (SessionModel session in sessions)
            {
                _sessions.Add(session);
            }
        }
    }
}
