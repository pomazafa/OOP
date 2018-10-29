using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class SessionController
    {
        Session Sessions { get; set; }

        public SessionController(Session session)
        {
            Sessions = session;
        }

        public void GetExamsCountBySubject(string subject)
        {
            Console.WriteLine($"Subject: {subject}, Count: {Sessions.exams.Where(x => x.Subject == subject).Count()}");
        }

        public void GetChechoutCount()
        {
            Console.WriteLine($"Total exams: {Sessions.exams.Count + Sessions.tests.Count}");
        }

        public void GetTestCountByQuestionCount(int count)
        {
            Console.WriteLine($"{Sessions.tests.Where(x => x.Questions.Count == count).Count()}");
        }
    }
}
