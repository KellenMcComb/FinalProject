// Author:          Kellen McComb
// Last Modified:   April 06, 2021
// Description:
//  This file contains the Car class and related functions for use in 
//  CarInventoryForms. 

using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Car
    {
        // Holds the number of cars and the car ID number.
        private static int carCount = 0;
        private int carIdentificationNumber = 0;

        // Variables for car data.
        private string carMake = String.Empty;
        private string carModel = String.Empty;
        private int carYear = 0;
        private decimal carPrice = 0;
        private bool carNewStatus = false;

        /// <summary>
        /// Constructor - Default - creates a new car object.
        /// </summary>
        public Car()
        {
            carCount += 1;
            carIdentificationNumber = carCount;
        }

        /// <summary>
        /// Constructor - Parameterized - creates a new car object
        /// </summary>
        /// <param name="make">Car's make</param>
        /// <param name="model">Car's model</param>
        /// <param name="year">Car's manufacture year</param>
        /// <param name="price">Car's price</param>
        /// <param name="newStatus">true if a Car is new</param>
        public Car(string make, string model, int year, decimal price, bool newStatus) : this()
        {
            // The ": this()" part above calls the default constructor, setting the Id.

            // Set all of the instance variables within this class using the values
            // passed into this constructor.
            carMake = make;
            carModel = model;
            carYear = year;
            carPrice = price;
            carNewStatus = newStatus;
        }

        /// <summary>
        /// Count ReadOnly Property - Gets the number of cars that have been instantiated.
        /// </summary>
        public int Count
        {
            get
            {
                return carCount;
            }
        }

        /// <summary>
        /// IdentificationNumber ReadOnly Property - Gets a specific cars' identification number
        /// </summary>
        public int IdentificationNumber
        {
            get
            {
                return carIdentificationNumber;
            }
        }

        /// <summary>
        /// Make property - Gets and Sets the make of a car
        /// </summary>
        public string Make
        {
            get
            {
                return carMake;
            }
            set
            {
                carMake = value;
            }
        }

        /// <summary>
        /// Make property - Gets and Sets the model of a car
        /// </summary>
        public string Model
        {
            get
            {
                return carModel;
            }
            set
            {
                carModel = value;
            }
        }

        /// <summary>
        /// Year property - Gets and Sets the year of a car
        /// </summary>
        public int Year
        {
            get
            {
                return carYear;
            }
            set
            {
                carYear = value;
            }
        }

        /// <summary>
        /// Price property - Gets and Sets the price of a car
        /// </summary>
        public decimal Price
        {
            get
            {
                return carPrice;
            }
            set
            {
                carPrice = value;
            }
        }

        /// <summary>
        /// NewStatus Property - >Gets and Sets the New status of a car
        /// </summary>
        public bool NewStatus
        {
            get
            {
                return carNewStatus;
            }
            set
            {
                carNewStatus = value;
            }
        }

        /// <summary>
        /// GetCarData is a function that displays car data based on the private properties within 
        /// the class scope
        /// </summary>
        /// <returns>string describing the customer</returns>
        public string GetCarData()
        {
            return "This car is a " + (carNewStatus ? "new" : "used") + carYear + " " + carMake + 
                " " + carModel + " priced at " + carPrice + ".";
        }
    }
}
