﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProxy.Entities
{
    using DatabaseConnector;

    public class ShowableUnit
    {
        public ShowableUnit() { }

        public ShowableUnit(Unit unit)
        {
            Factor = unit.convert_factor;
            Type = unit.UnitType.type_name;
            Name = unit.unit_name;
            Id = unit.id;
        }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Factor { get; set; }
        public int Id;
    }
}


