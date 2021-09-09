using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dz24_06_21.Classes;
using static dz24_06_21.Classes.Car;

namespace dz24_06_21.Interfaces
{

    interface ICar
    {
        EngineTypes EngineType { get; }
        TransmissionTypes TransmissionType { get; }
        BodyTypes BodyType { get; }
        FuelTypes FuelType { get; }

    }

}
