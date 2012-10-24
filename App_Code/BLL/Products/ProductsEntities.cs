﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Web;


namespace echo.BLL.Products
{
    /// <summary>
    /// Summary description for ProductsEntities
    /// </summary>
    public partial  class ProductsEntities
    {
        //Обработчик событие проверяющий сущности на валидность
        private void ProductsEntities_SavingChanges(object sender, EventArgs e)
        {
            List<ObjectStateEntry> typeEntries = (from entry in
                                                      ObjectStateManager.GetObjectStateEntries(EntityState.Added |
                                                                                               EntityState.Modified)
                                                  where entry.Entity is IBaseEntity
                                                  select entry).ToList();
            foreach (ObjectStateEntry ose in typeEntries)
            {
                var lBaseEntity = (IBaseEntity)ose.Entity;
                if (!lBaseEntity.IsValid)
                    throw new Exception(string.Format("Значение {0} не правильно", lBaseEntity.SetName));
            }
        }
    }
}
