
using devDept.Eyeshot.Entities;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Drawing;

namespace SuperHeroAPI.Models
{
    public class PointCloud
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Color Color { get; set; } = Color.Blue;


        public PointCloud() { }
    }
}
