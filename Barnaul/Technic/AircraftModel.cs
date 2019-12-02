using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftModelsInitialize
{
    [Serializable]
    class AircraftModel
    {
        public int Type { get; set; } // тип
        public String Name { get; set; } // название
        public int Forsage { get; set; } // максимальнаяая скорость, км/ч
        public int Speed { get; set; } // крейсерская скорость, км/ч
        public int Floor { get; set; }  // эшелон высоты, 1-4

        public AircraftModel(int type, String name, int speed, int forsage, int floor)
        {
            Type = type;
            Name = name;
            Forsage = forsage;
            Speed = speed;
            Floor = floor;
        }
    }
}
