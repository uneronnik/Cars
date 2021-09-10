using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz24_06_21.Classes.Cars
{
    class HavalH9 : Car
    {
        
        public HavalH9()
            : base(EngineTypes.Gas, TransmissionTypes.Automatic, BodyTypes.TwoVolume, 50)
        {
             
        }
    }
}
