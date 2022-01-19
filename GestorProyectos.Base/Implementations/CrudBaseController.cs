using GestorProyectos.Base.Attributes;
using GestorProyectos.Base.Interfaces;
using GestorProyectos.Base.Output;
using GestorProyectos.Extensions.Entity;
using GestorProyectos.Extensions.sys;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace GestorProyectos.Base.Implementations
{
    public class CrudBaseController<T, TEntity> : BaseController where T : IBaseRepository<TEntity> where TEntity : class
    {
        protected T currentRepository;
        protected Expression<Func<TEntity, object>> orderBy;
        protected Expression<Func<TEntity, object>> groupBy;
        protected string orderByString;

        protected delegate Expression<Func<TEntity, bool>> GetQuerySearch(string searchValue);
        protected GetQuerySearch getSearch;
        protected Expression<Func<TEntity, bool>> getQueryCount;
        string bodyString;
        protected IHostingEnvironment _hostingEnvironment;
        public CrudBaseController(T _repository)
        {
            currentRepository = _repository;
        }

        [Read]
        public virtual IActionResult GetAll()
        {
            try
            {
                return Ok(currentRepository.ListAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Read]
        public virtual IActionResult GetByFilter(string text)
        {
            try
            {
                return Ok(currentRepository.GetByFilter(text));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Read]
        protected string GetQueryStringValue(string key)
        {
            string result = HttpContext.Request.Query[key];
            if (result == null)
            {
                if (Request.Form.Count > 0)
                {
                    foreach (var item in Request.Form.Keys)
                    {
                        if (item.ToLower() == key.ToLower())
                        {
                            result = Request.Form[item];
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(result))
                {
                    string[] splitValues = bodyString.Split('&');
                    var GetItems = splitValues.Where(x => x.Contains(key + "="));
                    if (GetItems == null)
                    {
                        result = string.Empty;
                    }
                    else
                    {
                        foreach (var item in GetItems)
                        {
                            result = item.Replace(key + "=", "");
                            if (!string.IsNullOrEmpty(result))
                                break;
                        }
                    }
                }
            }
            return result;
        }

        [Read]
        private void LoadBody()
        {
            using (var mem = new MemoryStream())
            using (var reader = new StreamReader(mem))
            {
                Request.Body.CopyTo(mem);
                var body = reader.ReadToEnd();
                mem.Seek(0, SeekOrigin.Begin);
                bodyString = WebUtility.UrlDecode(reader.ReadToEnd());
            }
        }

        protected int draw = 0;
        protected int start = 0;
        protected int length = 0;
        protected string drawString;
        protected string startString;
        protected string lengthString;
        protected string searchValue;
        protected string orderColumnIndex;
        protected string orderDireccion;
        protected string orderColumn;
        protected string json_filter;
        protected string orderByValue;
        protected string[] columnsName;
        protected string[] columnsDescription;
        protected bool setGroupby = false;
        protected int countFiltered;
        protected Expression<Func<TEntity, bool>> currentQuery;

        [Read]
        protected virtual void GatherData()
        {
            draw = 0;
            start = 0;
            length = 0;
            LoadBody();
            drawString = GetQueryStringValue(nameof(draw));
            startString = GetQueryStringValue(nameof(start));
            lengthString = GetQueryStringValue(nameof(length));
            searchValue = GetQueryStringValue("search[value]");
            orderColumnIndex = GetQueryStringValue("order[0][column]");
            orderDireccion = GetQueryStringValue("order[0][dir]");
            orderColumn = GetQueryStringValue($"columns[{orderColumnIndex}][data]");
            json_filter = GetQueryStringValue($"json_filter");
            orderByValue = string.Empty;
            if (!string.IsNullOrEmpty(orderColumn))
            {
                orderByValue = $"{orderColumn} {orderDireccion}";
            }
            if (string.IsNullOrEmpty(orderByValue) && !string.IsNullOrEmpty(this.orderByString))
            {
                orderByValue = this.orderByString;
            }

            int.TryParse(drawString, out draw);
            int.TryParse(startString, out start);
            int.TryParse(lengthString, out length);
        }


        [Read]
        protected virtual void CustomGroupBy(IEnumerable<TEntity> data)
        {
            //setGroupby = true;
        }

        [Read]
        protected virtual DataTables<TEntity> EvaluarDataTables()
        {
            DataTables<TEntity> data = new DataTables<TEntity>();
            GatherData();

            if (getSearch != null || currentQuery != null)
            {
                searchValue = searchValue.ToLower();
                if (getSearch != null)
                    currentQuery = getSearch(searchValue);

                data.data = currentRepository.Get(currentQuery, groupBy, orderByValue, orderBy, length, start, json_filter).ToList();
                countFiltered = currentRepository.Count(currentQuery, groupBy, json_filter);
            }
            else
            {
                countFiltered = currentRepository.Count(null, groupBy, json_filter);
                data.data = currentRepository.Get(null, groupBy, orderByValue, orderBy, length, start, json_filter).ToList();
            }

            if (getQueryCount != null)
                data.recordsTotal = currentRepository.Count(getQueryCount, groupBy);
            else
                data.recordsTotal = currentRepository.Count(null, groupBy);

            data.draw = draw;
            data.recordsFiltered = countFiltered;
            setGroupby = false;
            return data;

        }

        [Read]
        [Consumes("application/json")]
        public virtual ActionResult GetDataTable()
        {
            DataTables<TEntity> data = new DataTables<TEntity>();
            try
            {
                SetInclude();
                data = EvaluarDataTables();
                return Ok(data);
            }
            catch (Exception ex)
            {
                data.data = new List<TEntity>();
                data.Error = ex.Message;
                return Ok(data);
            }
        }

        [Read]
        protected virtual void SetInclude()
        {

        }

        //public virtual ActionResult ExportExcel([FromForm] ExportViewModel viewModel)
        //{
        //    DataTables<TEntity> data = new DataTables<TEntity>();
        //    try
        //    {
        //        byte[] excel = new byte[0];
        //        SetInclude();
        //        if (getSearch != null || currentQuery != null)
        //        {
        //            searchValue = searchValue.ToLower();
        //            if (getSearch != null)
        //                currentQuery = getSearch(searchValue);

        //            data.data = currentRepository.Get(currentQuery, groupBy, orderByValue, orderBy, length, start, viewModel.json_filter).ToList();
        //        }
        //        else
        //        {
        //            data.data = currentRepository.Get(null, groupBy, orderByValue, orderBy, length, start, viewModel.json_filter).ToList();
        //        }
        //        columnsName = typeof(TEntity).UpdateColumnsName(viewModel.columnsName);
        //        Guid fileName = Guid.NewGuid();
        //        if (!Directory.Exists("Content"))
        //        {
        //            Directory.CreateDirectory("Content");
        //        }
        //        System.IO.File.WriteAllBytes($"Content/data_{fileName}.xlsx", data.data.ToExcel(viewModel.columnsDescription, columnsName));
        //        return Ok(fileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        data.data = new List<TEntity>();
        //        data.Error = ex.Message;
        //        return Ok(data);
        //    }
        //}

        [Read]
        public IActionResult GetFile(Guid fileName)
        {
            var fileArray = System.IO.File.ReadAllBytes($"Content/data_{fileName}.xlsx");
            System.IO.File.Delete($"Content/data_{fileName}.xlsx");
            return File(fileArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"data_{DateTime.Now.ToString("yyyyMMddhhmmss")}.xlsx");
        }

        [Read]
        public IActionResult GetFileFromDocuments(string fileName)
        {
            string link = Path.Combine(_hostingEnvironment.WebRootPath, "documents");
            link = Path.Combine(link, fileName);

            var fileArray = System.IO.File.ReadAllBytes(link);
            return File(fileArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        [Read]
        public virtual IActionResult Add(TEntity model)
        {
            try
            {
                currentRepository.Add(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Read]
        public virtual IActionResult Update(TEntity model)
        {
            try
            {
                currentRepository.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Read]
        public virtual IActionResult Delete(TEntity model)
        {
            try
            {
                currentRepository.Delete(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public virtual IActionResult GetWhere(string json)
        //{
        //    try
        //    {
        //        var where = currentRepository.Get(currentQuery, null, "", orderBy, 0, 0, json).AsQueryable().ToSql();
        //        if (!string.IsNullOrEmpty(where))
        //        {
        //            var splittedWhere = where.Split("WHERE");
        //            if (splittedWhere.Length > 1)
        //            {
        //                where = splittedWhere[1];
        //                for (char c = 'a'; c <= 'z'; c++)
        //                {
        //                    where = where.Replace($"[{c}].", "");
        //                }
        //                var orderByIndex = where.IndexOf("ORDER");
        //                if (orderByIndex > -1)
        //                {
        //                    where = where.Remove(orderByIndex);
        //                    return Ok(where);
        //                }
        //            }
        //        }
        //        return Ok("1 = 1");
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return Ok();
        //}
    }
}