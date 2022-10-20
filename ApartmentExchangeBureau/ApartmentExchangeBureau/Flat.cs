using System;

namespace ApartmentExchangeBureau
{
    public struct Flat
    {
        private int rooms;

        public int Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        private int floor;

        public int Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        private double area;

        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", rooms, floor, area, address);
        }
    }
}
