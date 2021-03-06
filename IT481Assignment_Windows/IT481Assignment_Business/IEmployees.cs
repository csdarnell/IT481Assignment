﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481Assignment_Business
{
    public interface IEmployees
    {
        /// <summary>
        /// Employee Count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// A read-only list of employees
        /// </summary>
        IReadOnlyCollection<Employee> List { get; }
        /// <summary>
        /// Refresh the Employee Data
        /// </summary>
        void Refresh();
    }
}
