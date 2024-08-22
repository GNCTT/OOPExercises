using Ex13;
using Ex13.Exceptions;
using System;
using System.Collections.Generic;

namespace Ex15
{
    public abstract class Student
    {
        private string _id;
        private string _fullName;
        private DateTime _birthDay;
        private int _yearEnroll;
        private float _scoreEnroll;
        protected StudentType _type;
        private List<Result> _results;

        private static List<string> ids = new List<string>();


        private const string ID_INFO = "Id: ";
        private const string ID_MESSAGE_ERROR = "Id is invalid or already taken. Try again!!";

        private const string FULLNAME_INFO = "Fullname: ";
        private const string FULLNAME_MESSAGE_ERROR = "Name is invalid. Try again!!";

        public Student()
        {
        }

        public virtual void GetDataFromInput()
        {

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
            } catch (InvalidNameException)
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

        }

        private void TypeYearEnroll()
        {

        }

        private void TypeScoreEnroll()
        {

        }

        private void TypeResults()
        {

        }

    }
}
