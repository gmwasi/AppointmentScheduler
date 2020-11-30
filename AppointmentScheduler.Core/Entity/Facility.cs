using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentScheduler.Core.Entity
{
    public class Facility : Entity
    {
        public string Name { get; set; }
        public string MflCode { get; set; }
        public string Location { get; set; }
        public string PostalAddress { get; set; }
        public int CountyId { get; set; }
        public int MaritalStatusId { get; set; }
        public int FacilityLevelId { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
    }
}
