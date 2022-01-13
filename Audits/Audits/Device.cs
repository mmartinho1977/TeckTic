using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits
{
    public class Device
    {
		private int id;
		private string code;
		private string netBios;
		private string functionality;
		private string type;
		private string brand;
		private string model;
		private string firmware;
		private string cpu;
		private string serialNumber;
		private Dictionary<string,int> drives;
		private int memorySize;
		private string operationSystem;
		private string operationSystemVersion;
		private string operationSystemKey;
		private string ipAddress;
		private bool dhcpEnable;
		private string macAddress;
		private DateTime dateTime;
		private List<string> networkShares;
		private List<User> users;
		private List<Software> applications;

		public List<Software> Applications
		{
			get { return applications; }
			set { applications = value; }
		}


		public List<User> Users
		{
			get { return users; }
			set { users = value; }
		}


		public List<string> NetworkShares
		{
			get { return networkShares; }
			set
			{
				if (this.networkShares == null)
				{
					this.networkShares = new List<string>();
				}
				networkShares = value; }
		}

		

		public DateTime InstalationDate
		{
			get { return dateTime; }
			set { dateTime = value; }
		}


		public string MacAddress
		{
			get { return macAddress; }
			set { macAddress = value; }
		}


		public bool DHCPEnable
		{
			get { return dhcpEnable; }
			set { dhcpEnable = value; }
		}


		public string IpAddress
		{
			get { return ipAddress; }
			set { ipAddress = value; }
		}


		public string OperationSystemKey
		{
			get { return operationSystemKey; }
			set { operationSystemKey = value; }
		}


		public string OperationSystemVersion
		{
			get { return operationSystemVersion; }
			set { operationSystemVersion = value; }
		}


		public string OperationSystem
		{
			get { return operationSystem; }
			set { operationSystem = value; }
		}


		public int MemorySize
		{
			get { return memorySize; }
			set { memorySize = value; }
		}


		public Dictionary<string,int> Drives
		{
			get { return drives; }
			set { drives = value; }
		}


		public string SerialNumber
		{
			get { return serialNumber; }
			set { serialNumber = value; }
		}


		public string CPU
		{
			get { return cpu; }
			set { cpu = value; }
		}


		public string Firmware
		{
			get { return firmware; }
			set { firmware = value; }
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


		public string Type
		{
			get { return type; }
			set { type = value; }
		}


		public string Functionality
		{
			get { return functionality; }
			set { functionality = value; }
		}


		public string MyProperty
		{
			get { return netBios; }
			set { netBios = value; }
		}


		public string Code
		{
			get { return code; }
			set { code = value; }
		}


		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public override string ToString()
		{
			return string.Format("[{0}] {1}-{2}", this.code, this.netBios, this.functionality);
		}

	}
}
