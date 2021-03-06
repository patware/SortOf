﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortOf.Model
{
	public interface IDataService
	{
		void GetData(Action<DataItem, Exception> callback);

		void SaveData(string lastInput);
	}
}
