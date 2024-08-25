using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CandidateManager candidateManager = new CandidateManager();

            while (true)
            {
                Console.WriteLine("Application Manage Candidate");
                Console.WriteLine("Type 1 to add candidate group A");
                Console.WriteLine("Type 2 to add candidate group B");
                Console.WriteLine("Type 3 to add candidate group C");
                Console.WriteLine("Type 4 to show infomation of all candidate");
                Console.WriteLine("Type 5 to search infomation of candidate by id");
                Console.WriteLine("Type 6 to clear console");
                Console.WriteLine("Type 7 to close app");
                
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "1":
                        {
                            Candidate candidateA = new CandidateGroupA();
                            candidateA.GetDataFromInput();
                            candidateManager.AddCandidate(candidateA);
                            break;
                        }
                    case "2":
                        {
                            Candidate candidateB = new CandidateGroupB();
                            candidateB.GetDataFromInput();
                            candidateManager.AddCandidate(candidateB);
                            break;
                        }
                    case "3":
                        {
                            Candidate candidateC = new CandidateGroupC();
                            candidateC.GetDataFromInput();
                            candidateManager.AddCandidate(candidateC);
                            break;
                        }
                    case "4":
                        {
                            candidateManager.ShowInfoCandidates(); break;
                        }
                    case "5":
                        {
                            int id = HandleInput.TypeNumber("Type Registration number: ", "Invalid registration number. Please check Again", n => n > 0);
                            Candidate candidate = candidateManager.FindCandidateByRegistrationNumber(id);
                            if (candidate != null)
                            {
                                Console.WriteLine(candidate);
                            }
                            else
                            {
                                {
                                    Console.WriteLine("Can not find candidate with this registration number");
                                }
                            }
                            break;
                        }
                    case "6":
                        {
                            Console.Clear();
                            break;
                        }
                    default:
                        break;
                }
                if (cmd == "7")
                {
                    break;
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------");
            }

        }
    }
}
