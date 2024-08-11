﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VillageRentalsMS.Interface;

namespace VillageRentalsMS.Domain
{
    internal class Category : IDatasetTable
    {
        // =====================================  INSTANCE FIELDS ======================================
        private int _category_id;
        private string _note;

        // ========================================  PROPERTIES ========================================
        public int Category_ID { get { return _category_id; } set { _category_id = value; } }
        public string Note { get { return _note; } set { _note = value; } }

        // =======================================  CONSTRUCTORS =======================================
        public Category (int category_id, string note)
        {
            Category_ID = category_id;
            Note = note;
        }

        // ==========================================  METHODS =========================================

        /// <summary>
        /// Blob.
        /// </summary>
        /// <param name="value">Blob.</param>
        /// <returns>Blob.</returns>
        public void UpdateDataset()
        {

        }

        /// <summary>
        /// Blob.
        /// </summary>
        /// <param name="value">Blob.</param>
        /// <returns>Blob.</returns>
        public Category GetObjectFromDataset(int category_id)
        {
            return category;
        }

    }
}
