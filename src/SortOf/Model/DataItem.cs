namespace SortOf.Model
{
	public class DataItem
	{
		public string LastInput
		{
			get;
			private set;
		}

		public DataItem(string lastInput)
		{
			LastInput = lastInput;
		}
	}
}