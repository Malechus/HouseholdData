using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseholdData.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdData.Services
{
	public class LocalData : ILocalData
	{
		private string HouseholdConnection { get; }
		
		public HouseholdContext householdContext{ get; }
		
		public LocalData()
		{
			HouseholdConnection = GetConnStr("HouseholdConnection");

			householdContext = new HouseholdContext(HouseholdConnection);
		}
		
		private string GetConnStr(string connName)
		{
			string? result = Environment.GetEnvironmentVariable(connName);

			if(result is null)
			{
				throw new InvalidDataException("Connection String not found." + connName);
			}

			return result;
		}
	}
}