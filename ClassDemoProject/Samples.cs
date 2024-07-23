using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorDemo
{
    //these are all types that exists under namespace
    internal class Car{
        //Properties - are method so field can be read(get) or set
        internal FuelType TypeOfFuel { 
            get { return _fuelType; }
        }
        internal int PassengerCapacity => _passengerCount;
        internal string VIN => _vin;
        internal decimal OdometerInMiles => Math.Round(_odometer / 1600M,1);
        internal decimal OdometerInKM => Math.Round(_odometer / 1000,1);
        //Field -- is the actual data,
        // fields are usually private so its only accessible by other members of the class
        private int _passengerCount; //4 bytes
        private FuelType _fuelType; //4byte
        private string _vin; //4bytes
        private decimal _odometer = 0;//16bytes

        //Methods - functionality(method),Constructor,Indexer,Finalizer,Deconstructor 
        //This is a constructor where the method has NO return, and has the same name as the class
        internal Car(string vin,FuelType ft,int passengers) {
            _vin = vin;
            _fuelType = ft;
            _passengerCount= passengers;
        }
        //This is a regular method called Drive
        internal void Drive(decimal distanceInMeters) {
            _odometer += distanceInMeters;
        }

    }
    internal record Record1 { }
    internal struct SampleStruct { }
    internal interface IDemo;
    internal enum FuelType
    {
        Gas=0,
        Hybrid=1,
        Electric=2,
        E85=3,
        Diesel=4
    }
    internal enum CardSuit { 
        Spade,
        Heart,
        Club,
        Diamond
    }
    internal delegate int MyDelegate(int x, int y);

}
