﻿using System;
using Apache.Cassandra;
using FluentCassandra.Types;

namespace FluentCassandra.Operations
{
	public class RemoveColumn : ColumnFamilyOperation<Void>
	{
		/*
		 * remove(keyspace, key, column_path, timestamp, consistency_level)
		 */

		public CassandraType Key { get; private set; }

		public CassandraType SuperColumnName { get; private set; }

		public CassandraType ColumnName { get; private set; }

		public override Void Execute()
		{
			var path = new CassandraColumnPath {
				ColumnFamily = ColumnFamily.FamilyName
			};

			if (SuperColumnName != null)
				path.SuperColumn = SuperColumnName;

			if (ColumnName != null)
				path.Column = ColumnName;

			Session.GetClient().remove(
				Key,
				path,
				DateTimeOffset.Now.ToTimestamp(),
				Session.WriteConsistency
			);

			return new Void();
		}

		public RemoveColumn(CassandraType key, CassandraType superColumnName, CassandraType columnName)
		{
			Key = key;
			SuperColumnName = superColumnName;
			ColumnName = columnName;
		}

		public RemoveColumn(CassandraType key, CassandraType columnName)
		{
			Key = key;
			ColumnName = columnName;
		}
	}
}