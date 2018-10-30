using System;

namespace SortOf.Model
{
	public class DataService : IDataService
	{
		private const string DefaultLastInput = "Enter some text\r\nIn any order\r\nand it will be sorted\r\nand displayed\r\nthe right order";

		public void GetData(Action<DataItem, Exception> callback)
		{
			// Use this to connect to the actual data service

			var s = SortOf.Properties.Settings.Default.LastInput;

			if (string.IsNullOrEmpty(s))
				s = DefaultLastInput;

			var item = new DataItem(s);

			callback(item, null);
		}

		public void SaveData(string lastInput)
		{
			SortOf.Properties.Settings.Default.LastInput = lastInput;

			SortOf.Properties.Settings.Default.Save();

		}
	}
}