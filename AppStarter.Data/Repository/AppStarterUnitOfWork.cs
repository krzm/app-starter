using AppStarter.Data.Model;
using Core.Lib;
using System;

namespace AppStarter.Data.Repository
{
	public class AppStarterUnitOfWork : IAppStarterUnitOfWork
	{
		private readonly AppStarterDbContext context = new();
		private EFGenericRepository<AppInfo, AppStarterDbContext> game;
		
		private bool disposed = false;

		public EFGenericRepository<AppInfo, AppStarterDbContext> AppInfo
		{
			get
			{

				if (game == null)
				{
					game = new EFGenericRepository<AppInfo, AppStarterDbContext>(context);
				}
				return game;
			}
		}

		public void Save()
		{
			context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}