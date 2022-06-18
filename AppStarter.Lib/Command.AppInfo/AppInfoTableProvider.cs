using AppStarter.Data;
using DataToTable;
using System.Collections.Generic;
using System.Linq;

namespace AppStarter.Lib;

public class AppInfoTableProvider 
	: ModelATable<AppInfo>
{
    public AppInfoTableProvider(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<AppInfo> columnCalculator) 
			: base(tableTextEditor
				, columnCalculator)
    {
    }

    protected override void CreateTableHeader()
	{
		SetColumns();
	}

	private void SetColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(AppInfo.Id)));
		Editor.AddColumn(GetColumnData(nameof(AppInfo.Name)));
		Editor.AddColumn(GetColumnData(nameof(AppInfo.Description)));
		Editor.AddColumn(GetColumnData(nameof(AppInfo.Path)));
	}

	protected override void CreateTableRow(AppInfo model)
	{
		Editor.AddValue(GetColumnData(nameof(AppInfo.Id)), model.Id.ToString());
		Editor.AddValue(GetColumnData(nameof(AppInfo.Name)), model.Name);
		Editor.AddValue(GetColumnData(nameof(AppInfo.Description)), model.Description);
		Editor.AddValue(GetColumnData(nameof(AppInfo.Path)), model.Path);
	}

	protected override void SetColumnsSize(List<AppInfo> models)
	{
		SetColumn(nameof(AppInfo.Id), GetIdsLength(models));
		SetColumn(nameof(AppInfo.Name), GetNamesLength(models));
		SetColumn(nameof(AppInfo.Description), GetDescsLength(models));
		SetColumn(nameof(AppInfo.Path), GetPathLength(models));
	}

	private static List<int> GetPathLength(List<AppInfo> models)
    {
        var rows = models.Select(e => e.Path.Length).ToList();
		rows.Insert(0, nameof(AppInfo.Path).Length);
		return rows;
    }
}