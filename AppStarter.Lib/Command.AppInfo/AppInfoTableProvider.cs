using AppStarter.Data.Model;
using DataToTable;
using System.Collections.Generic;
using System.Linq;

namespace AppStarter.Lib;

public class AppInfoTableProvider : ModelATable<AppInfo>
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

	protected override void CreateTableRow(AppInfo model)
	{
		AddValue(GetColumnData(nameof(AppInfo.Id)), model.Id.ToString());
		AddValue(GetColumnData(nameof(AppInfo.Name)), model.Name);
		AddValue(GetColumnData(nameof(AppInfo.Description)), model.Description);
		AddValue(GetColumnData(nameof(AppInfo.Path)), model.Path);
	}

	protected override void SetColumnsSize(List<AppInfo> models)
	{
		SetColumn(nameof(AppInfo.Id), GetIdsLength(models));
		SetColumn(nameof(AppInfo.Name), GetNameLength(models));
		SetColumn(nameof(AppInfo.Description), GetDescriptionLength(models));
		SetColumn(nameof(AppInfo.Path), GetPathLength(models));
	}

	private static List<int> GetIdsLength(List<AppInfo> models)
    {
        var rows = models.Select(e => e.Id.ToString().Length).ToList();
		rows.Insert(0, nameof(AppInfo.Id).Length);
		return rows;
    }

	private static List<int> GetNameLength(List<AppInfo> models)
    {
        var rows = models.Select(e => e.Name.Length).ToList();
		rows.Insert(0, nameof(AppInfo.Name).Length);
		return rows;
    }

	private static List<int> GetDescriptionLength(List<AppInfo> models)
    {
        var rows = models.Select(e => e.Description.Length).ToList();
		rows.Insert(0, nameof(AppInfo.Description).Length);
		return rows;
    }

	private static List<int> GetPathLength(List<AppInfo> models)
    {
        var rows = models.Select(e => e.Path.Length).ToList();
		rows.Insert(0, nameof(AppInfo.Path).Length);
		return rows;
    }
}