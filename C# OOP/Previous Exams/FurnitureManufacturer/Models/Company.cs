using System;
using System.Collections.Generic;
using FurnitureManufacturer.Interfaces;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private ICollection<IFurniture> furnitures;
        private string name;
        private string resistrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.furnitures = new List<IFurniture>();
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Name can not be null, empty ot less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.resistrationNumber;
            }
            private set
            {
                if(value.Length != 10 || !CheckRegistrationNumber(value))
                {
                    throw new ArgumentOutOfRangeException("Registration number must be exactly 10 symbols and must contain only digits.");
                }

                this.resistrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var result = new StringBuilder();

            result.Append(string.Format("{0} - {1} - ", this.Name, this.RegistrationNumber));
            if(this.Furnitures.Count == 0)
            {
                result.Append("no furnitures");
                result.AppendLine();
            }
            else if(this.Furnitures.Count == 1)
            {
                result.Append("1 furniture");
                result.AppendLine();
                foreach (var item in this.Furnitures)
                {
                    result.Append(item.ToString());
                }
                result.AppendLine();
            }
            else
            {
                result.AppendFormat("{0} furnitures", this.Furnitures.Count);
                result.AppendLine();
                var sortedFurnitures = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);
                foreach(var item in sortedFurnitures)
                {
                    result.Append(item.ToString());
                    result.AppendLine();
                }
            }

            return result.ToString();
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        private bool CheckRegistrationNumber(string number)
        {
            bool areOnlyDigits = true;

            for(int i = 0; i < number.Length; i++)
            {
                if((int)number[i] <= 47 || (int)number[i] >= 58)
                {
                    areOnlyDigits = false;
                    break;
                }
            }

            return areOnlyDigits;
        }
    }
}
