using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz24_06_21.Classes.Cars
{
    class FordMustang : Car
    {
        public FordMustang()
            : base(EngineTypes.Gas, TransmissionTypes.Automatic, BodyTypes.ThreeVolume, 100)
        {

        }
    }
}
