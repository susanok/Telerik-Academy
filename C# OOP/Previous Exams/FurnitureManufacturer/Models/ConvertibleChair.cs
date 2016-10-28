namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System.Text;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted = false;
        private decimal convertedHeight = 0.10m;
        private decimal initialheight;

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.initialheight = height;
        }
        
        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
        }

        public void Convert()
        {
            if (isConverted)
            {
                this.isConverted = false;
                this.Height = this.initialheight;
            }
            else
            {
                this.isConverted = true;
                this.Height = this.convertedHeight;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            if (this.IsConverted)
            {
                result.AppendFormat(", State: {0}", "Converted");
            }
            else
            {
                result.AppendFormat(", State: {0}", "Normal");
            }
            result.AppendFormat(", State: {0}", this.IsConverted ? "Converted" : "Normal");
            return result.ToString();
        }
    }
}
