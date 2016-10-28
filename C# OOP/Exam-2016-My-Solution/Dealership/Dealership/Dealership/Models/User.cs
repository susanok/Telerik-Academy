namespace Dealership.Models
{
    using Dealership.Contracts;
    using Dealership.Common.Enums;
    using Dealership.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class User : IUser
    {
        private const string FirstNameAsString = "Firstname";
        private const string LastNameAsString = "Lastname";
        private const string PasswordAsString = "Password";
        private const string UsernameAsString = "Username";

        public Role Role { get; set; }

        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private IList<IVehicle> vehicles;
        private int count = 5;

        public User(string username, string firstName, string lastName, string password, string role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = (Role)Enum.Parse(typeof(Role), role);
            this.vehicles = new List<IVehicle>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                int range = value.Length;
                Validator.ValidateIntRange(range, Constants.MinNameLength, Constants.MaxNameLength,
                    String.Format(Constants.StringMustBeBetweenMinAndMax, User.FirstNameAsString,
                    Constants.MinNameLength, Constants.MaxNameLength));
                Validator.ValidateNull(value, Constants.UserCannotBeNull);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                int range = value.Length;
                Validator.ValidateIntRange(range, Constants.MinNameLength, Constants.MaxNameLength,
                    String.Format(Constants.StringMustBeBetweenMinAndMax, User.LastNameAsString,
                    Constants.MinNameLength, Constants.MaxNameLength));
                Validator.ValidateNull(value, Constants.UserCannotBeNull);

                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                int range = value.Length;
                Validator.ValidateIntRange(range, Constants.MinPasswordLength, Constants.MaxPasswordLength,
                    String.Format(Constants.StringMustBeBetweenMinAndMax, User.PasswordAsString,
                    Constants.MinPasswordLength, Constants.MaxPasswordLength));
                Validator.ValidateNull(value, Constants.UserCannotBeNull);
                Validator.ValidateSymbols(value, Constants.PasswordPattern,
                    String.Format(Constants.InvalidSymbols, User.PasswordAsString));

                this.password = value;
            }
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                int range = value.Length;
                Validator.ValidateIntRange(range, Constants.MinNameLength, Constants.MaxNameLength,
                    String.Format(Constants.StringMustBeBetweenMinAndMax, User.UsernameAsString,
                    Constants.MinNameLength, Constants.MaxNameLength));
                Validator.ValidateNull(value, Constants.UserCannotBeNull);
                Validator.ValidateSymbols(value, Constants.UsernamePattern,
                    String.Format(Constants.InvalidSymbols, User.UsernameAsString));

                this.username = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            //Just add the comment to the list
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            //If the user is admin he cannot add a vehicle
            //If the user is not VIP he cannot add more than 5 vehicles
            if(this.Role == Role.Admin)
            {
                throw new ArgumentException(Constants.AdminCannotAddVehicles);
            }

            if(this.Role == Role.Normal)
            {
                if(count <= 0)
                {
                    throw new ArgumentException(String.Format(Constants.NotAnVipUserVehiclesAdd, "5"));
                }
                this.Vehicles.Add(vehicle);
                count--;
            }

            this.Vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            var result = new StringBuilder();
            int counter = 1;

            result.AppendFormat("--USER {0}--", this.Username);
            result.AppendLine();

            foreach (var item in this.Vehicles)
            {
                result.AppendFormat("{0}. ", counter);
                result.Append(item.ToString());
                counter++;
            }

            return result.ToString();
            
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            //If the author of the comment is not the current user he cannot remove it
            if(this.Username != commentToRemove.Author)
            {
                throw new ArgumentException(Constants.YouAreNotTheAuthor);
            }

            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            //Just remove the vehicle from the list

            int index = this.Vehicles.IndexOf(vehicle);
            this.Vehicles.RemoveAt(index);
        }

        public override string ToString()
        {
            return String.Format("Username: {0}, FullName: {1} {2}, Role: {3}",
                this.Username, this.FirstName, this.LastName, this.Role.ToString());
        }
    }
}
//this.Role = (Role)Enum.Parse(typeof(Role), role);
