using ex13.Exceptions;
using System;
using System.Collections.Generic;

namespace ex13
{
    public abstract class Employee
    {
        private int _id;
        private string _fullName;
        private DateTime _birthDay;
        private string _phone;
        private string _email;
        protected EmployeeType _employeeType;
        private List<Certificate> _certificates;

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public EmployeeType EmployeeType 
        { 
            get
            {
                return _employeeType;
            }
        }

        private static int employeeCount;
        private static List<int> ids = new List<int>();

        #region Const variable
        private const string ID_INFO = "Id: ";
        private const string ID_MESSAGE_INFO = "Not valid Id or Id is already taken. Type Again!!";

        private const string FULL_NAME_INFO = "Full name: ";
        private const string FULL_NAME_MESSAGE_ERROR = "Do not leave full name blank. Type again!!";

        private const string BIRTHDAY_INFO = "Birth Day(dd/mm/yyyy): ";
        private const string BIRTHDAY_MESSAGE_ERROR = "Do not leave birth day blank. Type again!!";

        private const string PHONE_INFO = "Phone(include 10 numbers (0-9)): ";
        private const string PHONE_MESSAGE_ERROR = "Do not leave phone blank. Type again!!";

        private const string EMAIL_INFO = "Email: ";
        private const string EMAIL_MESSAGE_ERROR = "Do not leave email blank. Type again!!";

        private const string EMPLOYEE_TYPE_INFO = "Employee type(0: Experience, 1: Fresher, 2: Intern): ";
        private const string EMPLOYEE_MESSAGE_INFO = "You must type 0-2. Type again";

        private const string DONOT_CHANGE_INFO = "You do not change";
        #endregion

        public Employee()
        {
            _certificates = new List<Certificate>();
        }

        public virtual void GetDataFromInput()
        {
            TypeId();
            TypeName();
            TypeBirthDay();
            TypePhone();
            TypeEmail();
            TypeCertificate();
            Console.WriteLine("Type certificate complete!!");
        }

        public virtual void EditData()
        {
            TypeId("(" + _id + ")", editMode : true);
            TypeName("(" + _fullName + ")", editMode : true);
            TypeBirthDay("(" + _birthDay.ToString("dd/mm/yyyy") + ")", editMode : true);
            TypePhone("(" + _phone + ")", editMode: true);
            TypeEmail("(" + _email + ")", editMode: true);
            TypeCertificate();
        }

        public void CopyInfo(Employee other)
        {
            _id = other._id;
            _fullName = other._fullName;
            _birthDay = other._birthDay;
            _phone = other._phone;
            _email = other._email;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine("Employee Info");
            Console.WriteLine(ID_INFO + _id);
            Console.WriteLine(BIRTHDAY_INFO + _birthDay.ToString("dd/mm/yyyy"));
            Console.WriteLine(PHONE_INFO + _phone);
            Console.WriteLine(EMAIL_INFO + _email);
            Console.WriteLine(EMPLOYEE_TYPE_INFO + _employeeType.ToString());
            Console.WriteLine("List certificates: ");
            for (int i = 0; i < _certificates.Count; i++)
            {
                Console.WriteLine("Certificate {0}", i + 1);
                Console.WriteLine(_certificates[i]);
            }
        }

        private void TypeId(string preInfo = "", bool editMode = false)
        {
            try
            {
                _id = HandleInput.TypeNumber(ID_INFO + preInfo, ID_MESSAGE_INFO, (id) =>
                {
                    if (id < 0) return false;
                    if (string.IsNullOrEmpty(preInfo))
                    {
                        if (ids.Contains(id)) return false;
                    }
                    else
                    {
                        if (id == _id) return true;
                        if (ids.Contains(id)) return false;
                    }
                    return true;
                }, editMode);
            }
            catch (LeaveBlankException)
            {
                Console.WriteLine(DONOT_CHANGE_INFO + " id field");
            }
        }

        private void TypeName(string preInfo = "", bool editMode = false)
        {
            try
            {
                var input = HandleInput.TypeString(FULL_NAME_INFO + preInfo, FULL_NAME_MESSAGE_ERROR, editMode);
                if (Validator.ValidateFullName(input))
                {
                    _fullName = input;
                }
            }
            catch (FullNameException ex)
            {
                Console.WriteLine(ex);
                TypeName();
            }
            catch (LeaveBlankException)
            {
                Console.WriteLine(DONOT_CHANGE_INFO + " name field");
            }
        }

        private void TypePhone(string preInfo = "", bool editMode = false)
        {
            try
            {
                var input = HandleInput.TypeString(PHONE_INFO + preInfo, PHONE_MESSAGE_ERROR, editMode);
                if (Validator.ValidatePhoneNumber(input))
                {
                    _phone = input;
                }
            }
            catch (PhoneException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Phone must be contain number from 0-9.");
                TypePhone();
            }
            catch (LeaveBlankException)
            {
                Console.WriteLine(DONOT_CHANGE_INFO + " phone field");
            }
        }

        private void TypeEmail(string preInfo = "", bool editMode = false)
        {
            try
            {
                var input = HandleInput.TypeString(EMAIL_INFO + preInfo, EMAIL_MESSAGE_ERROR, editMode);
                if (Validator.ValidateEmail(input))
                {
                    _email = input;
                }
            }
            catch (EmailException ex)
            {
                Console.WriteLine(ex);
                TypeEmail();
            }
            catch(LeaveBlankException)
            {
                Console.WriteLine(DONOT_CHANGE_INFO + " email field");
            }
        }

        public void TypeEmployeeType(string preInfo = "", bool editMode = false)
        {
            try
            {
                var type = (EmployeeType)HandleInput.TypeNumber(EMPLOYEE_TYPE_INFO + preInfo, EMPLOYEE_MESSAGE_INFO, (n) =>
                {
                    if (n < 0 || n > 2) return false;
                    return true;
                }, editMode);
                _employeeType = type;
            } catch (LeaveBlankException)
            {
                Console.WriteLine(DONOT_CHANGE_INFO + " employee type!");
            }
            
        }

        private void TypeCertificate(string preInfo = "")
        {
            int certificateNumber = HandleInput.TypeNumber("Certificate number: ", "Invalid number. Type again!!", (n) => n >= 0);
            for (int i = 0; i < certificateNumber; i++)
            {
                var certificate = new Certificate();
                certificate.GetDataFromInput();
                _certificates.Add(certificate);
            }
            
        }

        private void TypeBirthDay(string preInfo = "", bool editMode = false)
        {
            try
            {
                var input = HandleInput.TypeString(BIRTHDAY_INFO + preInfo, BIRTHDAY_MESSAGE_ERROR, editMode);
                if (Validator.ValidateBirthDay(input))
                {
                    var birthDay = DateTime.Now;
                    if (!DateTime.TryParseExact(input, "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out var birthday))
                    {
                        TypeBirthDay();
                    }
                    _birthDay = birthday;
                }
            }
            catch (BirthDayException ex)
            {
                Console.WriteLine(ex);
                TypeBirthDay();
            }
            catch (LeaveBlankException)
            {
                Console.WriteLine(DONOT_CHANGE_INFO + " birth day field");
            }
        }

        public static void AddEmployeeSuccessfull(int id)
        {
            ids.Add(id);
            employeeCount++;
        }

    }
}
