using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E12272.Models
{
  public class gps
    {

        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        public int latitud { get; set; }

        public int longitud { get; set; }

        [MaxLength(100)]
        public String direccion { get; set; }

        [MaxLength(20)]
        public String direcorta { get; set; }
    }
}
