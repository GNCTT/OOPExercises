using Ex15.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    public abstract class Student : IComparable<Student>
    {
        private string _id;
        private string _fullName;
        private DateTime _birthDay;
        private int _yearEnroll;
        private float _scoreEnroll;
        protected StudentType _type;
        private List<Result> _results = new List<Result>();

        private static List<string> ids = new List<string>();

        public string Id { get { return _id; } } 

        public int YearEnroll
        {
            get
            {
                return _yearEnroll;
            }
        }

        public float EnrollScore 
        { 
            get
            {
                return _scoreEnroll;
            }
        }


        private const string ID_INFO = "Id: ";
        private const string ID_MESSAGE_ERROR = "Id is invalid or already taken. Try again!!";

        private const string FULLNAME_INFO = "Fullname: ";
        private const string FULLNAME_MESSAGE_ERROR = "Name is invalid. Try again!!";

        private const string BIRTHDAY_INFO = "BirthDay(dd/mm/yyyy): ";
        private const string BIRTHDAY_MESSAGE_ERROR = "Invalid format date. Try again!!";

        private const string YEAR_ENROLL_INFO = "Year Enroll: ";
        private const string YEAR_ENROLL_MESSAGE_ERROR = "Year enroll must be from 2000-now. Try again!!";

        private const string SCORE_ENROLL_INFO = "Score enroll: ";
        private const string SCORE_ENROLL_MESSAGE_INFO = "Score shoulde be from 0 to 40. Try again!!";

        public Student()
        {
        }

        public virtual void GetDataFromInput()
        {
            TypeId();
            TypeName();
            TypeBirthDay();
            TypeYearEnroll();
            TypeScoreEnroll();
            TypeResults();
        }

        public Result GetLatestResult()
        {
            _results.Sort();
            return _results.LastOrDefault();
        }

        public void ShowShortInfo()
        {
            Console.WriteLine(ID_INFO + _id);
            Console.WriteLine(FULLNAME_INFO + _fullName);
            Console.WriteLine(BIRTHDAY_INFO + _birthDay.ToString("dd-mm-yyyy"));
        }

        public void ShowFullInfo()
        {
            Console.WriteLine(ID_INFO + _id);
            Console.WriteLine(FULLNAME_INFO + _fullName);
            Console.WriteLine(BIRTHDAY_INFO + _birthDay.ToString("dd-mm-yyyy"));
            Console.WriteLine(YEAR_ENROLL_INFO + _yearEnroll);
            Console.WriteLine(SCORE_ENROLL_INFO + _scoreEnroll);
            Console.WriteLine("Results: " + _results.Count);
            foreach (var result in _results)
            {
                result.ShowInfo();
                Console.WriteLine();
            }
        }

        public float GetScoreByTerm(int year, int term)
        {
            foreach (var result in _results)
            {
                if (result.Year == year && result.Term == term)
                {
                    return result.Score;
                }
            }
            return -1;
        }

        public float GetAverageScore()
        {
            return _results.Average(x => x.Score);
        }

        private void TypeId()
        {
            try
            {
                _id = HandleInput.TypeString(ID_INFO, ID_MESSAGE_ERROR, (s) =>
                {
                    if (ids.Contains(s)) return false;
                    return Validator.ValidateId(s);
                });
            }
            catch (InvalidNameException)
            {
                TypeId();
            }
        }

        private void TypeName()
        {
            try
            {
                _fullName = HandleInput.TypeString(FULLNAME_INFO, FULLNAME_MESSAGE_ERROR, (s) =>
                {
                    return Validator.ValidateName(s);
                });
            }
            catch (InvalidNameException)
            {
                Console.WriteLine("Name does not contain numbers");
                TypeName();
            }
        }

        private void TypeBirthDay()
        {
            try
            {
                _birthDay = HandleInput.TypeDate(BIRTHDAY_INFO, BIRTHDAY_MESSAGE_ERROR);
            }
            catch (InvalidDateException)
            {
                TypeBirthDay();
            }
        }

        private void TypeYearEnroll()
        {
            try
            {
                _yearEnroll = HandleInput.TypeNumber<int>(YEAR_ENROLL_INFO, YEAR_ENROLL_MESSAGE_ERROR, (n) =>
                {
                    if (n < 2000 || n > DateTime.Now.Year) return false;
                    return true;
                }, int.Parse);
            } catch (InvalidNumberException)
            {
                TypeYearEnroll();
            }
        }

        private void TypeScoreEnroll()
        {
            try
            {
                _scoreEnroll = HandleInput.TypeNumber<float>(SCORE_ENROLL_INFO, SCORE_ENROLL_MESSAGE_INFO, (n) =>
                {
                    if (n < 0 || n > 40) return false;
                    return true;
                }, float.Parse);
            }
            catch (InvalidNumberException)
            {
                TypeScoreEnroll();
            }
        }

        private void TypeResults()
        {
            int numberTerm = 0;
            try
            {
                numberTerm = HandleInput.TypeNumber<int>("ResultNumers: ", "ResultNumber must be from 0 to 14", (n) =>
                {
                    if (n < 0 || n > 14) return false;
                    return true;
                }, int.Parse);
            }catch (InvalidNumberException)
            {
                TypeResults();
            }

            for (int i = 0; i < numberTerm; i++)
            {
                var result = new Result(_yearEnroll);
                result.GetDataFromInput();
                foreach (var res in _results)
                {
                    if (res.Year == result.Year && res.Term == result.Term)
                    {
                        Console.WriteLine("You typed this term. Try again");
                        result.GetDataFromInput();
                    }
                }
                _results.Add(result);
            }
        }

        public int CompareTo(Student other)
        {
            if (_type > other._type) return 1;
            if (_yearEnroll < other._yearEnroll) return 1;
            return 0;
        }
    }
}
