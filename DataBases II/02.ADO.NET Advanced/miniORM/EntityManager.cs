using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using miniORM.Attributes;

namespace miniORM
{
    class EntityManager:IDbContext
    {
        private SqlConnection connection;
        private string connectionString;
        private bool isCodeFirst;

        public EntityManager(string connectionString, bool isCodeFirst)
        {
            this.connectionString = connectionString;
            this.isCodeFirst = isCodeFirst;

        }
        public bool Persist(object entity)
        {
            if (entity==null)
            {
                throw new ArgumentNullException("Cannot persist null entity");
            }
            if (isCodeFirst && !CheckIfTableExists(entity.GetType()))
            {
                this.CreateTable(entity.GetType());
            }

            Type entityType = entity.GetType();
            FieldInfo idInfo = GetID(entityType);
            int id = (int)idInfo.GetValue(entity);

            if (id<0)
            {
                return this.Insert(entityType, idInfo);
            }
            else
            {
                return this.Update(entityType, idInfo);
            }


        }

        private bool CheckIfTableExists(Type type)
        {
            string query = "select count(name) " +
                           "from sys.sysobjects " +
                           $"where [Name] = '{this.GetTableName(type)}' and [xtype] = 'U'";
            int numberOfTables = 0;
            using ( connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query,connection);
                numberOfTables = (int) command.ExecuteScalar();
            }
            return numberOfTables > 0;
        }

        private bool Update(Type entityType, FieldInfo idInfo)
        {
            int affectedRows = 0;
            //Todo
            return affectedRows > 0;
        }

        private bool Insert(Type entityType, FieldInfo idInfo)
        {
            int affectedRows = 0;
            //todo
            return affectedRows > 0;
        }

        public T FindById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>(string @where)
        {
            throw new NotImplementedException();
        }

        public T FindFirst<T>()
        {
            throw new NotImplementedException();
        }

        public T FindFirst<T>(string @where)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(object entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById<T>(int id)
        {
            throw new NotImplementedException();
        }

        private FieldInfo GetID(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Cannot get id for null type");
            }
            FieldInfo id =
                entity.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .FirstOrDefault(x => x.IsDefined(typeof(IdAttribute)));
            if (id == null)
            {
                throw new ArgumentNullException("No id field was found for the current class");
            }

            return id;
        }

        private string GetTableName(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Cannot get table name for null type");
            }

            if (!entity.IsDefined(typeof(EntityAttribute)))
            {
                throw new ArgumentException("Cannot get table name of entity");
            }
            string tableName = entity.GetCustomAttribute<EntityAttribute>().TableName;
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentNullException("Table name cannot be null");
            }
            return tableName;
        }

        private string GetColumnName(FieldInfo field)
        {
            if (field == null)
            {
                throw new ArgumentNullException("Field cannot be null");
            }
            if (!field.IsDefined(typeof(ColumnAttribute)))
            {
                return field.Name;
            }
            string columnName = field.GetCustomAttribute<ColumnAttribute>().ColumnName;
            if (string.IsNullOrEmpty(columnName))
            {
                throw new ArgumentNullException("Could not get column name");
            }
            return columnName;
        }

        private void CreateTable(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            string creationString = PrepareTableCreationString(entity);

            using (connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(creationString,this.connection);
                command.ExecuteNonQuery();
            }


        }

        private string PrepareTableCreationString(Type entity)
        {
            FieldInfo[] columnsInfos =
                entity.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(x => x.IsDefined(typeof(ColumnAttribute)))
                    .ToArray();
            //string[] columnNames = columnsInfos.Select(x => x.GetCustomAttribute<ColumnAttribute>().ColumnName).ToArray();

            StringBuilder sb = new StringBuilder();
            sb.Append($"Create table {GetTableName(entity)} (");
            sb.Append($"Id int primary key identity, ");

            foreach (var columnField in columnsInfos)
            {
                sb.Append($"{GetColumnName(columnField)} {GetTypeToDB(columnField)}, ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(")");
            return sb.ToString();
        }

        private string GetTypeToDB(FieldInfo info)
        {
            switch (info.FieldType.Name)
            {
                case "Int32":
                    return "INT";
                case "String":
                    return "varchar(max)";
                case "DateTime":
                    return "datetime";
                case "Boolean":
                    return "bit";
                default:
                    throw new ArgumentException("Type not supported yet");
                
            }
        }
    }
}
