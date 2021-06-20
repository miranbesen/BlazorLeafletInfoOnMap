using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLeaflet.Samples.Data
{
    public class Eczane
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Sehir { get; set; }
       
            
        public double Lat { get; set; }

    
        public double Long { get; set; }
    }
}
