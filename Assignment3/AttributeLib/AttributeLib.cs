namespace AttributeLib
{
    public class DataTable: Attribute
    {
		private string TableName;

		public string Tablename
		{
			get { return TableName; }
			set { TableName = value; }
		}
	}

	public class DataColumn : Attribute
	{
		private string _ColumnName;
		private string _ColumnType;

		public string ColumnType
		{
			get { return _ColumnType; }
			set { _ColumnType = value; }
		}

		public string ColumnName
		{
			get { return _ColumnName; }
			set { _ColumnName = value; }
		}
	}

    public class KeyColumn : Attribute
    {
        private string _KeyColumnName;
        public string KeyColumnName
        {
            get { return _KeyColumnName; }
            set { _KeyColumnName = value; }
        }
    }
    public class unMapped : Attribute
    {
        
    }
}
