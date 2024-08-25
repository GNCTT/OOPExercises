using Ex15.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    public class Result : IComparable<Result>
    {
        private int _minYear;
        private int _maxYear;

        private int _year;
        private int _term;
        private float _score;

        public int Year
        {
            get { return _year; }
        }

        public int Term
        {
            get { return _term; } 
        }

        public float Score
        {
            get { return _score; }
        }

        public string NameTerm()
        {
            return _year + " " + _term;
        }

        private const string YEAR_INFO = "Year: ";
        private const string YEAR_MESSAGE_ERROR = "Year must be from year student enroll to now";

        private const string TERM_INFO = "Term: ";
        private const string TERM_MESSAFE_ERROR = "Term must be 1 or 2";

        private const string SCORE_INFO = "Score average: ";
        private const string SCORE_MESSAGE_ERROR = "Score must be from 0.00 - 10.00. Try again!!";
        public Result()
        {

        }

        public Result(int minYear)
        {
            _minYear = minYear;
            _maxYear = DateTime.Now.Year;
        }

        public void GetDataFromInput()
        {
            TypeYear();
            TypeTerm();
            TypeScore();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Term: " + NameTerm());
            Console.WriteLine(SCORE_INFO + _score);
        }

        private void TypeYear()
        {
            try
            {
                _year = HandleInput.TypeNumber<int>(YEAR_INFO, YEAR_MESSAGE_ERROR, (n) =>
                {
                    if (n < _minYear || n > _maxYear) return false;
                    return true;
                }, int.Parse);
            } catch (InvalidNumberException)
            {
                TypeYear();
            }
        }

        private void TypeTerm()
        {
            try
            {
                _term = HandleInput.TypeNumber<int>(TERM_INFO, TERM_MESSAFE_ERROR, (n) =>
                {
                    if (n < 1 || n > 2) return false;
                    return true;
                }, int.Parse);
            }
            catch (InvalidNumberException)
            {
                TypeTerm();
            }
        }

        private void TypeScore()
        {
            try
            {
                _score = HandleInput.TypeNumber<float>(SCORE_INFO, SCORE_MESSAGE_ERROR, (n) =>
                {
                    if (n < 0.00 || n > 10.00) return false;
                    return true;
                }, float.Parse);
            }
            catch (InvalidNumberException)
            {
                TypeScore();
            }
        }

        public int CompareTo(Result other)
        {
            if (_year < other._year) return -1;
            if (_term < other._term) return -1;
            if (_year > other._year) return 1;
            if (_term > other._term) return 1;
            return 0;
        }
    }
}
