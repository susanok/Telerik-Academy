namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;
    using System.Text;

    public abstract class Furniture : IFurniture
    {
        private decimal height;
        private MaterialType material;
        private string model;
        private decimal price;

        public Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Height = height;
            this.Model = model;
            this.material = material;
            this.Price = price;
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height can not be less or equal to zero.");
                }

                this.height = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material.ToString();
            }         
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Model can not be null, empty ot less than 3 symbols.");
                }

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price can not be less or equal to zero.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height);

            return result.ToString();
        }
    }
}
