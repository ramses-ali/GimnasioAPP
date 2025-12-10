using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GimnasioApp
{
    public class CircularPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            using (GraphicsPath graphicsPath = new GraphicsPath())
            {
                // Define un rectángulo para el círculo (ajusta el tamaño según tu PictureBox)
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                graphicsPath.AddEllipse(rect);

                // Aplica la forma al PictureBox
                this.Region = new Region(graphicsPath);

                // Dibuja la imagen dentro del círculo (si hay una imagen)
                if (this.Image != null)
                {
                    // Puedes usar GraphicsPath para el suavizado
                    paintEventArgs.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    paintEventArgs.Graphics.DrawImage(this.Image, rect);
                }
            }
            base.OnPaint(paintEventArgs);
        }
    }
}
