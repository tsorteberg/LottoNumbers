/***************************************************************
* Name        : Lotto.cs
* Author      : Tom Sorteberg
* Created     : 07/18/2020
* Course      : CIS 169 - C#
* Version     : 1.0
* OS          : Windows 10 Pro, Visual Studio Community 2019
* Copyright   : This is my own original work based on
*               specifications issued by our instructor
* Description : This class file represents the model for an MVC
*               ASP.NET Core Web Application, which has been prepared
*               for my final project submission for CIS-169.  This
*               class instantiates an object of Lotto, which represents
*               4 numbers passed from the controller, a randomly generated
*               series of 4 numbers generated by a class method, and 
*               methods to test whether any of those numbers match.
* I have not used unauthorized source code, either modified or 
* unmodified. I have not given other fellow student(s) access 
* to my program.         
***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LottoNumbersSorteberg.Models
{
    // Lotto Class //
    public class Lotto
    {
        // Constants
        private const int low = 1;
        private const int high = 72;
        private const int ARRAY_SIZE = 4;

        // Declare and instatiate array and random object.
        private int[] _winningNumbersint = new int[ARRAY_SIZE];
        Random number = new Random();

        // Attributes
        private int? _number1;
        private int? _number2;
        private int? _number3;
        private int? _number4;
        private int _numberMatching = 0;

        // Base Constructor.
        public Lotto()
        {
            _number1 = null;
            _number2 = null;
            _number3 = null;
            _number4 = null;

            // For loop to generate other random numbers.
            for (int num = 0; num < ARRAY_SIZE; num++)
            {
                _winningNumbersint[num] = number.Next(low, high);
            }
        }

        // Default Constructor.
        public Lotto(string number1, string number2, string number3, string number4)
        {
            int temp1;
            int temp2;
            int temp3;
            int temp4;

            if (!int.TryParse(number1, out temp1) || !int.TryParse(number2, out temp2) || !int.TryParse(number3, out temp3) || !int.TryParse(number4, out temp4))
            {
                throw new ArgumentOutOfRangeException("Input must be a positive number.");
            }
            else if (temp1 < low || temp1 > high || temp2 < low || temp2 > high || temp3 < low || temp3 > high || temp4 < low || temp4 > high)
            {
                throw new ArgumentOutOfRangeException("Ticket number must be between the numbers 1 and 72.");
            }
            else
            {
                _number1 = Convert.ToInt32(number1);
                _number2 = Convert.ToInt32(number1);
                _number3 = Convert.ToInt32(number1);
                _number4 = Convert.ToInt32(number1);
            }

            // For loop to generate other random numbers.
            for (int num = 0; num < ARRAY_SIZE; num++)
            {
                _winningNumbersint[num] = number.Next(low, high);
            }
        }

        // Winning Numbers Attribute for use in Unit Testing.
        public int[] WinningNumbers
        {
            get { return _winningNumbersint; }
            set
            {
                if (value.Length != ARRAY_SIZE)
                {
                    throw new ArgumentOutOfRangeException("Array must contain 4 integer values.");
                }
                _winningNumbersint = value;
            }
        }

        // First Number Attribute.
        [Required(ErrorMessage = "ERROR: Cannot be blank.")]
        [Range(low, high)]
        public int? FirstNumber
        {
            get
            {
                return _number1;
            }
            set
            {
                _number1 = value;
            }
        }

        // Second Number Attribute.
        [Required(ErrorMessage = "ERROR: Cannot be blank.")]
        [Range(low, high)]
        public int? SecondNumber
        {
            get
            {
                return _number2;
            }
            set
            {
                _number2 = value;
            }
        }

        // Third Number Attribute.
        [Required(ErrorMessage = "ERROR: Cannot be blank.")]
        [Range(low, high)]
        public int? ThirdNumber
        {
            get
            {
                return _number3;
            }
            set
            {
                _number3 = value;
            }
        }

        // Fourth Number Attribute.
        [Required(ErrorMessage = "ERROR: Cannot be blank.")]
        [Range(low, high)]
        public int? FourthNumber
        {
            get
            {
                return _number4;
            }
            set
            {
                _number4 = value;
            }
        }

        // Check Matching Ticket Numbers.
        public int Compare()
        {
            // Check numbers.

            if (_number1 == _winningNumbersint[0])
            {
                _numberMatching += 1;
            }

            if (_number2 == _winningNumbersint[1])
            {
                _numberMatching += 1;
            }

            if (_number3 == _winningNumbersint[2])
            {
                _numberMatching += 1;
            }

            if (_number4 == _winningNumbersint[3])
            {
                _numberMatching += 1;
            }
            return _numberMatching;
        }
        // Display Winning Ticket Numbers.
        public string DisplayTicket()
        {
            string result1 = _winningNumbersint[0].ToString();
            string result2 = _winningNumbersint[1].ToString();
            string result3 = _winningNumbersint[2].ToString();
            string result4 = _winningNumbersint[3].ToString();

            return "{" + result1 + "," + result2 + "," + result3 + "," + result4 + "}";
        }
        override
        public String ToString()
        {
            return ("Winning Numbers: " + this.DisplayTicket() + ", Ticket Numbers: " + this.FirstNumber + "," + this.SecondNumber + "," + this.ThirdNumber + "," + this.FourthNumber + ", Matching Numbers: " + this.Compare());
        }
    }
}
