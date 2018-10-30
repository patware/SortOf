using System;
using SortOf.Model;

namespace SortOf.Design
{
	public class DesignDataService : IDataService
	{
		public void GetData(Action<DataItem, Exception> callback)
		{
			// Use this to create design time data

			var item = new DataItem("Bernie\r\nAgatha");
			callback(item, null);
		}
		public void SaveData(string lastInput)
		{
			/* nothing to do in design mode */
		}
	}
}