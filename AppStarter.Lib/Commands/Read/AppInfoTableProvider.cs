using AppStarter.Data.Model;
using Console.Lib;
using System.Collections.Generic;
using System.Linq;

namespace AppStarter.Lib.Commands
{
	public class AppInfoTableProvider : ModelATableProvider<AppInfo>
	{
        public AppInfoTableProvider(
			IColumnCalculator<AppInfo> columnCalculator) : base(columnCalculator)
        {
        }

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
			SetColumn(nameof(AppInfo.Id), GetIdsLength(items));
			SetColumn(nameof(AppInfo.Name), GetNameLength(items));
			SetColumn(nameof(AppInfo.Description), GetDescriptionLength(items));
			SetColumn(nameof(AppInfo.Path), GetIdsLength(items));
		}

		private List<int> GetIdsLength(List<AppInfo> models)
        {
            var rows = models.Select(e => e.Id.ToString().Length).ToList();
			rows.Insert(0, nameof(AppInfo.Id).Length);
			return rows;
        }

		private List<int> GetNameLength(List<AppInfo> models)
        {
            var rows = models.Select(e => e.Name.ToString().Length).ToList();
			rows.Insert(0, nameof(AppInfo.Name).Length);
			return rows;
        }

		private List<int> GetDescriptionLength(List<AppInfo> models)
        {
            var rows = models.Select(e => e.Description.ToString().Length).ToList();
			rows.Insert(0, nameof(AppInfo.Description).Length);
			return rows;
        }

		private List<int> GetPathLength(List<AppInfo> models)
        {
            var rows = models.Select(e => e.Path.ToString().Length).ToList();
			rows.Insert(0, nameof(AppInfo.Path).Length);
			return rows;
        }
	}
}