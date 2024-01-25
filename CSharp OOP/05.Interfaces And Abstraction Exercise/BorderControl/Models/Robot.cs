using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Interfaces;

namespace BorderControl.Models
{
    public class Robot : IIdentifier, IRobot
    {
        public string Id { get; set; }
        public string Model { get; set; }

        public Robot(string model, string Id)
        {
            this.Model = model;
            this.Id = Id;
        }
    }
}
