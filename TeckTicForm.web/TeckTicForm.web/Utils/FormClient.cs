using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeckTicForm.web.Utils
{
    public class FormClient
    {
		private string nif;
		private string name;
		private string address;
		private string postalCode;
		private string phone;
		private string mobile;
		private string brand;
		private string model;
		private string type;
		private string serial;
		private string items;
		private string email;
		private string problem;
		private string reproduce;
		private string processNumber;
		private string city;
		private string logoPath;

		public string LogoPath
		{
			get { return logoPath; }
			set { logoPath = value; }
		}


		public string City
		{
			get { return city; }
			set { city = value; }
		}


		public string ProcessNumber
		{
			get { return processNumber; }
			set { processNumber = value; }
		}


		public string Reproduce
		{
			get { return reproduce; }
			set { reproduce = value; }
		}


		public string Problem
		{
			get { return problem; }
			set { problem = value; }
		}


		public string Email
		{
			get { return email; }
			set { email = value; }
		}


		public string Items
		{
			get { return items; }
			set { items = value; }
		}


		public string Serial
		{
			get { return serial; }
			set { serial = value; }
		}


		public string Type
		{
			get { return type; }
			set { type = value; }
		}



		public string Model
		{
			get { return model; }
			set { model = value; }
		}


		public string Brand
		{
			get { return brand; }
			set { brand = value; }
		}


		public string Mobile
		{
			get { return mobile; }
			set { mobile = value; }
		}

		public string Phone
		{
			get { return phone; }
			set { phone = value; }
		}


		public string PostalCode
		{
			get { return postalCode; }
			set { postalCode = value; }
		}


		public string Address
		{
			get { return address; }
			set { address = value; }
		}


		public string Name
		{
			get { return name; }
			set { name = value; }
		}


		public string NIF
		{
			get { return nif; }
			set { nif = value; }
		}

	}
}