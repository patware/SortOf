namespace SortOf.Model
{
	public class DataItem
	{
		public string Title
		{
			get;
			private set;
		}

		public DataItem(string title)
		{
			Title = title;
		}
	}
}