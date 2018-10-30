using System;
using GalaSoft.MvvmLight;
using SortOf.Model;
using System.Linq;

namespace SortOf.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// See http://www.mvvmlight.net
	/// </para>
	/// </summary>
	public class MainViewModel : ViewModelBase
	{
		private readonly IDataService _dataService;


		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(IDataService dataService)
		{
			_dataService = dataService;

			this.PropertyChanged += MainViewModel_PropertyChanged;

			_dataService.GetData(
				(item, error) =>
				{
					if (error != null)
					{
						// Report error here
						return;
					}

					Input = item.LastInput;
				});

		}

		private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch(e.PropertyName)
			{
				case InputPropertyName:
					Sort();
					_dataService.SaveData(this.Input);
					break;
			}
		}

		private void Sort()
		{
			Output = string.Join(Environment.NewLine, Input
				.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
				.OrderBy(s => s));

		}


		////public override void Cleanup()
		////{
		////    // Clean up if needed

		////    base.Cleanup();
		////}
		///
		#region Properties
		#region Input
		/// <summary>
		/// The <see cref="Input" /> property's name.
		/// </summary>
		public const string InputPropertyName = "Input";

		private string _input = "input";

		/// <summary>
		/// Sets and gets the Input property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string Input
		{
			get
			{
				return _input;
			}

			set
			{
				if (_input == value)
				{
					return;
				}

				_input = value;
				RaisePropertyChanged(InputPropertyName);
			}
		}
		#endregion
		#region Output
		/// <summary>
			/// The <see cref="Output" /> property's name.
			/// </summary>
		public const string OutputPropertyName = "Output";

		private string _output = "Output";

		/// <summary>
		/// Sets and gets the Output property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string Output
		{
			get
			{
				return _output;
			}

			set
			{
				if (_output == value)
				{
					return;
				}

				_output = value;
				RaisePropertyChanged(OutputPropertyName);
			}
		}
		#endregion
		#endregion

	}
}