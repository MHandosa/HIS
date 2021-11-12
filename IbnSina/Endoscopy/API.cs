using System;
using Endoscopy.Models;
using System.Collections.Generic;
using System.Security.Authentication;

namespace Endoscopy
{
    internal static class API
    {
        private static string _userId;

        static API()
        {
            _userId = null;
        }

        public static bool Login(string userName, string password)
        {
            if (userName == "Handosa" && password == "123")
            {
                _userId = "01002218601";
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetUserDisplayName()
        {
            if (_userId == null)
            {
                throw new AuthenticationException();
            }

            return "محمد حسين حافظ حندوسة";
        }

        public static List<FoundationModel> GetFoundations()
        {
            if (_userId == null)
            {
                throw new AuthenticationException();
            }

            List<FoundationModel> foundations = new()
            {
                new FoundationModel("1", "مستشفى الباطنة"),
                new FoundationModel("2", "مستشفى الأطفال"),
                new FoundationModel("3", "مستشفى الطوارئ"),
                new FoundationModel("1", "مستشفى الباطنة"),
                new FoundationModel("2", "مستشفى الأطفال"),
                new FoundationModel("3", "مستشفى الطوارئ"),
                new FoundationModel("1", "مستشفى الباطنة"),
                new FoundationModel("2", "مستشفى الأطفال"),
                new FoundationModel("3", "مستشفى الطوارئ"),
                new FoundationModel("1", "مستشفى الباطنة"),
                new FoundationModel("2", "مستشفى الأطفال"),
                new FoundationModel("3", "مستشفى الطوارئ"),
                new FoundationModel("1", "مستشفى الباطنة"),
                new FoundationModel("2", "مستشفى الأطفال"),
                new FoundationModel("3", "مستشفى الطوارئ")
            };

            return foundations;
        }

        public static List<PatientModel> GetPatients(FoundationModel foundation)
        {
            if (_userId == null)
            {
                throw new AuthenticationException();
            }

            if (foundation == null)
            {
                throw new ArgumentNullException(nameof(foundation));
            }

            List<PatientModel> patients = new()
            {
                new PatientModel("1", "محمد إبراهيم وجدي عبد الله"),
                new PatientModel("2", "سامية عثمان عبدالكريم المرشدي"),
                new PatientModel("3", "سمير محمود حافظ محمدين"),
                new PatientModel("1", "محمد إبراهيم وجدي عبد الله"),
                new PatientModel("2", "سامية عثمان عبدالكريم المرشدي"),
                new PatientModel("3", "سمير محمود حافظ محمدين"),
                new PatientModel("1", "محمد إبراهيم وجدي عبد الله"),
                new PatientModel("2", "سامية عثمان عبدالكريم المرشدي"),
                new PatientModel("3", "سمير محمود حافظ محمدين")
            };

            return patients;
        }

        public static List<SessionModel> GetSessions(PatientModel patient)
        {
            if (_userId == null)
            {
                throw new AuthenticationException();
            }

            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            List<SessionModel> sessions = new()
            {
                new SessionModel("1", DateTime.Now),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0))),

                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0))),

                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0))),

                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0))),

                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0))),

                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0))),

                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(25, 0, 0, 0))),
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0))),
                
                new SessionModel("1", DateTime.Now.Subtract(new TimeSpan(35, 0, 0, 0)))
            };

            return sessions;
        }
    }
}