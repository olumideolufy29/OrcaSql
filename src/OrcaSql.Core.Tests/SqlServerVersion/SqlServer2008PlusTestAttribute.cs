﻿using System;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;

namespace OrcaSql.Core.Tests.SqlServerVersion
{
	public class SqlServer2008PlusTestAttribute : TestCaseSourceAttribute
	{
		private static IEnumerable<TestCaseData> versions
		{
			get
			{
				foreach (var value in Enum.GetValues(typeof(DatabaseVersion)))
				{
					if (ConfigurationManager.ConnectionStrings[value.ToString()] == null)
						continue;

					if ((DatabaseVersion)value >= DatabaseVersion.SqlServer2008)
						yield return new TestCaseData(value).SetCategory(value.ToString());
				}
			}
		}

		public SqlServer2008PlusTestAttribute()
			: base(typeof(SqlServer2008PlusTestAttribute), "versions")
		{ }
	}
}