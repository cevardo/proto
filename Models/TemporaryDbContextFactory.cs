﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Models
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<DbContext>
    {
        public DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DbContext>();

            var connectionUnix = "Server=localhost,1433;Initial Catalog=FoundryRowDBLocalMac;Persist Security Info=False;User ID=sa;Password=P@55w0rd;";
            var connectionWin = "Server=(localdb)\\MSSQLLocalDB; Database=FoundryRowDBLocal; Trusted_Connection=True; MultipleActiveResultSets=true";

            var connection = Environment.OSVersion.Platform == PlatformID.Unix ? connectionUnix : connectionWin;

            builder.UseSqlServer(connection,
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(DbContext).GetTypeInfo().Assembly.GetName().Name));

            builder.UseOpenIddict();

            return new DbContext(builder.Options);
        }
    }
}
