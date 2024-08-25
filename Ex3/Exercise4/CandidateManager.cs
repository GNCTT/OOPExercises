using System;
using System.Collections.Generic;

namespace Exercise3
{
    public class CandidateManager
    {
        private readonly List<Candidate> candidates;

        public CandidateManager()
        {
            candidates = new List<Candidate>();
        }

        public void AddCandidate(Candidate candidate)
        {
            var otherCandidate = candidates.Find(c => c.ID == candidate.ID);
            if (otherCandidate != null)
            {
                Console.WriteLine("Register number is already taken. Please check and refill candidate infomation!!");
                candidate.GetDataFromInput();
                return;
            }
            candidates.Add(candidate);
            Console.WriteLine("Add Candidate With {0} Successfully!!!", candidate);
        }

        public void ShowInfoCandidates()
        {
            Console.WriteLine("List candidate:");
            foreach (var candidate in candidates)
            {
                Console.WriteLine(candidate);
            }
        }

        public Candidate FindCandidateByRegistrationNumber(int id)
        {
            var candidate = candidates.Find(c => c.ID == id);
            if (candidate != null)
            {
                return candidate;
            }
            return null;
        }

        public void ExitProgram()
        {
            Console.WriteLine("Exit Program!");
        }
    }
}
