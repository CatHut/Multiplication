using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatHut
{
    public class ShapeDrawerClass
    {
        private List<Shape> shapes = new List<Shape>();

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public void Draw(Graphics g)
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw(g);
            }
        }

    }
}
