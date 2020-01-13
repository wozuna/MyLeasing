using Microsoft.AspNetCore.Mvc.Rendering;
using MyLeasing.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _datacontext;

        public CombosHelper(DataContext dataContext)
        {
            _datacontext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboPropertyTypes()
        {
            var list = _datacontext.PropertyTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                //Value = pt.Id.ToString()
                Value = $"{pt.Id}"
            }).OrderBy(pt => pt.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a property type...)",
                Value = "0"
            });

            return list;
        }

    }
}
