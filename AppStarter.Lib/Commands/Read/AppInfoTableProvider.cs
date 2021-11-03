using AppStarter.Data.Model;
using Console.Lib;
using System.Collections.Generic;

namespace AppStarter.Lib.Commands
{
	public class AppInfoTableProvider : ModelATableProvider<AppInfo>
	{
		protected override void CreateTableHeader()
		{
			SetColumns();
		}

		private void SetColumns()
		{
			AddColumn(GetColumnData(nameof(AppInfo.Id)));
			AddColumn(GetColumnData(nameof(AppInfo.Name)));
			AddColumn(GetColumnData(nameof(AppInfo.Description)));
			AddColumn(GetColumnData(nameof(AppInfo.Path)));
		}

		protected override void CreateTableRow(AppInfo e)
		{
			AddValue(GetColumnData(nameof(AppInfo.Id)), e.Id.ToString());
			AddValue(GetColumnData(nameof(AppInfo.Name)), e.Name);
			AddValue(GetColumnData(nameof(AppInfo.Description)), e.Description);
			AddValue(GetColumnData(nameof(AppInfo.Path)), e.Path);
		}

		protected override void SetColumnsSize(List<AppInfo> items)
		{
			SetColumn(items, nameof(AppInfo.Id), (e) => e.Id.ToString().Length);
			SetColumn(items, nameof(AppInfo.Name), (e) => e.Name.Length);
			SetColumn(items, nameof(AppInfo.Description), (e) => e.Description.Length);
			SetColumn(items, nameof(AppInfo.Path), (e) => e.Path.Length);
		}
	}
}