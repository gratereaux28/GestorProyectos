using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using GestorProyectos.Extensions.sys;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace GestorProyectos.Extensions.Entity
{
    public static class LinqExtension
    {
        public static IOrderedQueryable<T> OrderBy<T>(
              this IQueryable<T> source,
              string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(
            this IQueryable<T> source,
            string property)
        {
            return ApplyOrder<T>(source, property, "OrderByDescending");
        }

        public static IOrderedQueryable<T> ThenBy<T>(
            this IOrderedQueryable<T> source,
            string property)
        {
            return ApplyOrder<T>(source, property, "ThenBy");
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(
            this IOrderedQueryable<T> source,
            string property)
        {
            return ApplyOrder<T>(source, property, "ThenByDescending");
        }

        static IOrderedQueryable<T> ApplyOrder<T>(
            IQueryable<T> source,
            string property,
            string methodName,
             Func<T, object> orderBy = null)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            bool isObj = false;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                if (isObj)
                {
                    expr = Expression.Coalesce(expr, Expression.New(expr.Type));
                    expr = Expression.Property(expr, pi);

                }
                else
                {
                    expr = Expression.Property(expr, pi);
                }
                type = pi.PropertyType;
                isObj = true;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }


        public static byte[] ToExcel<T>(
         this IEnumerable<T> source, string[] columnsDescripccion, string[] columnsName)
        {
            byte[] result = new byte[1];
            IWorkbook workbook = new XSSFWorkbook();
            ISheet excelSheet = workbook.CreateSheet("Sheet 1");
            //var stylesHelpers = new NPOIHelpers(workbook);
            IRow row = excelSheet.CreateRow(0);

            for (int i = 0; i < columnsDescripccion.Length; i++)
            {
                var cell = row.CreateCell(i);
                cell.SetCellValue(columnsDescripccion[i]);
            }
            var list = source.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                row = excelSheet.CreateRow(i + 1);
                for (int j = 0; j < columnsName.Length; j++)
                {
                    var cell = row.CreateCell(j);
                    cell.SetCellValue(list[i].GetValue(columnsName[j]));
                }
            }
            MemoryStream output = new MemoryStream();
            workbook.Write(output);
            workbook.Close();
            result = output.ToArray();
            return result;
        }

        public static byte[] ToExcel(this DataTable dt)
        {
            byte[] result = new byte[1];
            IWorkbook workbook = new XSSFWorkbook();
            ISheet excelSheet = workbook.CreateSheet("Sheet 1");
            IRow row = excelSheet.CreateRow(0);

            for (int j = 0; j < dt.Columns.Count; j++)
            {
                var cell = row.CreateCell(j);
                cell.SetCellValue(dt.Columns[j].ToString());
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var dtRow = dt.Rows[i];
                row = excelSheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var cell = row.CreateCell(j);
                    cell.SetCellValue(dtRow[j].ToString());
                }
            }
            MemoryStream output = new MemoryStream();
            workbook.Write(output);
            workbook.Close();
            result = output.ToArray();
            return result;
        }



        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

        private static readonly FieldInfo QueryModelGeneratorField = QueryCompilerTypeInfo.DeclaredFields.First(x => x.Name == "_queryModelGenerator");

        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

        private static readonly PropertyInfo DatabaseDependenciesField = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");

        //public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        //{
        //    var queryCompiler = (QueryCompiler)QueryCompilerField.GetValue(query.Provider);
        //    var modelGenerator = (QueryModelGenerator)QueryModelGeneratorField.GetValue(queryCompiler);
        //    var queryModel = modelGenerator.ParseQuery(query.Expression);
        //    var database = (IDatabase)DataBaseField.GetValue(queryCompiler);
        //    var databaseDependencies = (DatabaseDependencies)DatabaseDependenciesField.GetValue(database);
        //    var queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
        //    var modelVisitor = (Microsoft.EntityFrameworkCore.Query.RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
        //    modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
        //    var sql = modelVisitor.Queries.First().ToString();
        //    return sql;
        //}

        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            else if (type == typeof(string))
            {
                return "";
            }
            return null;
        }
    }
}